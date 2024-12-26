using Cyotek.SvnMigrate;
using Cyotek.SvnMigrate.Client;
using Cyotek.SvnMigrate.Client.Properties;
using DotNet.Globbing;
using LibGit2Sharp;
using SharpSvn;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020-2024 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private string _lastScannedUrl;

    private SvnChangesetCollection _svnRevisions;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      if (!e.Cancel && saveSettingsOnExitToolStripMenuItem.Checked)
      {
        this.SaveSettings();
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.Text = Application.ProductName;
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.LoadSettings();
    }

    #endregion Protected Methods

    #region Private Methods

    private static string DetectSvnBasePath(Uri svnUri)
    {
      string basePath = svnUri.AbsolutePath;

      // TODO: My old HTTP based SVN server had /svn/ in the URL, which needed stripping
      // My new SVN server uses the SVN protocol, which doesn't have this
      // I am unaware if there are other patterns so this is now driven by
      // a user setting, but hopefully auto detect will work

      if (svnUri.Scheme == "svn")
      {
        basePath = basePath.Substring(basePath.IndexOf('/', 1));
      }
      else
      {
        // TODO: Are there other patterns than svn/{reponame}/? if so, this is broke
        if (basePath.StartsWith("/svn/", StringComparison.OrdinalIgnoreCase))
        {
          basePath = basePath.Substring(basePath.IndexOf('/', 5));
        }
      }

      return basePath;
    }

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

    private void AllowEmptyCommitsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.AllowEmptyCommits = allowEmptyCommitsToolStripMenuItem.Checked;
    }

    private SvnChangesetCollection BuildRevisionsList(Uri svnUri, string basePath)
    {
      SvnChangesetCollection sets;

      sets = new SvnChangesetCollection();

      using (SvnClient svn = new SvnClient())
      {
        svn.Log(svnUri, (o, args) =>
        {
          SvnChangeset changeset;

          changeset = new SvnChangeset
          {
            Author = new User { Name = args.Author },
            Revision = args.Revision,
            Time = args.Time,
            Log = args.LogMessage,
            IsSelected = true
          };

          foreach (SvnChangeItem change in args.ChangedPaths)
          {
            if (!string.IsNullOrEmpty(change.Path) && change.Path.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
            {
              switch (change.Action)
              {
                case SvnChangeAction.Add:
                  changeset.NewPaths.Add(change.Path);
                  break;

                case SvnChangeAction.Delete:
                  changeset.RemovedPaths.Add(change.Path);
                  break;

                case SvnChangeAction.Modify:
                  changeset.ModifiedPaths.Add(change.Path);
                  break;

                case SvnChangeAction.Replace:
                  changeset.NewPaths.Add(change.Path);
                  if (change.CopyFromPath != null)
                  {
                    changeset.RemovedPaths.Add(change.CopyFromPath);
                  }
                  break;
              }

              changeset.ChangedPaths.Add(change.Path);
            }
          }

          sets.Add(changeset);
          args.Detach();

          args.Cancel = changesetBackgroundWorker.CancellationPending;
        });
      }

      return sets;
    }

    private void CancelToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      changesetBackgroundWorker.CancelAsync();
      migrateBackgroundWorker.CancelAsync();
    }

    private void ChangesetBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      MigrationOptions options;
      SvnChangesetCollection changesets;

      options = (MigrationOptions)e.Argument;

      changesets = options.SvnUri != null
        ? this.BuildRevisionsList(options.SvnUri, options.SvnBasePath)
        : new SvnChangesetCollection();

      e.Result = changesets;
    }

    private void ChangesetBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      revisionsListView.Items.Clear();

      if (e.Error == null)
      {
        _svnRevisions = (SvnChangesetCollection)e.Result;

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

        _lastScannedUrl = svnBranchUrlComboBox.Text;
        this.UpdateMru();
      }
      else
      {
        _svnRevisions = new SvnChangesetCollection();
        _lastScannedUrl = null;

        MessageBox.Show(string.Format("Failed to load revisions. {0}", e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      this.UpdateSelectionCount();
      this.ResetProgressUi();
    }

    private void ChangesetTimer_Tick(object sender, EventArgs e)
    {
      this.LoadRevisions();
    }

    private void Checkout(Uri svnUri, SvnChangeset set, string workPath)
    {
      using (SvnClient svn = new SvnClient())
      {
        if (Directory.Exists(workPath))
        {
          try
          {
            svn.Switch(workPath, new SvnUriTarget(svnUri, set.Revision));
          }
          catch (SvnFileSystemException)
          {
            // this seems to happen when you try to switch to a branch
            // without any file changes - revision 814 in Cyotek triggers this
            // in this case, we do a full checkout which seems to succeed fine
            ShellHelpers.DeletePath(workPath);
            this.FullCheckout(svn, svnUri, set, workPath);
          }
        }
        else
        {
          this.FullCheckout(svn, svnUri, set, workPath);
        }
      }
    }

    private void Commit(string gitPath, SvnChangeset set)
    {
      CommitOptions commitOptions;

      commitOptions = new CommitOptions
      {
        AllowEmptyCommit = Settings.Default.AllowEmptyCommits
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

    private MigrationOptions CreateMigrationOptions()
    {
      MigrationOptions options;

      Uri.TryCreate(svnBranchUrlComboBox.Text, UriKind.Absolute, out Uri svnUri);

      options = new MigrationOptions
      {
        SvnUri = svnUri,
        SvnBasePath = this.GetOrDefineSvnBasePath(svnUri),
        RepositoryPath = gitRepositoryPathTextBox.Text,
        WorkingPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()),
        Authors = this.GetAuthorMapping(),
        Revisions = this.GetOrderedRevisions(),
        UseExistingRepository = useExistingRepositoryCheckBox.Checked
      };

      return options;
    }

    private void EnumerateSvnChangeSets(BackgroundWorker worker, MigrationOptions options, Action<SvnChangeset> operation)
    {
      SvnChangesetCollection sets;
      Glob[] includes;
      Glob[] excludes;

      includes = GlobMatcher.PrepareGlobs(this.GetGlobs(includesTextBox));
      excludes = GlobMatcher.PrepareGlobs(this.GetGlobs(excludesTextBox));

      sets = options.Revisions;

      for (int i = 0; i < sets.Count; i++)
      {
        SvnChangeset set;
        int progress;
        ProgressState args;

        set = sets[i];
        progress = Convert.ToInt32((double)i / sets.Count * 100);

        args = new ProgressState
        {
          Total = sets.Count,
          Current = i + 1,
          Changeset = set
        };

        if (string.IsNullOrEmpty(set.Author.EmailAddress))
        {
          set.Author = options.Authors.GetMapping(set.Author.Name);
        }

        if (this.ShouldCheckout(set, includes, excludes))
        {
          worker.ReportProgress(progress, args);

          operation(set);
        }
        else
        {
          args.Changeset = null;
          worker.ReportProgress(progress, args);
        }

        if (worker.CancellationPending)
        {
          throw new OperationCanceledException();
        }
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FullCheckout(SvnClient svn, Uri svnUri, SvnChangeset set, string workPath)
    {
      svn.CheckOut(svnUri, workPath, new SvnCheckOutArgs
      {
        Revision = set.Revision
      });
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

    private StringCollection GetGlobs(TextBox control)
    {
      StringCollection result;
      string[] lines;

      result = new StringCollection();
      lines = control.Lines;

      for (int i = 0; i < lines.Length; i++)
      {
        string line;

        line = lines[i].Trim();

        if (!string.IsNullOrWhiteSpace(line) && !result.Contains(line))
        {
          result.Add(line);
        }
      }

      return result;
    }

    private StringCollection GetMru()
    {
      StringCollection result;

      result = new StringCollection();

      for (int i = 0; i < svnBranchUrlComboBox.Items.Count; i++)
      {
        result.Add((string)svnBranchUrlComboBox.Items[i]);
      }

      return result;
    }

    private string GetOrDefineSvnBasePath(Uri svnUri)
    {
      return string.IsNullOrWhiteSpace(basePathTextBox.Text)
        ? DetectSvnBasePath(svnUri)
        : basePathTextBox.Text;
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

    private void ListPreviewFiles(StringBuilder sb, string basePath, StringCollection fileNames, string operation, Glob[] includes, Glob[] excludes)
    {
      foreach (string fileName in fileNames)
      {
        if (GlobMatcher.ShouldInclude(fileName, includes, excludes))
        {
          string shortName;

          shortName = fileName.StartsWith(basePath, StringComparison.OrdinalIgnoreCase)
            ? fileName.Substring(basePath.Length)
            : fileName;

          sb.AppendFormat("\t{0}: {1}\r\n", operation, shortName);
        }
      }
    }

    private void LoadGlobs(TextBox control, StringCollection globs)
    {
      if (globs != null && globs.Count > 0)
      {
        StringBuilder sb;

        sb = new StringBuilder();

        for (int i = 0; i < globs.Count; i++)
        {
          sb.AppendLine(globs[i]);
        }

        control.Text = sb.ToString();
      }
      else
      {
        control.Text = string.Empty;
      }
    }

    private void LoadMru(Settings settings)
    {
      svnBranchUrlComboBox.Items.Clear();

      if (settings.SvnBranchUriMru != null)
      {
        svnBranchUrlComboBox.BeginUpdate();
        foreach (string uri in settings.SvnBranchUriMru)
        {
          svnBranchUrlComboBox.Items.Add(uri);
        }
        svnBranchUrlComboBox.EndUpdate();
      }
    }

    private void LoadRevisions()
    {
      string uri;

      changesetTimer.Stop();

      uri = svnBranchUrlComboBox.Text;

      if (!string.Equals(uri, _lastScannedUrl))
      {
        Uri svnUri;

        this.PrepareProgressUi("Building revision list...");

        if (!string.IsNullOrEmpty(uri))
        {
          if (!Uri.TryCreate(uri, UriKind.Absolute, out svnUri))
          {
            MessageBox.Show("Invalid URI.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          svnUri = null;
        }

        changesetBackgroundWorker.RunWorkerAsync(new MigrationOptions
        {
          SvnUri = svnUri,
          SvnBasePath = this.GetOrDefineSvnBasePath(svnUri),
        });
      }
    }

    private void LoadSettings()
    {
      Settings settings;

      settings = Settings.Default;
      this.LoadMru(settings);
      svnBranchUrlComboBox.Text = settings.SvnBranchUri;
      basePathTextBox.Text = settings.SvnBasePath;
      gitRepositoryPathTextBox.Text = settings.GitRepositoryPath;
      authorMappingsTextBox.Text = settings.AuthorMapping;
      saveSettingsOnExitToolStripMenuItem.Checked = settings.SaveSettingsOnExit;
      allowEmptyCommitsToolStripMenuItem.Checked = settings.AllowEmptyCommits;
      useExistingRepositoryCheckBox.Checked = settings.UseExistingRepository;
      this.LoadGlobs(includesTextBox, settings.IncludeGlobs);
      this.LoadGlobs(excludesTextBox, settings.ExcludeGlobs);
    }

    private void MigrateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      MigrationOptions options;
      Uri svnUri;
      string workPath;
      string gitPath;
      StringCollection includes;
      StringCollection excludes;

      options = (MigrationOptions)e.Argument;
      svnUri = options.SvnUri;
      workPath = options.WorkingPath;
      gitPath = options.RepositoryPath;
      includes = this.GetGlobs(includesTextBox);
      excludes = this.GetGlobs(excludesTextBox);

      this.CreateGitRepository(gitPath);

      this.EnumerateSvnChangeSets(migrateBackgroundWorker, options, set =>
      {
        this.Checkout(svnUri, set, workPath);
        SimpleFolderSync.SyncFolders(workPath, gitPath, includes, excludes);

        try
        {
          this.Commit(gitPath, set);
        }
        catch (EmptyCommitException)
        {
          // ignore, if we get this the user has
          // disabled the option to allow empty commits
        }
      });

      ShellHelpers.DeletePath(workPath);
    }

    private void MigrateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      ProgressState args;

      args = (ProgressState)e.UserState;

      statusToolStripStatusLabel.Text = string.Format("Processing revision {0} of {1}...", args.Current, args.Total);
      toolStripProgressBar.Value = e.ProgressPercentage;
      statusStrip.Refresh();

      if (args.Changeset != null)
      {
        logTextBox.AppendText(string.Format("{0}\t{1}\r\n", DateTime.Now.ToString(), args.Changeset));
      }
    }

    private void MigrateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      string action;

      action = sender == migrateBackgroundWorker
        ? "Migration"
        : "Preview";

      if (e.Error != null)
      {
        MessageBox.Show(string.Format("{0} failed. {1}", action, e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        MessageBox.Show(string.Format("{0} complete.", action), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      if (e.Result != null)
      {
        logTextBox.Text = e.Result.ToString();
      }

      this.ResetProgressUi();
    }

    private void MigrateButton_Click(object sender, EventArgs e)
    {
      MigrationOptions options;

      options = this.CreateMigrationOptions();

      if (this.ValidateOptions(options))
      {
        this.PrepareProgressUi("Migrating...");

        tabList.SelectedPage = logTabListPage;

        migrateBackgroundWorker.RunWorkerAsync(options);
      }
    }

    private void NextButton_Click(object sender, EventArgs e)
    {
      tabList.SelectedIndex++;
    }

    private void PrepareProgressUi(string message)
    {
      Cursor.Current = Cursors.WaitCursor;
      this.UseWaitCursor = true;

      statusToolStripStatusLabel.Text = message;

      toolStripProgressBar.Visible = true;
      cancelToolStripStatusLabel.Visible = true;
      tabList.Enabled = false;
      commandPanel.Enabled = false;
    }

    private void PreviewBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      MigrationOptions options;
      Glob[] includes;
      Glob[] excludes;
      StringBuilder sb;
      string basePath;

      options = (MigrationOptions)e.Argument;
      includes = GlobMatcher.PrepareGlobs(this.GetGlobs(includesTextBox));
      excludes = GlobMatcher.PrepareGlobs(this.GetGlobs(excludesTextBox));
      sb = new StringBuilder();
      basePath = options.SvnBasePath;

      this.EnumerateSvnChangeSets(previewBackgroundWorker, options, set =>
      {
        sb.AppendFormat("{0} [{1}]\r\n{2}\r\n", set.Revision, set.Time, set.Log.Replace("\n", " ").Replace("\r", ""));

        this.ListPreviewFiles(sb, basePath, set.RemovedPaths, "DEL", includes, excludes);
        this.ListPreviewFiles(sb, basePath, set.ModifiedPaths, "MOD", includes, excludes);
        this.ListPreviewFiles(sb, basePath, set.NewPaths, "ADD", includes, excludes);
      });

      if (sb.Length == 0)
      {
        sb.AppendLine("Nothing found, is the base path or inclusions/exclusions correct?");
      }

      e.Result = sb.ToString();
    }

    private void PreviewButton_Click(object sender, EventArgs e)
    {
      MigrationOptions options;

      options = this.CreateMigrationOptions();

      if (this.ValidateOptions(options))
      {
        this.PrepareProgressUi("Building preview...");

        tabList.SelectedPage = logTabListPage;

        previewBackgroundWorker.RunWorkerAsync(options);
      }
    }

    private void PreviousButton_Click(object sender, EventArgs e)
    {
      tabList.SelectedIndex--;
    }

    private void RefreshBasePathButton_Click(object sender, EventArgs e)
    {
      string uri = svnBranchUrlComboBox.Text;

      if (!string.IsNullOrEmpty(uri) && Uri.TryCreate(uri, UriKind.Absolute, out Uri svnUri))
      {
        basePathTextBox.Text = DetectSvnBasePath(svnUri);
      }
      else
      {
        MessageBox.Show("Invalid URI.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      _lastScannedUrl = null;

      this.LoadRevisions();
    }

    private void ResetProgressUi()
    {
      Cursor.Current = Cursors.Default;
      this.UseWaitCursor = false;

      statusToolStripStatusLabel.Text = string.Empty;
      toolStripProgressBar.Value = 0;
      toolStripProgressBar.Visible = false;
      cancelToolStripStatusLabel.Visible = false;
      tabList.Enabled = true;
      commandPanel.Enabled = true;
    }

    private void RevisionsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      _svnRevisions[(int)e.Item.Tag].IsSelected = e.Item.Checked;

      selectionChangeTimer.Stop();
      selectionChangeTimer.Start();
    }

    private void SaveSettings()
    {
      Settings settings;

      settings = Settings.Default;

      settings.SvnBranchUri = svnBranchUrlComboBox.Text;
      settings.SvnBasePath = basePathTextBox.Text;
      settings.GitRepositoryPath = gitRepositoryPathTextBox.Text;
      settings.AuthorMapping = authorMappingsTextBox.Text;
      settings.SaveSettingsOnExit = saveSettingsOnExitToolStripMenuItem.Checked;
      settings.UseExistingRepository = useExistingRepositoryCheckBox.Checked;
      settings.SvnBranchUriMru = this.GetMru();
      settings.IncludeGlobs = this.GetGlobs(includesTextBox);
      settings.ExcludeGlobs = this.GetGlobs(excludesTextBox);

      settings.Save();
    }

    private void SaveSettingsNowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveSettings();
    }

    private void SelectionChangeTimer_Tick(object sender, EventArgs e)
    {
      selectionChangeTimer.Stop();

      this.UpdateSelectionCount();
    }

    private bool ShouldCheckout(SvnChangeset set, Glob[] includeGlobs, Glob[] excludeGlobs)
    {
      bool result;

      result = false;

      foreach (string fileName in set.ChangedPaths)
      {
        if (GlobMatcher.ShouldInclude(fileName, includeGlobs, excludeGlobs))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private void SvnBranchUrlTextBox_TextChanged(object sender, EventArgs e)
    {
      changesetTimer.Stop();
      changesetTimer.Start();
    }

    private void TabList_SelectedIndexChanged(object sender, EventArgs e)
    {
      previousButton.Enabled = tabList.SelectedIndex > 0;
      nextButton.Enabled = tabList.SelectedIndex < tabList.TabListPageCount - 1;
    }

    private void UpdateMru()
    {
      string uri;
      int index;

      uri = svnBranchUrlComboBox.Text;
      index = svnBranchUrlComboBox.FindStringExact(uri);

      if (index != -1 && index != 0)
      {
        svnBranchUrlComboBox.Items.RemoveAt(index);
      }

      if (index != 0)
      {
        svnBranchUrlComboBox.Items.Insert(0, uri);
        svnBranchUrlComboBox.SelectedIndex = 0;
      }

      while (svnBranchUrlComboBox.Items.Count > 256)
      {
        svnBranchUrlComboBox.Items.RemoveAt(svnBranchUrlComboBox.Items.Count - 1);
      }
    }

    private void UpdateSelectionCount()
    {
      revisionCountToolStripStatusLabel.Text = string.Format("{0} Revisions ({1} Selected)", revisionsListView.Items.Count, revisionsListView.CheckedIndices.Count);
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
      else if (!options.UseExistingRepository && !this.IsEmptyFolder(options.RepositoryPath))
      {
        MessageBox.Show("Git repository location is not empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (options.UseExistingRepository && !Repository.IsValid(options.RepositoryPath))
      {
        MessageBox.Show("Git repository location does not point to a valid Git repository.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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