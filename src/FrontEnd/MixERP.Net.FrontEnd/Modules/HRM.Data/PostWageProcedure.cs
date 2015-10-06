// ReSharper disable All
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
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.HRM;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Core.Modules.HRM.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "hrm.post_wage(_user_id integer, _as_of date, _employee_id integer, _statement_reference text, _regular_pay_rate numeric, _overtime_pay_rate numeric, _details hrm.wage_processing_details[])" on the database.
    /// </summary>
    public class PostWageProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "hrm";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "post_wage";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_user_id" argument of the function "hrm.post_wage".
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Maps to "_as_of" argument of the function "hrm.post_wage".
        /// </summary>
        public DateTime AsOf { get; set; }
        /// <summary>
        /// Maps to "_employee_id" argument of the function "hrm.post_wage".
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Maps to "_statement_reference" argument of the function "hrm.post_wage".
        /// </summary>
        public string StatementReference { get; set; }
        /// <summary>
        /// Maps to "_regular_pay_rate" argument of the function "hrm.post_wage".
        /// </summary>
        public decimal RegularPayRate { get; set; }
        /// <summary>
        /// Maps to "_overtime_pay_rate" argument of the function "hrm.post_wage".
        /// </summary>
        public decimal OvertimePayRate { get; set; }
        /// <summary>
        /// Maps to "_details" argument of the function "hrm.post_wage".
        /// </summary>
        public MixERP.Net.Entities.HRM.WageProcessingDetail[] Details { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.post_wage(_user_id integer, _as_of date, _employee_id integer, _statement_reference text, _regular_pay_rate numeric, _overtime_pay_rate numeric, _details hrm.wage_processing_details[])" on the database.
        /// </summary>
        public PostWageProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.post_wage(_user_id integer, _as_of date, _employee_id integer, _statement_reference text, _regular_pay_rate numeric, _overtime_pay_rate numeric, _details hrm.wage_processing_details[])" on the database.
        /// </summary>
        /// <param name="userId">Enter argument value for "_user_id" parameter of the function "hrm.post_wage".</param>
        /// <param name="asOf">Enter argument value for "_as_of" parameter of the function "hrm.post_wage".</param>
        /// <param name="employeeId">Enter argument value for "_employee_id" parameter of the function "hrm.post_wage".</param>
        /// <param name="statementReference">Enter argument value for "_statement_reference" parameter of the function "hrm.post_wage".</param>
        /// <param name="regularPayRate">Enter argument value for "_regular_pay_rate" parameter of the function "hrm.post_wage".</param>
        /// <param name="overtimePayRate">Enter argument value for "_overtime_pay_rate" parameter of the function "hrm.post_wage".</param>
        /// <param name="details">Enter argument value for "_details" parameter of the function "hrm.post_wage".</param>
        public PostWageProcedure(int userId, DateTime asOf, int employeeId, string statementReference, decimal regularPayRate, decimal overtimePayRate, MixERP.Net.Entities.HRM.WageProcessingDetail[] details)
        {
            this.UserId = userId;
            this.AsOf = asOf;
            this.EmployeeId = employeeId;
            this.StatementReference = statementReference;
            this.RegularPayRate = regularPayRate;
            this.OvertimePayRate = overtimePayRate;
            this.Details = details;
        }
        /// <summary>
        /// Prepares and executes the function "hrm.post_wage".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"PostWageProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM hrm.post_wage(@UserId, @AsOf, @EmployeeId, @StatementReference, @RegularPayRate, @OvertimePayRate, @Details);";

            query = query.ReplaceWholeWord("@UserId", "@0::integer");
            query = query.ReplaceWholeWord("@AsOf", "@1::date");
            query = query.ReplaceWholeWord("@EmployeeId", "@2::integer");
            query = query.ReplaceWholeWord("@StatementReference", "@3::text");
            query = query.ReplaceWholeWord("@RegularPayRate", "@4::numeric");
            query = query.ReplaceWholeWord("@OvertimePayRate", "@5::numeric");

            int detailsOffset = 6;
            query = query.ReplaceWholeWord("@Details", "ARRAY[" + this.SqlForDetails(this.Details, detailsOffset, 9) + "]");


            List<object> parameters = new List<object>();
            parameters.Add(this.UserId);
            parameters.Add(this.AsOf);
            parameters.Add(this.EmployeeId);
            parameters.Add(this.StatementReference);
            parameters.Add(this.RegularPayRate);
            parameters.Add(this.OvertimePayRate);
            parameters.AddRange(this.ParamsForDetails(this.Details));

            return Factory.Scalar<long>(this._Catalog, query, parameters.ToArray());
        }

        private string SqlForDetails(MixERP.Net.Entities.HRM.WageProcessingDetail[] details, int offset, int memberCount)
        {
            if (details == null)
            {
                return "NULL::hrm.wage_processing_details";
            }
            List<string> parameters = new List<string>();
            for (int i = 0; i < details.Count(); i++)
            {
                List<string> args = new List<string>();
                for (int j = 0; j < memberCount; j++)
                {
                    args.Add("@" + offset);
                    offset++;
                }

                string parameter = "ROW({0})::hrm.wage_processing_details";
                parameter = string.Format(System.Globalization.CultureInfo.InvariantCulture, parameter,
                    string.Join(",", args));
                parameters.Add(parameter);
            }
            return string.Join(",", parameters);
        }

        private List<object> ParamsForDetails(MixERP.Net.Entities.HRM.WageProcessingDetail[] details)
        {
            List<object> collection = new List<object>();

            if (details != null && details.Count() > 0)
            {
                foreach (MixERP.Net.Entities.HRM.WageProcessingDetail detail in details)
                {
                    collection.Add(detail.WageProcessingDetailId);
                    collection.Add(detail.WageProcessingId);
                    collection.Add(detail.ForDate);
                    collection.Add(detail.HoursWorked);
                    collection.Add(detail.LunchDeductionMinutes);
                    collection.Add(detail.AdjustmentMinutes);
                    collection.Add(detail.PayHours);
                    collection.Add(detail.AuditUserId);
                    collection.Add(detail.AuditTs);
                }
            }
            return collection;
        }
    }
}