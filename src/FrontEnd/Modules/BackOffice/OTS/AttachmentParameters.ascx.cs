using MixERP.Net.Framework.Controls;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.Core.Modules.BackOffice.OTS
{
    public partial class AttachmentParameters : MixERPUserControl
    {
        public override AccessLevel AccessLevel
        {
            get
            {
                return AccessLevel.AdminOnly;
            }
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (Scrud scrud = new Scrud())
            {
                scrud.KeyColumn = "key";

                scrud.ExcludeEdit = "key";
                scrud.TableSchema = "config";
                scrud.DenyDelete = true;

                scrud.Table = "attachment_factory";
                scrud.ViewSchema = "config";
                scrud.View = "attachment_factory_scrud_view";

                scrud.Text = Titles.AttachmentParameters;

                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}