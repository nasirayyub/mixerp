using MixERP.Net.Common;
using MixERP.Net.Common.Helpers;
using MixERP.Net.WebControls.ScrudFactory.Data;
using MixERP.Net.WebControls.ScrudFactory.Helpers;
using System;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudItemSelector
    {
        private void FilterSelectDataBound(object sender, EventArgs e)
        {
            using (DropDownList dropDownList = sender as DropDownList)
            {
                if (dropDownList == null)
                {
                    return;
                }

                foreach (ListItem item in dropDownList.Items)
                {
                    item.Text = ScrudLocalizationHelper.GetResourceString(this.GetResourceClassName(), item.Text);
                }
            }
        }

        private string GetResourceClassName()
        {
            if (string.IsNullOrWhiteSpace(this.ResourceClassName))
            {
                return DbConfig.GetScrudParameter(this.Catalog, "ResourceClassName");
            }

            return this.ResourceClassName;
        }

        private string GetSchema()
        {
            return Conversion.TryCastString(this.Page.Request["Schema"]);
        }

        private string GetView()
        {
            return Conversion.TryCastString(this.Page.Request["View"]);
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.GetSchema()))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(this.GetView()))
            {
                return;
            }

            using (
                var table = FormHelper.GetTable(this.Catalog, this.GetSchema(), this.GetView(),
                    this.filterSelect.SelectedItem.Value, this.filterInputText.Text, 10, "1"))
            {
                this.searchGridView.DataSource = table;
                this.searchGridView.DataBind();
            }
        }

        private void SearchGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    string cellText = e.Row.Cells[i].Text;

                    if (!string.IsNullOrWhiteSpace(cellText))
                    {
                        cellText =
                            ScrudLocalizationHelper.GetResourceString(this.GetResourceClassName(), cellText);
                        e.Row.Cells[i].Text = cellText;
                    }
                }
            }
        }
    }
}