using MixERP.Net.Common;
using MixERP.Net.WebControls.ScrudFactory.Helpers;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void AddScrudScript()
        {
            var script = ScrudJavascriptHelper.GetScript(this.Catalog, this.KeyColumn, this.CustomFormUrl, this.formGridView.ID, this.gridPanel.ID, this.userIdHidden.ID, this.officeCodeHidden.ID, this.titleLabel.ID, this.formPanel.ID, this.cancelButton.ID);
            PageUtility.RegisterJavascript("ScrudFormScript", script, this.Page, true);
        }

        private void LoadScrudContainer(Panel p)
        {
            this.AddTitle(p);

            AddRuler(p);

            this.AddDescription(p);

            this.CreateCommandPanels();
            this.CreateGridPanel();
            this.CreateFormPanel();
            this.AddUpdatePanel(p);

            this.AddScrudScript();
        }
    }
}