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
// ReSharper disable All
using PetaPoco;
using System;

namespace MixERP.Net.Entities.HRM
{
    [PrimaryKey("", autoIncrement = false)]
    [TableName("hrm.provident_fund_scrud_view")]
    [ExplicitColumns]
    public sealed class ProvidentFundScrudView : PetaPocoDB.Record<ProvidentFundScrudView>, IPoco
    {
        [Column("provident_fund_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? ProvidentFundId { get; set; }

        [Column("provident_fund_code")]
        [ColumnDbType("varchar", 12, true, "")]
        public string ProvidentFundCode { get; set; }

        [Column("provident_fund_name")]
        [ColumnDbType("varchar", 128, true, "")]
        public string ProvidentFundName { get; set; }

        [Column("employee_contribution_rate")]
        [ColumnDbType("text", 0, true, "")]
        public string EmployeeContributionRate { get; set; }

        [Column("employer_contribution_rate")]
        [ColumnDbType("text", 0, true, "")]
        public string EmployerContributionRate { get; set; }

        [Column("holiding_account")]
        [ColumnDbType("text", 0, true, "")]
        public string HolidingAccount { get; set; }

        [Column("expense_account")]
        [ColumnDbType("text", 0, true, "")]
        public string ExpenseAccount { get; set; }
    }
}