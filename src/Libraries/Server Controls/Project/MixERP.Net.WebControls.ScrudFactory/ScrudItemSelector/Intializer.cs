using MixERP.Net.WebControls.ScrudFactory.Data;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudItemSelector
    {
        private void Initialize(string catalog)
        {
            this.LoadParmeters(catalog);
            this.LoadGridView(catalog);
        }

        private void LoadGridView(string catalog)
        {
            if (string.IsNullOrWhiteSpace(this.GetSchema()))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(this.GetView()))
            {
                return;
            }

            using (var table = FormHelper.GetTable(catalog, this.GetSchema(), this.GetView(), "", "", 10, "1"))
            {
                this.searchGridView.DataSource = table;
                this.searchGridView.DataBind();
            }
        }

        private void LoadParmeters(string catalog)
        {
            if (string.IsNullOrWhiteSpace(this.GetSchema()))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(this.GetView()))
            {
                return;
            }

            this.filterSelect.DataSource = TableHelper.GetColumns(catalog, this.GetSchema(), this.GetView());
            this.filterSelect.DataBind();
        }
    }
}