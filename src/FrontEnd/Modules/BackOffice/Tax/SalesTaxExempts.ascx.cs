using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class SalesTaxExempts : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "sales_tax_exempt_id";
                scrud.TableSchema = "core";
                scrud.Table = "sales_tax_exempts";
                scrud.ViewSchema = "core";
                scrud.View = "sales_tax_exempt_scrud_view";
                scrud.Text = Titles.SalesTaxExempts;

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.tax_master.tax_master_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "TaxMasterDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.tax_exempt_types.tax_exempt_type_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "TaxExemptTypeDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.sales_taxes.sales_tax_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "SalesTaxDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "office.stores.store_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "StoreDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.tax_master.tax_master_id", "core.tax_master_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.tax_exempt_types.tax_exempt_type_id",
                "core.tax_exempt_type_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.sales_taxes.sales_tax_id", "core.sales_tax_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "office.stores.store_id", "office.store_scrud_view");

            return string.Join(",", displayViews);
        }
    }
}