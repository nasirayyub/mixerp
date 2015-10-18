using MixERP.Net.Common.Helpers;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

[assembly: WebResource("MixERP.Net.WebControls.ScrudFactory.ScrudItemSelector.js", "application/x-javascript", PerformSubstitution = true)]

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudItemSelector
    {
        [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        private void AddJavascript()
        {
            JSUtility.AddJSReference(this.Page, "MixERP.Net.WebControls.ScrudFactory.ScrudItemSelector.js", "ScrudItemSelector", typeof(ScrudItemSelector));
        }
    }
}