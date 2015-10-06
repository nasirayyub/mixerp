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
    /// Prepares, validates, and executes the function "hrm.get_salary_tax_id_by_salary_tax_code(_salary_tax_code character varying)" on the database.
    /// </summary>
    public class GetSalaryTaxIdBySalaryTaxCodeProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "hrm";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_salary_tax_id_by_salary_tax_code";
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
        /// Maps to "_salary_tax_code" argument of the function "hrm.get_salary_tax_id_by_salary_tax_code".
        /// </summary>
        public string SalaryTaxCode { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.get_salary_tax_id_by_salary_tax_code(_salary_tax_code character varying)" on the database.
        /// </summary>
        public GetSalaryTaxIdBySalaryTaxCodeProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "hrm.get_salary_tax_id_by_salary_tax_code(_salary_tax_code character varying)" on the database.
        /// </summary>
        /// <param name="salaryTaxCode">Enter argument value for "_salary_tax_code" parameter of the function "hrm.get_salary_tax_id_by_salary_tax_code".</param>
        public GetSalaryTaxIdBySalaryTaxCodeProcedure(string salaryTaxCode)
        {
            this.SalaryTaxCode = salaryTaxCode;
        }
        /// <summary>
        /// Prepares and executes the function "hrm.get_salary_tax_id_by_salary_tax_code".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public int Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetSalaryTaxIdBySalaryTaxCodeProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM hrm.get_salary_tax_id_by_salary_tax_code(@SalaryTaxCode);";

            query = query.ReplaceWholeWord("@SalaryTaxCode", "@0::character varying");


            List<object> parameters = new List<object>();
            parameters.Add(this.SalaryTaxCode);

            return Factory.Scalar<int>(this._Catalog, query, parameters.ToArray());
        }


    }
}