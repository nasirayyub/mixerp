using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    internal sealed class AjaxProgressTemplate : ITemplate
    {
        private readonly string cssClass;
        private readonly string spinnerImageCssClass;
        private readonly string spinnerImagePath;

        public AjaxProgressTemplate(string cssClass, string spinnerImageCssClass, string spinnerImagePath)
        {
            this.cssClass = cssClass;
            this.spinnerImageCssClass = spinnerImageCssClass;
            this.spinnerImagePath = spinnerImagePath;
        }

        public void InstantiateIn(Control container)
        {
            using (HtmlGenericControl ajaxProgressDiv = new HtmlGenericControl("div"))
            {
                ajaxProgressDiv.Attributes.Add("class", this.cssClass);

                using (HtmlGenericControl ajaxImage = new HtmlGenericControl("img"))
                {
                    ajaxImage.Attributes.Add("src", this.spinnerImagePath);
                    ajaxImage.Attributes.Add("class", this.spinnerImageCssClass);

                    ajaxProgressDiv.Controls.Add(ajaxImage);

                    container.Controls.Add(ajaxProgressDiv);
                }
            }
        }
    }
}