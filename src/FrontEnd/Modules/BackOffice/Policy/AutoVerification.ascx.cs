using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.Common.Helpers;
using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Collections.Generic;

namespace MixERP.Net.Core.Modules.BackOffice.Policy
{
    public partial class AutoVerification : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                bool denyToNonAdmins = !AppUsers.GetCurrent().View.IsAdmin.ToBool();

                scrud.DenyAdd = denyToNonAdmins;
                scrud.DenyEdit = denyToNonAdmins;
                scrud.DenyDelete = denyToNonAdmins;

                scrud.ExcludeEdit = "user_id";

                scrud.KeyColumn = "policy_id";

                scrud.TableSchema = "policy";
                scrud.Table = "auto_verification_policy";
                scrud.ViewSchema = "policy";
                scrud.View = "auto_verification_policy_scrud_view";

                scrud.PageSize = 100;

                scrud.DisplayFields = GetDisplayFields();
                scrud.DisplayViews = GetDisplayViews();
                scrud.UseDisplayViewsAsParents = true;

                scrud.Text = Titles.AutoVerificationPolicy;


                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }

        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "office.users.user_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "UserDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "office.offices.office_id",
                DbConfig.GetDbParameter(AppUsers.GetCurrentUserDB(), "OfficeDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "office.users.user_id", "office.user_selector_view");
            ScrudHelper.AddDisplayView(displayViews, "office.offices.office_id", "office.office_scrud_view");
            return string.Join(",", displayViews);
        }
    }
}