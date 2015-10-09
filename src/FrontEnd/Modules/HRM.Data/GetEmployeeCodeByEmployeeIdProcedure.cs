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
    /// Prepares, validates, and executes the function "hrm.get_employee_code_by_employee_id(_employee_id integer)" on the database.
    /// </summary>
    public class GetEmployeeCodeByEmployeeIdProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "hrm";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_employee_code_by_employee_id";
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
        /// Maps to "_employee_id" argument of the function "hrm.get_employee_code_by_employee_id".
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.get_employee_code_by_employee_id(_employee_id integer)" on the database.
        /// </summary>
        public GetEmployeeCodeByEmployeeIdProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.get_employee_code_by_employee_id(_employee_id integer)" on the database.
        /// </summary>
        /// <param name="employeeId">Enter argument value for "_employee_id" parameter of the function "hrm.get_employee_code_by_employee_id".</param>
        public GetEmployeeCodeByEmployeeIdProcedure(int employeeId)
        {
            this.EmployeeId = employeeId;
        }
        /// <summary>
        /// Prepares and executes the function "hrm.get_employee_code_by_employee_id".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public string Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetEmployeeCodeByEmployeeIdProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM hrm.get_employee_code_by_employee_id(@EmployeeId);";

            query = query.ReplaceWholeWord("@EmployeeId", "@0::integer");


            List<object> parameters = new List<object>();
            parameters.Add(this.EmployeeId);

            return Factory.Scalar<string>(this._Catalog, query, parameters.ToArray());
        }


    }
}