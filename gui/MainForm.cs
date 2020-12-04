﻿using Cyotek.SvnMigrate;
using Cyotek.SvnMigrate.Client;
using LibGit2Sharp;
using SharpSvn;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private SvnChangesetCollection _svnRevisions;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.Text = Application.ProductName;
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

#if DEBUG
      //svnTextBox.Text = "https://hades:8443/svn/cyotek/trunk/cyotek/source/Libraries/Cyotek.Web.BbCodeFormatter";
      svnBranchUrlTextBox.Text = "https://hades:8443/svn/cyotek/trunk/cyotek/source/Applications/ErrorVault";
      gitRepositoryPathTextBox.Text = @"C:\svnmig\" + DateTime.Now.Ticks;
      authorMappingsTextBox.Text = "Richard = Richard Moss <richard.moss@cyotek.com>";
#endif
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void AddBlankMapping(string name)
    {
      bool found;

      found = false;

      foreach (string line in authorMappingsTextBox.Lines)
      {
        if (!string.IsNullOrEmpty(line))
        {
          int nameEnd;

          nameEnd = line.IndexOf('=');

          if (nameEnd != -1)
          {
            string test;

            test = line.Substring(0, nameEnd).Trim();

            if (string.Equals(name, test, StringComparison.OrdinalIgnoreCase))
            {
              found = true;
              break;
            }
          }
        }
      }

      if (!found)
      {
        authorMappingsTextBox.AppendText(string.Format("\r\n{0} = {0} <>", name));
      }
    }

    private SvnChangesetCollection BuildRevisionsList(Uri svnUri)
    {
      SvnChangesetCollection sets;

      sets = new SvnChangesetCollection();

      using (SvnClient svn = new SvnClient())
      {
        svn.Log(svnUri, (o, args) =>
        {
          sets.Add(new SvnChangeset
          {
            Author = new User
            {
              Name = args.Author
            },
            Revision = args.Revision,
            Time = args.Time,
            Log = args.LogMessage,
            IsSelected = true
          });
          args.Detach();
        });
      }

      return sets;
    }

    private void CancelToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      migrateBackgroundWorker.CancelAsync();
    }

    private void ChangesetBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      string url;
      SvnChangesetCollection changesets;

      url = (string)e.Argument;

      if (!string.IsNullOrEmpty(url))
      {
        changesets = this.BuildRevisionsList(new Uri(url));
      }
      else
      {
        changesets = new SvnChangesetCollection();
      }

      e.Result = changesets;
    }

    private void ChangesetBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      revisionsListView.Items.Clear();

      _svnRevisions = (SvnChangesetCollection)e.Result;

      if (e.Error == null)
      {
        revisionsListView.BeginUpdate();

        for (int i = 0; i < _svnRevisions.Count; i++)
        {
          SvnChangeset changeset;

          changeset = _svnRevisions[i];

          revisionsListView.Items.Add(
            new ListViewItem
            {
              Checked = true,
              Tag = i,
              Text = changeset.Revision.ToString(),
              SubItems =
              {
                changeset.Author.ToString(),
                changeset.Time.ToString(),
                changeset.Log
              }
            });

          this.AddBlankMapping(changeset.Author.Name);
        }

        revisionsListView.EndUpdate();
      }
      else
      {
        MessageBox.Show(string.Format("Failed to load revisions. {0}", e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ChangesetTimer_Tick(object sender, EventArgs e)
    {
      changesetTimer.Stop();

      changesetBackgroundWorker.RunWorkerAsync(svnBranchUrlTextBox.Text);
    }

    private void Checkout(Uri svnUri, SvnChangeset set, string workPath)
    {
      using (SvnClient svn = new SvnClient())
      {
        if (Directory.Exists(workPath))
        {
          svn.Switch(workPath, new SvnUriTarget(svnUri, set.Revision));
        }
        else
        {
          svn.CheckOut(svnUri, workPath, new SvnCheckOutArgs
          {
            Revision = set.Revision
          });
        }
      }
    }

    private void Commit(string gitPath, SvnChangeset set)
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

        author = new Signature(set.Author.Name, set.Author.EmailAddress, set.Time);
        committer = author;

        commit = repo.Commit(set.Log, author, committer, commitOptions);
      }
    }

    private string CreateGitRepository(string path)
    {
      Directory.CreateDirectory(path);

      return Repository.Init(path);
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private UserCollection GetAuthorMapping()
    {
      UserCollection results;

      results = new UserCollection();

      foreach (string line in authorMappingsTextBox.Lines)
      {
        if (!string.IsNullOrEmpty(line))
        {
          int nameEnd;

          nameEnd = line.IndexOf('=');

          if (nameEnd != -1)
          {
            int emailStart;
            int emailEnd;

            emailStart = line.IndexOf('<', nameEnd);
            emailEnd = line.IndexOf('>', emailStart);

            if (emailStart != -1 && emailEnd != -1)
            {
              string alternateName;
              string name;
              string email;

              alternateName = line.Substring(0, nameEnd).Trim();
              name = line.Substring(nameEnd + 1, emailStart - (nameEnd + 1)).Trim();
              email = line.Substring(emailStart + 1, emailEnd - (emailStart + 1)).Trim();

              results.Add(name, email, alternateName);
            }
          }
        }
      }

      return results;
    }

    private SvnChangesetCollection GetOrderedRevisions()
    {
      SvnChangesetCollection revisions;

      revisions = new SvnChangesetCollection();

      foreach (SvnChangeset revision in _svnRevisions)
      {
        if (revision.IsSelected)
        {
          revisions.Add(revision);
        }
      }

      revisions.Sort();

      return revisions;
    }

    private void GitRepositoryPathBrowseButton_Click(object sender, EventArgs e)
    {
      string path;

      path = FileDialogHelper.GetFolderName("Select git repository &path:", gitRepositoryPathTextBox.Text);

      if (!string.IsNullOrEmpty(path))
      {
        gitRepositoryPathTextBox.Text = path;
      }
    }

    private bool IsEmptyFolder(string path)
    {
      bool result;

      result = true;

      if (Directory.Exists(path))
      {
        foreach (string _ in Directory.EnumerateFileSystemEntries(path))
        {
          result = false;
          break;
        }
      }

      return result;
    }

    private void MigrateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      MigrationOptions options;
      Uri svnUri;
      SvnChangesetCollection sets;
      string workPath;
      string gitPath;
      ProgressState args;

      options = (MigrationOptions)e.Argument;
      svnUri = options.SvnUri;
      workPath = options.WorkingPath;
      gitPath = options.RepositoryPath;

      sets = options.Revisions;

      this.CreateGitRepository(gitPath);

      args = new ProgressState
      {
        Total = sets.Count
      };

      for (int i = 0; i < sets.Count; i++)
      {
        SvnChangeset set;
        int progress;

        set = sets[i];
        progress = Convert.ToInt32((double)i / sets.Count * 100);

        args.Current = i + 1;
        args.Changeset = set;

        migrateBackgroundWorker.ReportProgress(progress, args);

        if (string.IsNullOrEmpty(set.Author.EmailAddress))
        {
          set.Author = options.Authors.GetMapping(set.Author.Name);
        }

        this.Checkout(svnUri, set, workPath);
        SimpleFolderSync.SyncFolders(workPath, gitPath);
        this.Commit(gitPath, set);

        if (migrateBackgroundWorker.CancellationPending)
        {
          throw new ApplicationException("User cancelled operation.");
        }
      }

      ShellHelpers.DeletePath(workPath);
    }

    private void MigrateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      ProgressState args;

      args = (ProgressState)e.UserState;

      logTextBox.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString(), args.Changeset));
      statusToolStripStatusLabel.Text = string.Format("Migrating revision {0} of {1}...", args.Current, args.Total);
      toolStripProgressBar.Value = e.ProgressPercentage;
    }

    private void MigrateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        MessageBox.Show(string.Format("Migration failed. {0}", e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        MessageBox.Show("Migration complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      statusToolStripStatusLabel.Text = string.Empty; ;
      toolStripProgressBar.Value = 0;
      toolStripProgressBar.Visible = false;
      cancelToolStripStatusLabel.Visible = false;
      tabList.Enabled = true;
    }

    private void MigrateButton_Click(object sender, EventArgs e)
    {
      MigrationOptions options;

      Uri.TryCreate(svnBranchUrlTextBox.Text, UriKind.Absolute, out Uri svnUri);

      options = new MigrationOptions
      {
        SvnUri = svnUri,
        RepositoryPath = gitRepositoryPathTextBox.Text,
        WorkingPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()),
        Authors = this.GetAuthorMapping(),
        Revisions = this.GetOrderedRevisions()
      };

      if (this.ValidateOptions(options))
      {
        toolStripProgressBar.Visible = true;
        cancelToolStripStatusLabel.Visible = true;
        tabList.Enabled = false;

        migrateBackgroundWorker.RunWorkerAsync(options);
      }
    }

    private void RevisionsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      _svnRevisions[(int)e.Item.Tag].IsSelected = e.Item.Checked;
    }

    private void SvnBranchUrlTextBox_TextChanged(object sender, EventArgs e)
    {
      changesetTimer.Stop();
      changesetTimer.Start();
    }

    private bool ValidateOptions(MigrationOptions options)
    {
      bool result;

      result = false;

      if (options.SvnUri == null)
      {
        MessageBox.Show("SVN branch URI required.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (string.IsNullOrWhiteSpace(options.RepositoryPath))
      {
        MessageBox.Show("Git repository path required.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!this.IsEmptyFolder(options.RepositoryPath))
      {
        MessageBox.Show("Git repository location is not empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (options.Revisions.Count == 0)
      {
        MessageBox.Show("No revisions available.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (options.Revisions.Count(r => r.IsSelected) == 0)
      {
        MessageBox.Show("No revisions selected.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (options.Authors.Count == 0)
      {
        MessageBox.Show("No authors available.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        result = true;
      }

      return result;
    }

    #endregion Private Methods
  }
}