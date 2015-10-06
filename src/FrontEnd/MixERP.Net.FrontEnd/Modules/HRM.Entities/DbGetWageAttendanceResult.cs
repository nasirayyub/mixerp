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
    [FunctionName("hrm.get_wage_attendance")]
    [ExplicitColumns]
    public sealed class DbGetWageAttendanceResult : PetaPocoDB.Record<DbGetWageAttendanceResult>, IPoco
    {
        [Column("employee_id")]
        [ColumnDbType("integer", 0, false, "")]
        public int EmployeeId { get; set; }

        [Column("employee")]
        [ColumnDbType("text", 0, false, "")]
        public string Employee { get; set; }

        [Column("regular_hours")]
        [ColumnDbType("integer", 0, false, "")]
        public int RegularHours { get; set; }

        [Column("regular_pay")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal RegularPay { get; set; }

        [Column("overtime_pay")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal OvertimePay { get; set; }

        [Column("photo")]
        [ColumnDbType("text", 0, false, "")]
        public string Photo { get; set; }

        [Column("attendance_date")]
        [ColumnDbType("date", 0, false, "")]
        public DateTime AttendanceDate { get; set; }

        [Column("hours_worked")]
        [ColumnDbType("numeric", 0, false, "")]
        public decimal HoursWorked { get; set; }
    }
}