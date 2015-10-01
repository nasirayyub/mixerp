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
    [PrimaryKey("salary_deduction_id", autoIncrement = true)]
    [TableName("hrm.salary_deductions")]
    [ExplicitColumns]
    public sealed class SalaryDeduction : PetaPocoDB.Record<SalaryDeduction>, IPoco
    {
        [Column("salary_deduction_id")]
        [ColumnDbType("int8", 0, false, "nextval('hrm.salary_deductions_salary_deduction_id_seq'::regclass)")]
        public long SalaryDeductionId { get; set; }

        [Column("employee_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int EmployeeId { get; set; }

        [Column("deduction_setup_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int DeductionSetupId { get; set; }

        [Column("currency_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string CurrencyCode { get; set; }

        [Column("amount")]
        [ColumnDbType("money_strict", 0, true, "")]
        public decimal? Amount { get; set; }

        [Column("begins_from")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? BeginsFrom { get; set; }

        [Column("ends_on")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? EndsOn { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}