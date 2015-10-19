using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MixERP.Net.i18n.Resources;
using MixERP.Net.WebControls.ScrudFactory.Helpers;

namespace MixERP.Net.WebControls.ScrudFactory.Controls.ListControls
{
    internal static class ScrudRadioButtonList
    {
        internal static void AddRadioButtonList(HtmlTable htmlTable, string resourceClassName, string columnName, string label, string description,
            bool isNullable, string keys, string values, string selectedValue, string errorCssClass, bool disabled)
        {
            if (htmlTable == null)
            {
                return;
            }

            using (RadioButtonList radioButtonList = GetRadioButtonList(columnName + "_radiobuttonlist", keys, values, selectedValue))
            {
                if (!string.IsNullOrWhiteSpace(description))
                {
                    radioButtonList.CssClass += " activating element";
                    radioButtonList.Attributes.Add("data-content", description);
                }

                if (string.IsNullOrWhiteSpace(label))
                {
                    label = ScrudLocalizationHelper.GetResourceString(resourceClassName, columnName);
                }

                radioButtonList.Enabled = !disabled;

                if (!isNullable)
                {
                    using (
                        RequiredFieldValidator required = ScrudFactoryHelper.GetRequiredFieldValidator(radioButtonList,
                            errorCssClass))
                    {
                        ScrudFactoryHelper.AddRow(htmlTable, label + Labels.RequiredFieldIndicator, radioButtonList,
                            required);
                        return;
                    }
                }

                ScrudFactoryHelper.AddRow(htmlTable, label, radioButtonList);
            }
        }

        private static RadioButtonList GetRadioButtonList(string id, string keys, string values, string selectedValues)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            using (RadioButtonList list = new RadioButtonList())
            {
                list.ID = id;
                list.ClientIDMode = ClientIDMode.Static;
                list.RepeatDirection = RepeatDirection.Horizontal;

                Helper.AddListItems(list, keys, values, selectedValues);

                return list;
            }
        }
    }
}