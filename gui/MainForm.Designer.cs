
namespace Cyotek.SvnMigrate.Client
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
      this.label1 = new System.Windows.Forms.Label();
      this.svnTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.gitTextBox = new System.Windows.Forms.TextBox();
      this.migrateButton = new System.Windows.Forms.Button();
      this.migrateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.logTextBox = new System.Windows.Forms.TextBox();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(72, 92);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&SVN Path:";
      // 
      // svnTextBox
      // 
      this.svnTextBox.Location = new System.Drawing.Point(75, 108);
      this.svnTextBox.Name = "svnTextBox";
      this.svnTextBox.Size = new System.Drawing.Size(561, 20);
      this.svnTextBox.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(72, 137);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "&GIT Path:";
      // 
      // gitTextBox
      // 
      this.gitTextBox.Location = new System.Drawing.Point(75, 153);
      this.gitTextBox.Name = "gitTextBox";
      this.gitTextBox.Size = new System.Drawing.Size(561, 20);
      this.gitTextBox.TabIndex = 3;
      // 
      // migrateButton
      // 
      this.migrateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.migrateButton.Location = new System.Drawing.Point(561, 292);
      this.migrateButton.Name = "migrateButton";
      this.migrateButton.Size = new System.Drawing.Size(75, 23);
      this.migrateButton.TabIndex = 4;
      this.migrateButton.Text = "&Migrate";
      this.migrateButton.UseVisualStyleBackColor = true;
      this.migrateButton.Click += new System.EventHandler(this.migrateButton_Click);
      // 
      // migrateBackgroundWorker
      // 
      this.migrateBackgroundWorker.WorkerReportsProgress = true;
      this.migrateBackgroundWorker.WorkerSupportsCancellation = true;
      this.migrateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.migrateBackgroundWorker_DoWork);
      this.migrateBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.migrateBackgroundWorker_ProgressChanged);
      this.migrateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.migrateBackgroundWorker_RunWorkerCompleted);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.toolStripProgressBar});
      this.statusStrip.Location = new System.Drawing.Point(0, 428);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(800, 22);
      this.statusStrip.TabIndex = 6;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.AutoSize = false;
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(683, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripProgressBar
      // 
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
      // 
      // logTextBox
      // 
      this.logTextBox.Location = new System.Drawing.Point(75, 246);
      this.logTextBox.Multiline = true;
      this.logTextBox.Name = "logTextBox";
      this.logTextBox.ReadOnly = true;
      this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.logTextBox.Size = new System.Drawing.Size(337, 128);
      this.logTextBox.TabIndex = 7;
      // 
      // MainForm
      // 
      this.AcceptButton = this.migrateButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.migrateButton;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.logTextBox);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.migrateButton);
      this.Controls.Add(this.gitTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.svnTextBox);
      this.Controls.Add(this.label1);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox svnTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox gitTextBox;
    private System.Windows.Forms.Button migrateButton;
    private System.ComponentModel.BackgroundWorker migrateBackgroundWorker;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    private System.Windows.Forms.TextBox logTextBox;
  }
}

