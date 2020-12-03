using LibGit2Sharp;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  public partial class MainForm : Form
  {
    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

#if DEBUG
      //svnTextBox.Text = "https://hades:8443/svn/cyotek/trunk/cyotek/source/Libraries/Cyotek.Web.BbCodeFormatter";
      svnTextBox.Text = "https://hades:8443/svn/cyotek/trunk/cyotek/source/Applications/ErrorVault";
      gitTextBox.Text = @"C:\svnmig\" + DateTime.Now.Ticks;
#endif
    }

    #endregion Protected Methods

    #region Private Methods

    private List<Changeset> BuildChangesets(Uri svnUri)
    {
      List<Changeset> sets;

      sets = new List<Changeset>();

      using (SvnClient svn = new SvnClient())
      {
        svn.Log(svnUri, (o, args) =>
        {
          sets.Add(new Changeset
          {
            Author = args.Author,
            Revision = args.Revision,
            Time = args.Time,
            Log = args.LogMessage
          }); ;
          args.Detach();
        });
      }

      sets.Sort((x, y) => x.Revision.CompareTo(y.Revision));

      return sets;
    }

    private void Checkout(Uri svnUri, Changeset set, string workPath)
    {
      this.DeletePath(workPath);

      using (SvnClient svn = new SvnClient())
      {
        svn.CheckOut(svnUri, workPath, new SvnCheckOutArgs
        {
          Revision = set.Revision
        });
      }
    }

    private void Commit(string gitPath, Changeset set)
    {
      CommitOptions commitOptions;

      commitOptions = new CommitOptions
      {
        AllowEmptyCommit = true
      };

      using (Repository repo = new Repository(gitPath))
      {
        Signature author;
        Signature committer;
        Commit commit;

        Commands.Stage(repo, "*");

        author = new Signature("Richard Moss", "richard.moss@cyotek.com", set.Time);
        committer = author;

        commit = repo.Commit(set.Log, author, committer, commitOptions);
      }
    }

    private void CopyFiles(string srcPath, string dstPath)
    {
      foreach (string srcFile in Directory.EnumerateFiles(srcPath))
      {
        string dstFile;

        dstFile = Path.Combine(dstPath, Path.GetFileName(srcFile));

        File.Copy(srcFile, dstFile);
      }
    }

    private void CopyFolder(string src, string dst)
    {
      Stack<string> paths;

      if (src[src.Length - 1] == Path.DirectorySeparatorChar || src[src.Length - 1] == Path.DirectorySeparatorChar)
      {
        src = src.Substring(0, src.Length - 1);
      }

      paths = new Stack<string>();
      paths.Push("");

      do
      {
        string relative;
        string srcPath;
        string dstPath;

        relative = paths.Pop();
        srcPath = Path.Combine(src, relative);
        dstPath = Path.Combine(dst, relative);

        Directory.CreateDirectory(dstPath);

        this.CopyFiles(srcPath, dstPath);

        foreach (string child in Directory.EnumerateDirectories(srcPath))
        {
          if (!child.EndsWith("\\.svn", StringComparison.OrdinalIgnoreCase))
          {
            paths.Push(child.Substring(src.Length + 1));
          }
        }
      } while (paths.Count > 0);
    }

    private string CreateGitRepository(string path)
    {
      Directory.CreateDirectory(path);

      return Repository.Init(path);
    }

    private void DeleteFiles(string path)
    {
      foreach (string fileName in Directory.EnumerateFiles(path))
      {
        File.SetAttributes(fileName, FileAttributes.Normal);
        File.Delete(fileName);
      }
    }

    private void DeletePath(string root)
    {
      if (Directory.Exists(root))
      {
        Stack<string> paths;

        paths = new Stack<string>();
        paths.Push(root);

        do
        {
          string path;

          path = paths.Pop();

          this.DeleteFiles(path);

          foreach (string child in Directory.EnumerateDirectories(path))
          {
            paths.Push(child);
          }
        } while (paths.Count > 0);

        Directory.Delete(root, true);
      }
    }

    private void EmptyGitFolder(string path)
    {
      this.DeleteFiles(path);

      foreach (string child in Directory.EnumerateDirectories(path))
      {
        if (!child.EndsWith("\\.git", StringComparison.OrdinalIgnoreCase))
        {
          this.DeletePath(child);
        }
      }
    }

    private void migrateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      MigrationOptions options;
      Uri svnUri;
      List<Changeset> sets;
      string workPath;
      string gitPath;

      options = (MigrationOptions)e.Argument;
      svnUri = options.SvnUri;
      workPath = options.WorkingPath;
      gitPath = options.RepositoryPath;

      sets = this.BuildChangesets(svnUri);
      this.CreateGitRepository(gitPath);

      for (int i = 0; i < sets.Count; i++)
      {
        Changeset set;
        int progress;

        set = sets[i];
        progress = (int)(((float)i / sets.Count) * 100);

        migrateBackgroundWorker.ReportProgress(progress, set);

        this.Checkout(svnUri, set, workPath);
        this.EmptyGitFolder(gitPath);
        this.CopyFolder(workPath, gitPath);
        this.Commit(gitPath, set);

        if (migrateBackgroundWorker.CancellationPending)
        {
          break;
        }
      }

      this.DeletePath(workPath);
    }

    private void migrateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      Changeset set;

      set = (Changeset)e.UserState;

      logTextBox.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString(), set));
      statusToolStripStatusLabel.Text = string.Format("Migrating revision {0}...", set.Revision);
      toolStripProgressBar.Value = e.ProgressPercentage;
    }

    private void migrateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        MessageBox.Show(string.Format("Migration failed. {0}", e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if (migrateBackgroundWorker.CancellationPending)
      {
        MessageBox.Show("Migration cancelled.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        MessageBox.Show("Migration complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      statusToolStripStatusLabel.Text = string.Empty; ;
      toolStripProgressBar.Value = 0;
      toolStripProgressBar.Visible = false;
      cancelToolStripStatusLabel.Visible = false;
    }

    private void migrateButton_Click(object sender, EventArgs e)
    {
      MigrationOptions options;

      options = new MigrationOptions
      {
        SvnUri = new Uri(svnTextBox.Text),
        RepositoryPath = gitTextBox.Text,
        WorkingPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()),
        Authors =
        {
          new User("Richard Moss","richard.moss@cyotek.com","Richard")
        }
      };

      toolStripProgressBar.Visible = true;
      cancelToolStripStatusLabel.Visible = true;


      migrateBackgroundWorker.RunWorkerAsync(options);
    }

    #endregion Private Methods

    #region Private Classes

    private class Changeset
    {
      #region Public Properties

      public string Author { get; set; }

      public string Log { get; set; }

      public long Revision { get; set; }

      public DateTime Time { get; set; }

      public override string ToString()
      {
        return string.Format("Revision: {0}, Time: {1}, Author: {2}, Log: {3}", this.Revision, this.Time, this.Author, this.Log);
      }

      #endregion Public Properties
    }

    #endregion Private Classes

    private void cancelToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      migrateBackgroundWorker.CancelAsync();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}