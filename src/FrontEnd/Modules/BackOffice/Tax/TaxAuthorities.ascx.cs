using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class TaxAuthorities : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "tax_authority_id";
                scrud.TableSchema = "core";
                scrud.Table = "tax_authorities";
                scrud.ViewSchema = "core";
                scrud.View = "tax_authority_scrud_view";
                scrud.Text = Titles.TaxAuthorities;

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
            ScrudHelper.AddDisplayField(displayFields, "core.countries.country_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "CountryDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.states.state_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "StateDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.tax_master.tax_master_id", "core.tax_master_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.countries.country_id", "core.country_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "core.states.state_id", "core.state_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}