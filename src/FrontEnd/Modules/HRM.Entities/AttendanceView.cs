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
    [TableName("hrm.attendance_view")]
    [ExplicitColumns]
    public sealed class AttendanceView : PetaPocoDB.Record<AttendanceView>, IPoco
    {
        [Column("attendance_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? AttendanceId { get; set; }

        [Column("office_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? OfficeId { get; set; }

        [Column("office")]
        [ColumnDbType("text", 0, true, "")]
        public string Office { get; set; }

        [Column("employee_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? EmployeeId { get; set; }

        [Column("employee")]
        [ColumnDbType("text", 0, true, "")]
        public string Employee { get; set; }

        [Column("photo")]
        [ColumnDbType("image", 0, true, "")]
        public string Photo { get; set; }

        [Column("attendance_date")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? AttendanceDate { get; set; }

        [Column("was_present")]
        [ColumnDbType("bool", 0, true, "")]
        public bool? WasPresent { get; set; }

        [Column("check_in_time")]
        [ColumnDbType("time", 0, true, "")]
        public DateTime? CheckInTime { get; set; }

        [Column("check_out_time")]
        [ColumnDbType("time", 0, true, "")]
        public DateTime? CheckOutTime { get; set; }

        [Column("overtime_hours")]
        [ColumnDbType("numeric", 0, true, "")]
        public decimal? OvertimeHours { get; set; }

        [Column("was_absent")]
        [ColumnDbType("bool", 0, true, "")]
        public bool? WasAbsent { get; set; }

        [Column("reason_for_absentism")]
        [ColumnDbType("text", 0, true, "")]
        public string ReasonForAbsentism { get; set; }
    }
}