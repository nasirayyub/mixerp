using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class UOM : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "unit_id";

                scrud.TableSchema = "core";
                scrud.Table = "units";
                scrud.ViewSchema = "core";
                scrud.View = "unit_scrud_view";

                scrud.Text = Titles.UnitsOfMeasure;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}