
namespace Cyotek.Demo.Windows.Forms
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.GroupBox repositoryGroupBox;
      System.Windows.Forms.GroupBox revisionsGroupBox;
      System.Windows.Forms.GroupBox migrateGroupBox;
      System.Windows.Forms.GroupBox gitRepositoryGroupBox;
      System.Windows.Forms.Label gitRepositoryPathLabel;
      System.Windows.Forms.GroupBox authorsGroupBox;
      System.Windows.Forms.SplitContainer globsSplitContainer;
      System.Windows.Forms.GroupBox includesGroupBox;
      System.Windows.Forms.GroupBox excludesGroupBox;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.refreshButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.svnBranchUrlComboBox = new System.Windows.Forms.ComboBox();
      this.revisionsListView = new Cyotek.Windows.Forms.ListView();
      this.revisionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.messageColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.logTextBox = new System.Windows.Forms.TextBox();
      this.useExistingRepositoryCheckBox = new System.Windows.Forms.CheckBox();
      this.gitRepositoryPathBrowseButton = new System.Windows.Forms.Button();
      this.gitRepositoryPathTextBox = new System.Windows.Forms.TextBox();
      this.authorMappingsTextBox = new System.Windows.Forms.TextBox();
      this.includesTextBox = new System.Windows.Forms.TextBox();
      this.excludesTextBox = new System.Windows.Forms.TextBox();
      this.migrateButton = new System.Windows.Forms.Button();
      this.migrateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.revisionCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.cancelToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSettingsOnExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSettingsNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.allowEmptyCommitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabList = new Cyotek.Windows.Forms.TabList();
      this.svnTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.authorMappingTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.globsTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.gitTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.changesetBackgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.changesetTimer = new System.Windows.Forms.Timer(this.components);
      this.commandPanel = new System.Windows.Forms.Panel();
      this.previousButton = new System.Windows.Forms.Button();
      this.nextButton = new System.Windows.Forms.Button();
      this.selectionChangeTimer = new System.Windows.Forms.Timer(this.components);
      repositoryGroupBox = new System.Windows.Forms.GroupBox();
      revisionsGroupBox = new System.Windows.Forms.GroupBox();
      migrateGroupBox = new System.Windows.Forms.GroupBox();
      gitRepositoryGroupBox = new System.Windows.Forms.GroupBox();
      gitRepositoryPathLabel = new System.Windows.Forms.Label();
      authorsGroupBox = new System.Windows.Forms.GroupBox();
      globsSplitContainer = new System.Windows.Forms.SplitContainer();
      includesGroupBox = new System.Windows.Forms.GroupBox();
      excludesGroupBox = new System.Windows.Forms.GroupBox();
      repositoryGroupBox.SuspendLayout();
      revisionsGroupBox.SuspendLayout();
      migrateGroupBox.SuspendLayout();
      gitRepositoryGroupBox.SuspendLayout();
      authorsGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(globsSplitContainer)).BeginInit();
      globsSplitContainer.Panel1.SuspendLayout();
      globsSplitContainer.Panel2.SuspendLayout();
      globsSplitContainer.SuspendLayout();
      includesGroupBox.SuspendLayout();
      excludesGroupBox.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.tabList.SuspendLayout();
      this.svnTabListPage.SuspendLayout();
      this.authorMappingTabListPage.SuspendLayout();
      this.globsTabListPage.SuspendLayout();
      this.gitTabListPage.SuspendLayout();
      this.commandPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // repositoryGroupBox
      // 
      repositoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      repositoryGroupBox.Controls.Add(this.refreshButton);
      repositoryGroupBox.Controls.Add(this.label1);
      repositoryGroupBox.Controls.Add(this.svnBranchUrlComboBox);
      repositoryGroupBox.Location = new System.Drawing.Point(3, 3);
      repositoryGroupBox.Name = "repositoryGroupBox";
      repositoryGroupBox.Size = new System.Drawing.Size(681, 54);
      repositoryGroupBox.TabIndex = 0;
      repositoryGroupBox.TabStop = false;
      repositoryGroupBox.Text = "Repository";
      // 
      // refreshButton
      // 
      this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.refreshButton.Image = global::Cyotek.SvnMigrate.Client.Properties.Resources.Refresh;
      this.refreshButton.Location = new System.Drawing.Point(652, 17);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(23, 23);
      this.refreshButton.TabIndex = 2;
      this.refreshButton.UseVisualStyleBackColor = true;
      this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Branch URL:";
      // 
      // svnBranchUrlComboBox
      // 
      this.svnBranchUrlComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.svnBranchUrlComboBox.Location = new System.Drawing.Point(81, 19);
      this.svnBranchUrlComboBox.Name = "svnBranchUrlComboBox";
      this.svnBranchUrlComboBox.Size = new System.Drawing.Size(565, 21);
      this.svnBranchUrlComboBox.TabIndex = 1;
      this.svnBranchUrlComboBox.TextChanged += new System.EventHandler(this.SvnBranchUrlTextBox_TextChanged);
      // 
      // revisionsGroupBox
      // 
      revisionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      revisionsGroupBox.Controls.Add(this.revisionsListView);
      revisionsGroupBox.Location = new System.Drawing.Point(3, 63);
      revisionsGroupBox.Name = "revisionsGroupBox";
      revisionsGroupBox.Size = new System.Drawing.Size(681, 353);
      revisionsGroupBox.TabIndex = 1;
      revisionsGroupBox.TabStop = false;
      revisionsGroupBox.Text = "Revisions";
      // 
      // revisionsListView
      // 
      this.revisionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.revisionsListView.CheckBoxes = true;
      this.revisionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.revisionColumnHeader,
            this.authorColumnHeader,
            this.dateColumnHeader,
            this.messageColumnHeader});
      this.revisionsListView.FullRowSelect = true;
      this.revisionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.revisionsListView.HideSelection = false;
      this.revisionsListView.Location = new System.Drawing.Point(6, 19);
      this.revisionsListView.Name = "revisionsListView";
      this.revisionsListView.Size = new System.Drawing.Size(669, 328);
      this.revisionsListView.TabIndex = 0;
      this.revisionsListView.UseCompatibleStateImageBehavior = false;
      this.revisionsListView.View = System.Windows.Forms.View.Details;
      this.revisionsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.RevisionsListView_ItemChecked);
      // 
      // revisionColumnHeader
      // 
      this.revisionColumnHeader.Text = "Revision";
      this.revisionColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // authorColumnHeader
      // 
      this.authorColumnHeader.Text = "Author";
      this.authorColumnHeader.Width = 70;
      // 
      // dateColumnHeader
      // 
      this.dateColumnHeader.Text = "Date";
      this.dateColumnHeader.Width = 120;
      // 
      // messageColumnHeader
      // 
      this.messageColumnHeader.Text = "Message";
      this.messageColumnHeader.Width = 380;
      // 
      // migrateGroupBox
      // 
      migrateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      migrateGroupBox.Controls.Add(this.logTextBox);
      migrateGroupBox.Location = new System.Drawing.Point(3, 81);
      migrateGroupBox.Name = "migrateGroupBox";
      migrateGroupBox.Size = new System.Drawing.Size(681, 335);
      migrateGroupBox.TabIndex = 1;
      migrateGroupBox.TabStop = false;
      migrateGroupBox.Text = "&Log";
      // 
      // logTextBox
      // 
      this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.logTextBox.Location = new System.Drawing.Point(6, 19);
      this.logTextBox.Multiline = true;
      this.logTextBox.Name = "logTextBox";
      this.logTextBox.ReadOnly = true;
      this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.logTextBox.Size = new System.Drawing.Size(669, 310);
      this.logTextBox.TabIndex = 0;
      // 
      // gitRepositoryGroupBox
      // 
      gitRepositoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      gitRepositoryGroupBox.Controls.Add(this.useExistingRepositoryCheckBox);
      gitRepositoryGroupBox.Controls.Add(this.gitRepositoryPathBrowseButton);
      gitRepositoryGroupBox.Controls.Add(gitRepositoryPathLabel);
      gitRepositoryGroupBox.Controls.Add(this.gitRepositoryPathTextBox);
      gitRepositoryGroupBox.Location = new System.Drawing.Point(3, 3);
      gitRepositoryGroupBox.Name = "gitRepositoryGroupBox";
      gitRepositoryGroupBox.Size = new System.Drawing.Size(681, 72);
      gitRepositoryGroupBox.TabIndex = 0;
      gitRepositoryGroupBox.TabStop = false;
      gitRepositoryGroupBox.Text = "Repository";
      // 
      // useExistingRepositoryCheckBox
      // 
      this.useExistingRepositoryCheckBox.AutoSize = true;
      this.useExistingRepositoryCheckBox.Location = new System.Drawing.Point(6, 45);
      this.useExistingRepositoryCheckBox.Name = "useExistingRepositoryCheckBox";
      this.useExistingRepositoryCheckBox.Size = new System.Drawing.Size(131, 17);
      this.useExistingRepositoryCheckBox.TabIndex = 3;
      this.useExistingRepositoryCheckBox.Text = "Use &existing repository";
      this.useExistingRepositoryCheckBox.UseVisualStyleBackColor = true;
      // 
      // gitRepositoryPathBrowseButton
      // 
      this.gitRepositoryPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gitRepositoryPathBrowseButton.Location = new System.Drawing.Point(600, 17);
      this.gitRepositoryPathBrowseButton.Name = "gitRepositoryPathBrowseButton";
      this.gitRepositoryPathBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.gitRepositoryPathBrowseButton.TabIndex = 2;
      this.gitRepositoryPathBrowseButton.Text = "&Browse...";
      this.gitRepositoryPathBrowseButton.UseVisualStyleBackColor = true;
      this.gitRepositoryPathBrowseButton.Click += new System.EventHandler(this.GitRepositoryPathBrowseButton_Click);
      // 
      // gitRepositoryPathLabel
      // 
      gitRepositoryPathLabel.AutoSize = true;
      gitRepositoryPathLabel.Location = new System.Drawing.Point(3, 22);
      gitRepositoryPathLabel.Name = "gitRepositoryPathLabel";
      gitRepositoryPathLabel.Size = new System.Drawing.Size(85, 13);
      gitRepositoryPathLabel.TabIndex = 0;
      gitRepositoryPathLabel.Text = "&Repository Path:";
      // 
      // gitRepositoryPathTextBox
      // 
      this.gitRepositoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gitRepositoryPathTextBox.Location = new System.Drawing.Point(94, 19);
      this.gitRepositoryPathTextBox.Name = "gitRepositoryPathTextBox";
      this.gitRepositoryPathTextBox.Size = new System.Drawing.Size(500, 20);
      this.gitRepositoryPathTextBox.TabIndex = 1;
      // 
      // authorsGroupBox
      // 
      authorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      authorsGroupBox.Controls.Add(this.authorMappingsTextBox);
      authorsGroupBox.Location = new System.Drawing.Point(3, 3);
      authorsGroupBox.Name = "authorsGroupBox";
      authorsGroupBox.Size = new System.Drawing.Size(681, 413);
      authorsGroupBox.TabIndex = 2;
      authorsGroupBox.TabStop = false;
      authorsGroupBox.Text = "&Authors";
      // 
      // authorMappingsTextBox
      // 
      this.authorMappingsTextBox.AcceptsReturn = true;
      this.authorMappingsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.authorMappingsTextBox.Location = new System.Drawing.Point(6, 19);
      this.authorMappingsTextBox.Multiline = true;
      this.authorMappingsTextBox.Name = "authorMappingsTextBox";
      this.authorMappingsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.authorMappingsTextBox.Size = new System.Drawing.Size(669, 388);
      this.authorMappingsTextBox.TabIndex = 1;
      // 
      // globsSplitContainer
      // 
      globsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      globsSplitContainer.Location = new System.Drawing.Point(0, 0);
      globsSplitContainer.Name = "globsSplitContainer";
      globsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // globsSplitContainer.Panel1
      // 
      globsSplitContainer.Panel1.Controls.Add(includesGroupBox);
      // 
      // globsSplitContainer.Panel2
      // 
      globsSplitContainer.Panel2.Controls.Add(excludesGroupBox);
      globsSplitContainer.Size = new System.Drawing.Size(687, 419);
      globsSplitContainer.SplitterDistance = 207;
      globsSplitContainer.TabIndex = 0;
      // 
      // includesGroupBox
      // 
      includesGroupBox.Controls.Add(this.includesTextBox);
      includesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      includesGroupBox.Location = new System.Drawing.Point(0, 0);
      includesGroupBox.Name = "includesGroupBox";
      includesGroupBox.Size = new System.Drawing.Size(687, 207);
      includesGroupBox.TabIndex = 0;
      includesGroupBox.TabStop = false;
      includesGroupBox.Text = "&Inclusion Patterns";
      // 
      // includesTextBox
      // 
      this.includesTextBox.AcceptsReturn = true;
      this.includesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.includesTextBox.Location = new System.Drawing.Point(6, 19);
      this.includesTextBox.Multiline = true;
      this.includesTextBox.Name = "includesTextBox";
      this.includesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.includesTextBox.Size = new System.Drawing.Size(675, 182);
      this.includesTextBox.TabIndex = 2;
      // 
      // excludesGroupBox
      // 
      excludesGroupBox.Controls.Add(this.excludesTextBox);
      excludesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      excludesGroupBox.Location = new System.Drawing.Point(0, 0);
      excludesGroupBox.Name = "excludesGroupBox";
      excludesGroupBox.Size = new System.Drawing.Size(687, 208);
      excludesGroupBox.TabIndex = 1;
      excludesGroupBox.TabStop = false;
      excludesGroupBox.Text = "&Exclusion Patterns";
      // 
      // excludesTextBox
      // 
      this.excludesTextBox.AcceptsReturn = true;
      this.excludesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.excludesTextBox.Location = new System.Drawing.Point(6, 19);
      this.excludesTextBox.Multiline = true;
      this.excludesTextBox.Name = "excludesTextBox";
      this.excludesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.excludesTextBox.Size = new System.Drawing.Size(675, 183);
      this.excludesTextBox.TabIndex = 2;
      // 
      // migrateButton
      // 
      this.migrateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.migrateButton.Location = new System.Drawing.Point(763, 6);
      this.migrateButton.Name = "migrateButton";
      this.migrateButton.Size = new System.Drawing.Size(75, 23);
      this.migrateButton.TabIndex = 2;
      this.migrateButton.Text = "&Migrate";
      this.migrateButton.UseVisualStyleBackColor = true;
      this.migrateButton.Click += new System.EventHandler(this.MigrateButton_Click);
      // 
      // migrateBackgroundWorker
      // 
      this.migrateBackgroundWorker.WorkerReportsProgress = true;
      this.migrateBackgroundWorker.WorkerSupportsCancellation = true;
      this.migrateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MigrateBackgroundWorker_DoWork);
      this.migrateBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MigrateBackgroundWorker_ProgressChanged);
      this.migrateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MigrateBackgroundWorker_RunWorkerCompleted);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.revisionCountToolStripStatusLabel,
            this.toolStripProgressBar,
            this.cancelToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 492);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(845, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(701, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // revisionCountToolStripStatusLabel
      // 
      this.revisionCountToolStripStatusLabel.Name = "revisionCountToolStripStatusLabel";
      this.revisionCountToolStripStatusLabel.Size = new System.Drawing.Size(129, 17);
      this.revisionCountToolStripStatusLabel.Text = "0 Revisions (0 Selected)";
      // 
      // toolStripProgressBar
      // 
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
      this.toolStripProgressBar.Visible = false;
      // 
      // cancelToolStripStatusLabel
      // 
      this.cancelToolStripStatusLabel.IsLink = true;
      this.cancelToolStripStatusLabel.Name = "cancelToolStripStatusLabel";
      this.cancelToolStripStatusLabel.Size = new System.Drawing.Size(43, 17);
      this.cancelToolStripStatusLabel.Text = "Cancel";
      this.cancelToolStripStatusLabel.Visible = false;
      this.cancelToolStripStatusLabel.Click += new System.EventHandler(this.CancelToolStripStatusLabel_Click);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(845, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsOnExitToolStripMenuItem,
            this.saveSettingsNowToolStripMenuItem,
            this.toolStripMenuItem1,
            this.allowEmptyCommitsToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // saveSettingsOnExitToolStripMenuItem
      // 
      this.saveSettingsOnExitToolStripMenuItem.Checked = true;
      this.saveSettingsOnExitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.saveSettingsOnExitToolStripMenuItem.Name = "saveSettingsOnExitToolStripMenuItem";
      this.saveSettingsOnExitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.saveSettingsOnExitToolStripMenuItem.Text = "Save Settings on &Exit";
      // 
      // saveSettingsNowToolStripMenuItem
      // 
      this.saveSettingsNowToolStripMenuItem.Name = "saveSettingsNowToolStripMenuItem";
      this.saveSettingsNowToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.saveSettingsNowToolStripMenuItem.Text = "Save Settings &Now";
      this.saveSettingsNowToolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsNowToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
      // 
      // allowEmptyCommitsToolStripMenuItem
      // 
      this.allowEmptyCommitsToolStripMenuItem.CheckOnClick = true;
      this.allowEmptyCommitsToolStripMenuItem.Name = "allowEmptyCommitsToolStripMenuItem";
      this.allowEmptyCommitsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
      this.allowEmptyCommitsToolStripMenuItem.Text = "&Allow Empty Commits";
      this.allowEmptyCommitsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.AllowEmptyCommitsToolStripMenuItem_CheckedChanged);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // tabList
      // 
      this.tabList.Controls.Add(this.svnTabListPage);
      this.tabList.Controls.Add(this.authorMappingTabListPage);
      this.tabList.Controls.Add(this.globsTabListPage);
      this.tabList.Controls.Add(this.gitTabListPage);
      this.tabList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabList.Location = new System.Drawing.Point(0, 24);
      this.tabList.Name = "tabList";
      this.tabList.Size = new System.Drawing.Size(845, 427);
      this.tabList.TabIndex = 1;
      this.tabList.SelectedIndexChanged += new System.EventHandler(this.TabList_SelectedIndexChanged);
      // 
      // svnTabListPage
      // 
      this.svnTabListPage.Controls.Add(revisionsGroupBox);
      this.svnTabListPage.Controls.Add(repositoryGroupBox);
      this.svnTabListPage.Name = "svnTabListPage";
      this.svnTabListPage.Size = new System.Drawing.Size(687, 419);
      this.svnTabListPage.Text = "SVN";
      // 
      // authorMappingTabListPage
      // 
      this.authorMappingTabListPage.Controls.Add(authorsGroupBox);
      this.authorMappingTabListPage.Name = "authorMappingTabListPage";
      this.authorMappingTabListPage.Size = new System.Drawing.Size(687, 419);
      this.authorMappingTabListPage.Text = "Author Mapping";
      // 
      // globsTabListPage
      // 
      this.globsTabListPage.Controls.Add(globsSplitContainer);
      this.globsTabListPage.Name = "globsTabListPage";
      this.globsTabListPage.Size = new System.Drawing.Size(687, 419);
      this.globsTabListPage.Text = "Inclusion / Exclusion";
      // 
      // gitTabListPage
      // 
      this.gitTabListPage.Controls.Add(migrateGroupBox);
      this.gitTabListPage.Controls.Add(gitRepositoryGroupBox);
      this.gitTabListPage.Name = "gitTabListPage";
      this.gitTabListPage.Size = new System.Drawing.Size(687, 419);
      this.gitTabListPage.Text = "Git";
      // 
      // changesetBackgroundWorker
      // 
      this.changesetBackgroundWorker.WorkerSupportsCancellation = true;
      this.changesetBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChangesetBackgroundWorker_DoWork);
      this.changesetBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ChangesetBackgroundWorker_RunWorkerCompleted);
      // 
      // changesetTimer
      // 
      this.changesetTimer.Interval = 500;
      this.changesetTimer.Tick += new System.EventHandler(this.ChangesetTimer_Tick);
      // 
      // commandPanel
      // 
      this.commandPanel.Controls.Add(this.previousButton);
      this.commandPanel.Controls.Add(this.nextButton);
      this.commandPanel.Controls.Add(this.migrateButton);
      this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.commandPanel.Location = new System.Drawing.Point(0, 451);
      this.commandPanel.Name = "commandPanel";
      this.commandPanel.Size = new System.Drawing.Size(845, 41);
      this.commandPanel.TabIndex = 2;
      // 
      // previousButton
      // 
      this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.previousButton.Enabled = false;
      this.previousButton.Location = new System.Drawing.Point(595, 6);
      this.previousButton.Name = "previousButton";
      this.previousButton.Size = new System.Drawing.Size(75, 23);
      this.previousButton.TabIndex = 0;
      this.previousButton.Text = "&Previous";
      this.previousButton.UseVisualStyleBackColor = true;
      this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
      // 
      // nextButton
      // 
      this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nextButton.Location = new System.Drawing.Point(676, 6);
      this.nextButton.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
      this.nextButton.Name = "nextButton";
      this.nextButton.Size = new System.Drawing.Size(75, 23);
      this.nextButton.TabIndex = 1;
      this.nextButton.Text = "&Next";
      this.nextButton.UseVisualStyleBackColor = true;
      this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
      // 
      // selectionChangeTimer
      // 
      this.selectionChangeTimer.Tick += new System.EventHandler(this.SelectionChangeTimer_Tick);
      // 
      // MainForm
      // 
      this.AcceptButton = this.migrateButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(845, 514);
      this.Controls.Add(this.tabList);
      this.Controls.Add(this.commandPanel);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Cyotek Svn2Git Migration Utility";
      repositoryGroupBox.ResumeLayout(false);
      repositoryGroupBox.PerformLayout();
      revisionsGroupBox.ResumeLayout(false);
      migrateGroupBox.ResumeLayout(false);
      migrateGroupBox.PerformLayout();
      gitRepositoryGroupBox.ResumeLayout(false);
      gitRepositoryGroupBox.PerformLayout();
      authorsGroupBox.ResumeLayout(false);
      authorsGroupBox.PerformLayout();
      globsSplitContainer.Panel1.ResumeLayout(false);
      globsSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(globsSplitContainer)).EndInit();
      globsSplitContainer.ResumeLayout(false);
      includesGroupBox.ResumeLayout(false);
      includesGroupBox.PerformLayout();
      excludesGroupBox.ResumeLayout(false);
      excludesGroupBox.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.tabList.ResumeLayout(false);
      this.svnTabListPage.ResumeLayout(false);
      this.authorMappingTabListPage.ResumeLayout(false);
      this.globsTabListPage.ResumeLayout(false);
      this.gitTabListPage.ResumeLayout(false);
      this.commandPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox svnBranchUrlComboBox;
    private System.Windows.Forms.Button migrateButton;
    private System.ComponentModel.BackgroundWorker migrateBackgroundWorker;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    private System.Windows.Forms.TextBox logTextBox;
    private System.Windows.Forms.ToolStripStatusLabel cancelToolStripStatusLabel;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private Cyotek.Windows.Forms.TabList tabList;
    private Cyotek.Windows.Forms.TabListPage svnTabListPage;
    private Cyotek.Windows.Forms.TabListPage gitTabListPage;
    private Cyotek.Windows.Forms.ListView revisionsListView;
    private System.Windows.Forms.ColumnHeader revisionColumnHeader;
    private System.Windows.Forms.ColumnHeader authorColumnHeader;
    private System.Windows.Forms.ColumnHeader dateColumnHeader;
    private System.Windows.Forms.ColumnHeader messageColumnHeader;
    private System.ComponentModel.BackgroundWorker changesetBackgroundWorker;
    private System.Windows.Forms.Timer changesetTimer;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private Cyotek.Windows.Forms.TabListPage authorMappingTabListPage;
    private System.Windows.Forms.TextBox gitRepositoryPathTextBox;
    private System.Windows.Forms.TextBox authorMappingsTextBox;
    private System.Windows.Forms.Button gitRepositoryPathBrowseButton;
    private System.Windows.Forms.Panel commandPanel;
    private System.Windows.Forms.Button previousButton;
    private System.Windows.Forms.Button nextButton;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSettingsOnExitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSettingsNowToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem allowEmptyCommitsToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel revisionCountToolStripStatusLabel;
    private System.Windows.Forms.Timer selectionChangeTimer;
    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.CheckBox useExistingRepositoryCheckBox;
    private Cyotek.Windows.Forms.TabListPage globsTabListPage;
    private System.Windows.Forms.TextBox includesTextBox;
    private System.Windows.Forms.TextBox excludesTextBox;
  }
}

