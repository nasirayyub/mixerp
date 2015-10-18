using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class CompoundItems : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "compound_item_id";

                scrud.TableSchema = "core";
                scrud.Table = "compound_items";
                scrud.ViewSchema = "core";
                scrud.View = "compound_item_scrud_view";

                scrud.Text = Titles.CompoundItems;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}