using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class SalesTaxExemptDetails : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "sales_tax_exempt_detail_id";
                scrud.TableSchema = "core";
                scrud.Table = "sales_tax_exempt_details";
                scrud.ViewSchema = "core";
                scrud.View = "sales_tax_exempt_detail_scrud_view";
                scrud.Text = Titles.SalesTaxExemptDetails;

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.sales_tax_exempts.sales_tax_exempt_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "SalesTaxExemptDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.entities.entity_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "EntityDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.industries.industry_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "IndustryDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.parties.party_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "PartyDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.party_types.party_type_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "PartyTypeDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.items.item_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "ItemDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.item_groups.item_group_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "ItemGroupDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.sales_tax_exempts.sales_tax_exempt_id",
                "core.sales_tax_exempt_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.entities.entity_id", "core.entity_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.industries.industry_id", "core.industry_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.party_types.party_type_id", "core.party_type_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.parties.party_id", "core.party_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.items.item_id", "core.item_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.item_groups.item_group_id", "core.item_group_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}