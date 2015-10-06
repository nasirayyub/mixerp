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
    [PrimaryKey("wage_processing_detail_id", autoIncrement = true)]
    [TableName("hrm.wage_processing_details")]
    [ExplicitColumns]
    public sealed class WageProcessingDetail : PetaPocoDB.Record<WageProcessingDetail>, IPoco
    {
        [Column("wage_processing_detail_id")]
        [ColumnDbType("int8", 0, false, "nextval('hrm.wage_processing_details_wage_processing_detail_id_seq'::regclass)")]
        public long WageProcessingDetailId { get; set; }

        [Column("wage_processing_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long WageProcessingId { get; set; }

        [Column("for_date")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? ForDate { get; set; }

        [Column("hours_worked")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal HoursWorked { get; set; }

        [Column("lunch_deduction_minutes")]
        [ColumnDbType("int4", 0, true, "")]
        public int? LunchDeductionMinutes { get; set; }

        [Column("adjustment_minutes")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AdjustmentMinutes { get; set; }

        [Column("pay_hours")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal PayHours { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}