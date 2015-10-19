using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class Counters : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "counter_id";

                scrud.TableSchema = "office";
                scrud.Table = "counters";
                scrud.ViewSchema = "office";
                scrud.View = "counter_scrud_view";

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();

                scrud.Text = Titles.Counters;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "office.cash_repositories.cash_repository_id", DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "CashRepositoryDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "office.stores.store_id", DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "StoreDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "office.cash_repositories.cash_repository_id", "office.cash_repository_scrud_view");
            ScrudHelper.AddDisplayView(displayViews, "office.stores.store_id", "office.store_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}