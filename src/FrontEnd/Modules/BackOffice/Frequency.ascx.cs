using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class Frequency : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "frequency_setup_id";

                scrud.TableSchema = "core";
                scrud.Table = "frequency_setups";
                scrud.ViewSchema = "core";
                scrud.View = "frequency_setup_scrud_view";
                scrud.PageSize = 12;

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                scrud.Text = Titles.Frequencies;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.frequencies.frequency_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "FrequencyDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "core.fiscal_year.fiscal_year_code",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "FiscalYearDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.frequencies.frequency_id", "core.frequency_selector_view");
            ScrudHelper.AddDisplayView(displayViews, "core.fiscal_year.fiscal_year_code", "core.fiscal_year_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}