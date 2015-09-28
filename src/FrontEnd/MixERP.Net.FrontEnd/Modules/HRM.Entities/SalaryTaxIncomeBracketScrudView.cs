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
    [TableName("hrm.salary_tax_income_bracket_scrud_view")]
    [ExplicitColumns]
    public sealed class SalaryTaxIncomeBracketScrudView : PetaPocoDB.Record<SalaryTaxIncomeBracketScrudView>, IPoco
    {
        [Column("salary_tax_income_bracket_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? SalaryTaxIncomeBracketId { get; set; }

        [Column("salary_tax")]
        [ColumnDbType("text", 0, true, "")]
        public string SalaryTax { get; set; }

        [Column("salary_from")]
        [ColumnDbType("money_strict", 0, true, "")]
        public decimal? SalaryFrom { get; set; }

        [Column("salary_to")]
        [ColumnDbType("money_strict", 0, true, "")]
        public decimal? SalaryTo { get; set; }

        [Column("income_tax_rate")]
        [ColumnDbType("text", 0, true, "")]
        public string IncomeTaxRate { get; set; }
    }
}