using MixERP.Net.Common;
using MixERP.Net.Common.Helpers;
using MixERP.Net.WebControls.ScrudFactory.Data;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void BindGridView()
        {
            var limit = 10;
            var offset = 0;

            if (this.GetPageSize() != 0)
            {
                limit = this.GetPageSize();
            }


            if (this.Page.Request["page"] != null)
            {
                offset = (Conversion.TryCastInteger(this.Page.Request["page"]) - 1)*limit;
            }

            using (DataTable table = FormHelper.GetView(this.Catalog, this.ViewSchema, this.View, this.KeyColumn, limit, offset))
            {
                this.formGridView.DataSource = table;
                this.formGridView.DataBind();
            }
        }

        private Unit GetGridViewWidth()
        {
            if (this.GridViewWidth.Value.Equals(0))
            {
                var width = Conversion.TryCastUnit(DbConfig.GetScrudParameter(this.Catalog, "GridViewDefaultWidth"));

                return width;
            }

            return this.GridViewWidth;
        }

        private void LoadGrid()
        {
            this.BindGridView();

            this.formGridView.Width = this.GetGridViewWidth();
            this.formGridView.Attributes.Add("style", "white-space: nowrap;");

            this.userIdHidden.Value = this.UserId.ToString(CultureInfo.InvariantCulture);
            this.officeCodeHidden.Value = this.OfficeCode;
        }
    }
}