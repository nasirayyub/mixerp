using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class Countries : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "country_id";
                scrud.TableSchema = "core";
                scrud.Table = "countries";
                scrud.ViewSchema = "core";
                scrud.View = "country_scrud_view";
                scrud.Text = Titles.Countries;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}