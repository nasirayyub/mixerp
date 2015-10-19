using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class StoreTypes : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "store_type_id";

                scrud.TableSchema = "office";
                scrud.Table = "store_types";
                scrud.ViewSchema = "office";
                scrud.View = "store_type_scrud_view";

                scrud.Text = Titles.StoreTypes;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}