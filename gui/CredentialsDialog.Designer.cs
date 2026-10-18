namespace Cyotek.SvnMigrate.Client
{
  partial class CredentialsDialog
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
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.saveAuthenticationCheckBox = new System.Windows.Forms.CheckBox();
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.passwordLabel = new System.Windows.Forms.Label();
      this.userNameTextBox = new System.Windows.Forms.TextBox();
      this.userNameLabel = new System.Windows.Forms.Label();
      this.infoLabel = new System.Windows.Forms.Label();
      this.realmTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(288, 218);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 17;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(207, 218);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 16;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // saveAuthenticationCheckBox
      // 
      this.saveAuthenticationCheckBox.AutoSize = true;
      this.saveAuthenticationCheckBox.Location = new System.Drawing.Point(12, 111);
      this.saveAuthenticationCheckBox.Name = "saveAuthenticationCheckBox";
      this.saveAuthenticationCheckBox.Size = new System.Drawing.Size(121, 17);
      this.saveAuthenticationCheckBox.TabIndex = 15;
      this.saveAuthenticationCheckBox.Text = "&Save authentication";
      this.saveAuthenticationCheckBox.UseVisualStyleBackColor = true;
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.passwordTextBox.Location = new System.Drawing.Point(76, 85);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(287, 20);
      this.passwordTextBox.TabIndex = 14;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // passwordLabel
      // 
      this.passwordLabel.AutoSize = true;
      this.passwordLabel.Location = new System.Drawing.Point(9, 88);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(56, 13);
      this.passwordLabel.TabIndex = 13;
      this.passwordLabel.Text = "&Password:";
      // 
      // userNameTextBox
      // 
      this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userNameTextBox.Location = new System.Drawing.Point(76, 59);
      this.userNameTextBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.userNameTextBox.Name = "userNameTextBox";
      this.userNameTextBox.Size = new System.Drawing.Size(287, 20);
      this.userNameTextBox.TabIndex = 12;
      // 
      // userNameLabel
      // 
      this.userNameLabel.AutoSize = true;
      this.userNameLabel.Location = new System.Drawing.Point(9, 62);
      this.userNameLabel.Name = "userNameLabel";
      this.userNameLabel.Size = new System.Drawing.Size(58, 13);
      this.userNameLabel.TabIndex = 11;
      this.userNameLabel.Text = "&Username:";
      // 
      // infoLabel
      // 
      this.infoLabel.AutoSize = true;
      this.infoLabel.Location = new System.Drawing.Point(9, 37);
      this.infoLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
      this.infoLabel.Name = "infoLabel";
      this.infoLabel.Size = new System.Drawing.Size(283, 13);
      this.infoLabel.TabIndex = 10;
      this.infoLabel.Text = "Enter the user name and password to access this resource";
      // 
      // realmTextBox
      // 
      this.realmTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.realmTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.realmTextBox.Location = new System.Drawing.Point(12, 12);
      this.realmTextBox.Name = "realmTextBox";
      this.realmTextBox.ReadOnly = true;
      this.realmTextBox.Size = new System.Drawing.Size(351, 13);
      this.realmTextBox.TabIndex = 9;
      // 
      // CredentialsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(375, 253);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.saveAuthenticationCheckBox);
      this.Controls.Add(this.passwordTextBox);
      this.Controls.Add(this.passwordLabel);
      this.Controls.Add(this.userNameTextBox);
      this.Controls.Add(this.userNameLabel);
      this.Controls.Add(this.infoLabel);
      this.Controls.Add(this.realmTextBox);
      this.Name = "CredentialsDialog";
      this.Text = "Authentication";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.CheckBox saveAuthenticationCheckBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.TextBox userNameTextBox;
    private System.Windows.Forms.Label userNameLabel;
    private System.Windows.Forms.Label infoLabel;
    private System.Windows.Forms.TextBox realmTextBox;
  }
}