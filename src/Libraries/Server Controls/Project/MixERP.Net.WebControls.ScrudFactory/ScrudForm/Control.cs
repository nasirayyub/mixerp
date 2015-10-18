using MixERP.Net.Common;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    [ToolboxData("<{0}:ScrudForm runat=server></{0}:ScrudForm>")]
    public partial class ScrudForm
    {
        private string imageColumn = string.Empty;
        private Panel scrudContainer;

        protected override void CreateChildControls()
        {
            this.Validate();
            this.ValidateRequestMode = ValidateRequestMode.Disabled;
            this.scrudContainer = new Panel();

            this.LoadScrudContainer(this.scrudContainer);

            this.LoadTitle();
            this.LoadDescription();

            this.LoadGrid();
            this.CreatePager(this.gridPanel);

            this.InitializeScrudControl();

            PageUtility.AddMeta(this.Page, "generator", Assembly.GetAssembly(typeof(ScrudForm)).GetName().Name);

            this.Controls.Add(this.scrudContainer);
        }

        protected override void RecreateChildControls()
        {
            this.EnsureChildControls();
        }

        protected override void Render(HtmlTextWriter w)
        {
            this.scrudContainer.RenderControl(w);
        }
    }
}