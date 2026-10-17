using System;
using System.Windows.Forms;

namespace Cyotek.SvnMigrate.Client
{
  internal sealed partial class CredentialsDialog : BaseForm
  {
    #region Public Constructors

    public CredentialsDialog()
    {
      this.InitializeComponent();
    }

    public CredentialsDialog(string realm, string initialUserName, bool canSave)
      : this()
    {
      realmTextBox.Text = realm;
      userNameTextBox.Text = initialUserName;

      saveAuthenticationCheckBox.Checked = canSave;
      saveAuthenticationCheckBox.Enabled = canSave;
    }

    #endregion

    #region Public Properties

    public string Password => passwordTextBox.Text;

    public bool SaveCredentials => saveAuthenticationCheckBox.Enabled && saveAuthenticationCheckBox.Checked;

    public string UserName => userNameTextBox.Text;

    #endregion

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    #endregion
  }
}
