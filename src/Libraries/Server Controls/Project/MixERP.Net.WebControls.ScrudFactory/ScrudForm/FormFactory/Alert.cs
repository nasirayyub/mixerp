using MixERP.Net.Common;
using MixERP.Net.Framework;
using MixERP.Net.i18n.Resources;
using Serilog;
using System.Resources;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void DisplayError(MixERPException ex)
        {
            this.messageLabel.CssClass = this.GetErrorCssClass();
            this.messageLabel.ID = "ScrudError";

            string message = ex.Message;

            if (!string.IsNullOrWhiteSpace(ex.DBConstraintName))
            {
                message = this.GetLocalizedErrorMessage(ex);
            }

            this.messageLabel.Text = message;
            this.messageLabel.Style.Add("display", "block");
            this.messageLabel.Style.Add("font-size", "16px;");
            this.messageLabel.Style.Add("padding", "8px 0;");

            this.gridPanel.Attributes["style"] = "display:block;";
            this.formPanel.Attributes["style"] = "display:none;";

            Log.Warning("ScrudFactory: {Message}/{Exception}.", message, ex);

            this.ResetForm();
        }

        private string GetLocalizedErrorMessage(MixERPException ex)
        {
            try
            {
                return i18n.ResourceManager.GetString(this.GetResourceClassName(), ex.DBConstraintName);
            }
            catch (MissingManifestResourceException)
            {
                //swallow
            }

            return ex.Message;
        }

        private void DisplaySuccess()
        {
            this.messageLabel.CssClass = this.GetSuccessCssClass();
            this.messageLabel.Text = Titles.TaskCompletedSuccessfully;
            this.messageLabel.Style.Add("display", "block");

            this.gridPanel.Attributes["style"] = "display:block;";
            this.formPanel.Attributes["style"] = "display:none;";

            this.ResetForm();
        }
        private void ResetForm()
        {
            PageUtility.RegisterJavascript("ScrudFormReset", "$('#form1').each(function(){this.reset();});", this.Page, true);
        }
    }
}