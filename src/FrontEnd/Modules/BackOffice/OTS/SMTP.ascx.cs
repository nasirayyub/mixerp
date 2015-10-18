using System;
using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;

namespace MixERP.Net.Core.Modules.BackOffice.OTS
{
    public partial class SMTP : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "smtp_id";

                scrud.ExcludeEdit = "key";
                scrud.TableSchema = "config";
                scrud.Table = "smtp";
                scrud.ViewSchema = "config";
                scrud.View = "smtp";

                scrud.Text = Titles.SMTPConfiguration;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}