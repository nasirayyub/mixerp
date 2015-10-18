using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.CRM.Setup
{
    public partial class LeadStatuses : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "lead_status_id";

                scrud.TableSchema = "crm";
                scrud.Table = "lead_statuses";
                scrud.ViewSchema = "crm";
                scrud.View = "lead_statuses";
                scrud.Text = Titles.LeadStatuses;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}