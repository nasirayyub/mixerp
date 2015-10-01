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
    [TableName("hrm.salary_deduction_scrud_view")]
    [ExplicitColumns]
    public sealed class SalaryDeductionScrudView : PetaPocoDB.Record<SalaryDeductionScrudView>, IPoco
    {
        [Column("salary_deduction_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? SalaryDeductionId { get; set; }

        [Column("employee")]
        [ColumnDbType("text", 0, true, "")]
        public string Employee { get; set; }

        [Column("photo")]
        [ColumnDbType("image", 0, true, "")]
        public string Photo { get; set; }

        [Column("deduction_setup")]
        [ColumnDbType("text", 0, true, "")]
        public string DeductionSetup { get; set; }

        [Column("currency_code")]
        [ColumnDbType("varchar", 12, true, "")]
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
    }
}