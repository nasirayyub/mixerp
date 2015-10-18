using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class Roles : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "role_id";

                scrud.TableSchema = "office";
                scrud.Table = "roles";
                scrud.ViewSchema = "office";
                scrud.View = "role_scrud_view";

                scrud.Text = Titles.Roles;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}