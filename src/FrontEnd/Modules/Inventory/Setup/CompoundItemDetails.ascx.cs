using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.Inventory.Setup
{
    public partial class CompoundItemDetails : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "compound_item_detail_id";

                scrud.TableSchema = "core";
                scrud.Table = "compound_item_details";
                scrud.ViewSchema = "core";
                scrud.View = "compound_item_detail_scrud_view";

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                scrud.Text = Titles.CompoundItemDetails;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.compound_items.compound_item_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "CompoundItemDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.items.item_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "ItemDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.units.unit_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "UnitDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.compound_items.compound_item_id",
                "core.compound_item_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.items.item_id", "core.item_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.units.unit_id", "core.unit_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}