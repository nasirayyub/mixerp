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
    [PrimaryKey("wage_processing_id", autoIncrement = true)]
    [TableName("hrm.wage_processing")]
    [ExplicitColumns]
    public sealed class WageProcessing : PetaPocoDB.Record<WageProcessing>, IPoco
    {
        [Column("wage_processing_id")]
        [ColumnDbType("int8", 0, false, "nextval('hrm.wage_processing_wage_processing_id_seq'::regclass)")]
        public long WageProcessingId { get; set; }

        [Column("employee_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int EmployeeId { get; set; }

        [Column("posted_till")]
        [ColumnDbType("date", 0, false, "")]
        public DateTime PostedTill { get; set; }

        [Column("regular_hours")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal RegularHours { get; set; }

        [Column("regular_pay_rate")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal RegularPayRate { get; set; }

        [Column("overtime_hours")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal OvertimeHours { get; set; }

        [Column("overtime_pay_rate")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal OvertimePayRate { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}