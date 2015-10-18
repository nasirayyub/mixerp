using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class TaxExemptTypes : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "tax_exempt_type_id";
                scrud.TableSchema = "core";
                scrud.Table = "tax_exempt_types";
                scrud.ViewSchema = "core";
                scrud.View = "tax_exempt_type_scrud_view";
                scrud.Text = Titles.TaxExemptTypes;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}