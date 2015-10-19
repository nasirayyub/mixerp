using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private Label descriptionLabel;
        private Label titleLabel;

        private static void AddRuler(Panel p)
        {
            if (p == null)
            {
                return;
            }

            using (HtmlGenericControl ruler = new HtmlGenericControl("div")) //"hr"
            {
                ruler.Attributes.Add("class", "ui divider");
                p.Controls.Add(ruler);
            }
        }

        private void AddDescription(Panel p)
        {
            this.descriptionLabel = new Label();
            this.descriptionLabel.Attributes.Add("style", "display:block;");
            p.Controls.Add(this.descriptionLabel);
        }

        private void AddTitle(Panel p)
        {
            if (p == null)
            {
                return;
            }

            using (HtmlGenericControl titleDiv = new HtmlGenericControl())
            {
                titleDiv.TagName = "div";
                this.titleLabel = new Label();
                this.titleLabel.ID = "TitleLabel";
                titleDiv.Attributes.Add("class", this.GetTitleLabelCssClass());

                titleDiv.Controls.Add(this.titleLabel);
                p.Controls.Add(titleDiv);
            }
        }

        private void LoadDescription()
        {
            if (!string.IsNullOrWhiteSpace(this.Description))
            {
                this.descriptionLabel.CssClass = this.GetDescriptionCssClass();
                this.descriptionLabel.Text = this.Description;
            }
        }

        private void LoadTitle()
        {
            this.titleLabel.Text = this.Text;
            this.Page.Title = this.Text;
        }
    }
}