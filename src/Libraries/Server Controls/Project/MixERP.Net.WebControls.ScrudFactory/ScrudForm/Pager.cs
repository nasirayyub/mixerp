using MixERP.Net.Common;
using MixERP.Net.WebControls.ScrudFactory.Controls;
using MixERP.Net.WebControls.ScrudFactory.Data;
using System.Web.UI;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void CreatePager(Control container)
        {
            int pageSize = this.GetPageSize();
            int totalRecords = FormHelper.GetTotalRecords(this.Catalog, this.ViewSchema, this.View);

            int currentPage = Conversion.TryCastInteger(this.Page.Request.QueryString["page"]);
            if (currentPage.Equals(0))
            {
                currentPage = 1;
            }

            string cssClass = this.GetPagerCssClass();
            string activeCssClass = this.GetPagerCurrentPageCssClass();
            string itemCssClass = this.GetPagerPageButtonCssClass();

            if (totalRecords == 0 || pageSize > totalRecords)
            {
                return;
            }

            const int blockCount = 10; //This can be parameterized.

            this.CreatePager(container, pageSize, totalRecords, currentPage, blockCount, cssClass, activeCssClass, itemCssClass);
        }

        private void CreatePager(Control container, int pageSize, int totalRecords, int currentPage, int blockCount, string cssClass, string activeCssClass, string itemCssClass)
        {
            string queryString = this.Page.Request.QueryString.ToString();
           
            ScrudPager scrudPager = new ScrudPager
             {
                 TotalRecords = totalRecords,
                 CurrentPage = currentPage,
                 PageSize = pageSize,
                 BlockCount = blockCount,
                 CssClass = cssClass,
                 ActiveCssClass = activeCssClass,
                 ItemCssClass = itemCssClass,
                 CurrentPageUrl = this.Page.Request.Url.AbsolutePath,
                 QueryString=queryString
             };

            container.Controls.Add(scrudPager.GetPager());
        }
    }
}