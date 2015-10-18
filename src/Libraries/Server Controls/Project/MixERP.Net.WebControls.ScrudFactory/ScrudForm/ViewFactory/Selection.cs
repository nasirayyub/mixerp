using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void ClearSelectedValue()
        {
            foreach (GridViewRow row in this.formGridView.Rows)
            {
                var r = (HtmlInputRadioButton)row.Controls[0].Controls[0];
                if (r.Checked)
                {
                    r.Checked = false;
                }
            }
        }

        private string GetSelectedValue()
        {
            foreach (GridViewRow row in this.formGridView.Rows)
            {
                var r = (HtmlInputRadioButton)row.Controls[0].Controls[0];
                if (r.Checked)
                {
                    return r.Value;
                }
            }

            return string.Empty;
        }
    }
}