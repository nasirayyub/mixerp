using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class SalesTaxTypes : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "sales_tax_type_id";

                scrud.TableSchema = "core";
                scrud.Table = "sales_tax_types";

                scrud.ViewSchema = "core";
                scrud.View = "sales_tax_type_scrud_view";

                scrud.Text = Titles.SalesTaxTypes;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}