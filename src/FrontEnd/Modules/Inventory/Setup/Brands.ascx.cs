using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class Brands : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "brand_id";

                scrud.TableSchema = "core";
                scrud.Table = "brands";
                scrud.ViewSchema = "core";
                scrud.View = "brand_scrud_view";

                scrud.Text = Titles.Brands;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}