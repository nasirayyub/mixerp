using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class TaxMaster : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "tax_master_id";
                scrud.TableSchema = "core";
                scrud.Table = "tax_master";
                scrud.ViewSchema = "core";
                scrud.View = "tax_master_scrud_view";
                scrud.Text = Titles.TaxMaster;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}