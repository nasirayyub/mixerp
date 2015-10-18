using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice
{
    public partial class Entities : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "entity_id";
                scrud.TableSchema = "core";
                scrud.Table = "entities";
                scrud.ViewSchema = "core";
                scrud.View = "entity_scrud_view";
                scrud.Text = Titles.Entities;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}