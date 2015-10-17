/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MixERP.Net.Common.Helpers;

namespace MixERP.Net.WebControls.StockTransactionFactory
{
    public partial class StockTransactionForm
    {
        private void CreateGrid(Control container)
        {
            using (HtmlGenericControl div = new HtmlGenericControl("div"))
            {
                div.Attributes.Add("style", "width:100%;overflow:auto;");
                div.Attributes.Add("class", "ui form vpad16");

                using (Table productGridView = new Table())
                {
                    productGridView.ID = "ProductGridView";
                    productGridView.CssClass = "ui table";
                    productGridView.Style.Value = ConfigurationHelper.GetStockTransactionFactoryParameter("GridStyle");

                    CreateHeaderRow(productGridView);
                    this.CreateFooterRow(productGridView);

                    div.Controls.Add(productGridView);
                }

                container.Controls.Add(div);
            }
        }
    }
}