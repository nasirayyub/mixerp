using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.CRM.Setup
{
    public partial class LeadSources : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "lead_source_id";

                scrud.TableSchema = "crm";
                scrud.Table = "lead_sources";
                scrud.ViewSchema = "crm";
                scrud.View = "lead_sources";

                scrud.Text = Titles.LeadSources;
                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}