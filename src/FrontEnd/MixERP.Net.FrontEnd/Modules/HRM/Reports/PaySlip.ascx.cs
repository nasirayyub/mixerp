using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;

namespace MixERP.Net.Core.Modules.HRM.Reports
{
    public partial class PaySlip : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            Collection<KeyValuePair<string, object>> list = new Collection<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("@wage_processing_id", this.Page.Request["WageProcessingId"]));

            using (WebReport report = new WebReport())
            {
                report.AddParameterToCollection(list);
                report.AddParameterToCollection(list);
                report.AutoInitialize = true;
                report.Path = "~/Modules/HRM/Reports/Source/HRM.Payroll.PaySlip.xml";

                this.Controls.Add(report);
            }
        }
    }
}