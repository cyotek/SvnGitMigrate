namespace Cyotek.SvnMigrate.Client
{
  partial class RevisionInformationDialog
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
      System.Windows.Forms.Label revisionLabel;
      System.Windows.Forms.Label timestampLabel;
      System.Windows.Forms.Label authorLabel;
      System.Windows.Forms.Label dataLabel;
      this.revisionTextBox = new System.Windows.Forms.TextBox();
      this.timestampTextBox = new System.Windows.Forms.TextBox();
      this.authorTextBox = new System.Windows.Forms.TextBox();
      this.dataTextBox = new System.Windows.Forms.TextBox();
      this.closeButton = new System.Windows.Forms.Button();
      revisionLabel = new System.Windows.Forms.Label();
      timestampLabel = new System.Windows.Forms.Label();
      authorLabel = new System.Windows.Forms.Label();
      dataLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // revisionLabel
      // 
      revisionLabel.AutoSize = true;
      revisionLabel.Location = new System.Drawing.Point(9, 9);
      revisionLabel.Name = "revisionLabel";
      revisionLabel.Size = new System.Drawing.Size(51, 13);
      revisionLabel.TabIndex = 3;
      revisionLabel.Text = "&Revision:";
      // 
      // timestampLabel
      // 
      timestampLabel.AutoSize = true;
      timestampLabel.Location = new System.Drawing.Point(9, 31);
      timestampLabel.Name = "timestampLabel";
      timestampLabel.Size = new System.Drawing.Size(61, 13);
      timestampLabel.TabIndex = 5;
      timestampLabel.Text = "&Timestamp:";
      // 
      // authorLabel
      // 
      authorLabel.AutoSize = true;
      authorLabel.Location = new System.Drawing.Point(9, 50);
      authorLabel.Name = "authorLabel";
      authorLabel.Size = new System.Drawing.Size(41, 13);
      authorLabel.TabIndex = 7;
      authorLabel.Text = "&Author:";
      // 
      // dataLabel
      // 
      dataLabel.AutoSize = true;
      dataLabel.Location = new System.Drawing.Point(9, 66);
      dataLabel.Name = "dataLabel";
      dataLabel.Size = new System.Drawing.Size(33, 13);
      dataLabel.TabIndex = 0;
      dataLabel.Text = "&Data:";
      // 
      // revisionTextBox
      // 
      this.revisionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.revisionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.revisionTextBox.Location = new System.Drawing.Point(76, 12);
      this.revisionTextBox.Name = "revisionTextBox";
      this.revisionTextBox.ReadOnly = true;
      this.revisionTextBox.Size = new System.Drawing.Size(536, 13);
      this.revisionTextBox.TabIndex = 4;
      // 
      // timestampTextBox
      // 
      this.timestampTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.timestampTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.timestampTextBox.Location = new System.Drawing.Point(76, 31);
      this.timestampTextBox.Name = "timestampTextBox";
      this.timestampTextBox.ReadOnly = true;
      this.timestampTextBox.Size = new System.Drawing.Size(536, 13);
      this.timestampTextBox.TabIndex = 6;
      // 
      // authorTextBox
      // 
      this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.authorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.authorTextBox.Location = new System.Drawing.Point(76, 50);
      this.authorTextBox.Name = "authorTextBox";
      this.authorTextBox.ReadOnly = true;
      this.authorTextBox.Size = new System.Drawing.Size(536, 13);
      this.authorTextBox.TabIndex = 8;
      // 
      // dataTextBox
      // 
      this.dataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataTextBox.Location = new System.Drawing.Point(12, 82);
      this.dataTextBox.Multiline = true;
      this.dataTextBox.Name = "dataTextBox";
      this.dataTextBox.ReadOnly = true;
      this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dataTextBox.Size = new System.Drawing.Size(600, 318);
      this.dataTextBox.TabIndex = 1;
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(537, 406);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 2;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // RevisionInformationDialog
      // 
      this.AcceptButton = this.closeButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(624, 441);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.dataTextBox);
      this.Controls.Add(dataLabel);
      this.Controls.Add(this.authorTextBox);
      this.Controls.Add(authorLabel);
      this.Controls.Add(this.timestampTextBox);
      this.Controls.Add(timestampLabel);
      this.Controls.Add(this.revisionTextBox);
      this.Controls.Add(revisionLabel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Name = "RevisionInformationDialog";
      this.Text = "Revision Information";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox revisionTextBox;
    private System.Windows.Forms.TextBox timestampTextBox;
    private System.Windows.Forms.TextBox authorTextBox;
    private System.Windows.Forms.TextBox dataTextBox;
    private System.Windows.Forms.Button closeButton;
  }
}