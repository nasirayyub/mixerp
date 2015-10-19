using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class ItemTypes : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "item_type_id";
                scrud.TableSchema = "core";
                scrud.Table = "item_types";
                scrud.ViewSchema = "core";
                scrud.View = "item_type_scrud_view";
                scrud.Text = Titles.ItemTypes;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}