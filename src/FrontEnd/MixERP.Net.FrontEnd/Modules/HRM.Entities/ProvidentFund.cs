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
    [PrimaryKey("provident_fund_id", autoIncrement = true)]
    [TableName("hrm.provident_funds")]
    [ExplicitColumns]
    public sealed class ProvidentFund : PetaPocoDB.Record<ProvidentFund>, IPoco
    {
        [Column("provident_fund_id")]
        [ColumnDbType("int4", 0, false, "nextval('hrm.provident_funds_provident_fund_id_seq'::regclass)")]
        public int ProvidentFundId { get; set; }

        [Column("provident_fund_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string ProvidentFundCode { get; set; }

        [Column("provident_fund_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string ProvidentFundName { get; set; }

        [Column("employee_contribution_rate")]
        [ColumnDbType("decimal_strict", 0, false, "")]
        public decimal EmployeeContributionRate { get; set; }

        [Column("employer_contribution_rate")]
        [ColumnDbType("decimal_strict", 0, false, "")]
        public decimal EmployerContributionRate { get; set; }

        [Column("fund_holding_account_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long FundHoldingAccountId { get; set; }

        [Column("provident_fund_expense_account_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long ProvidentFundExpenseAccountId { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}