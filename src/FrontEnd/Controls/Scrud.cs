using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.WebControls.ScrudFactory;

namespace MixERP.Net.FrontEnd.Controls
{
    public sealed class Scrud : ScrudForm
    {
        public Scrud()
        {
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.UserName = AppUsers.GetCurrent().View.UserName;
            this.OfficeCode = AppUsers.GetCurrent().View.OfficeName;
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();
        }
    }
}