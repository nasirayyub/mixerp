using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.CRM.Setup
{
    public partial class OpportunityStages : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "opportunity_stage_id";

                scrud.TableSchema = "crm";
                scrud.Table = "opportunity_stages";
                scrud.ViewSchema = "crm";
                scrud.View = "opportunity_stages";

                scrud.Text = Titles.OpportunityStages;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}