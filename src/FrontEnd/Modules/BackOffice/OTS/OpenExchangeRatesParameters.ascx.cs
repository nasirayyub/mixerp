using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.OTS
{
    public partial class OpenExchangeRatesParameters : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "key";

                scrud.ExcludeEdit = "key";
                scrud.TableSchema = "config";
                scrud.DenyDelete = true;

                scrud.Table = "open_exchange_rates";
                scrud.ViewSchema = "config";
                scrud.View = "open_exchange_rate_scrud_view";

                scrud.Text = Titles.OpenExchangeRatesParameters;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}