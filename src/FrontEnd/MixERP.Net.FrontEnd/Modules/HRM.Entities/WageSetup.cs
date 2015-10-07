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
    [PrimaryKey("wage_setup_id", autoIncrement = true)]
    [TableName("hrm.wage_setup")]
    [ExplicitColumns]
    public sealed class WageSetup : PetaPocoDB.Record<WageSetup>, IPoco
    {
        [Column("wage_setup_id")]
        [ColumnDbType("int4", 0, false, "nextval('hrm.wage_setup_wage_setup_id_seq'::regclass)")]
        public int WageSetupId { get; set; }

        [Column("wage_setup_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string WageSetupCode { get; set; }

        [Column("wage_setup_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string WageSetupName { get; set; }

        [Column("currency_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string CurrencyCode { get; set; }

        [Column("max_week_hours")]
        [ColumnDbType("int4", 0, false, "0")]
        public int MaxWeekHours { get; set; }

        [Column("hourly_rate")]
        [ColumnDbType("money_strict", 0, false, "")]
        public decimal HourlyRate { get; set; }

        [Column("overtime_applicable")]
        [ColumnDbType("bool", 0, false, "true")]
        public bool OvertimeApplicable { get; set; }

        [Column("overtime_hourly_rate")]
        [ColumnDbType("money_strict2", 0, false, "")]
        public decimal OvertimeHourlyRate { get; set; }

        [Column("expense_account_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long ExpenseAccountId { get; set; }

        [Column("description")]
        [ColumnDbType("text", 0, true, "")]
        public string Description { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}