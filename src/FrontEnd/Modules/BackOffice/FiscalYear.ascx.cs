using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class FiscalYear : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get { return AccessLevel.AdminOnly; }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "fiscal_year_code";

                scrud.TableSchema = "core";
                scrud.Table = "fiscal_year";
                scrud.ViewSchema = "core";
                scrud.View = "fiscal_year_scrud_view";

                scrud.Text = Titles.FiscalYear;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}