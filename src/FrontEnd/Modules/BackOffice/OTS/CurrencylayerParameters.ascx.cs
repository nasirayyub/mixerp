using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.OTS
{
    public partial class CurrencylayerParameters : MixERPUserControl
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

                scrud.Table = "currency_layer";
                scrud.ViewSchema = "config";
                scrud.View = "currency_layer_scrud_view";

                scrud.Text = Titles.CurrencylayerParameters;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}