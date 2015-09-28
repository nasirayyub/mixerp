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
    [PrimaryKey("employment_tax_detail_id", autoIncrement = true)]
    [TableName("hrm.employment_tax_details")]
    [ExplicitColumns]
    public sealed class EmploymentTaxDetail : PetaPocoDB.Record<EmploymentTaxDetail>, IPoco
    {
        [Column("employment_tax_detail_id")]
        [ColumnDbType("int4", 0, false, "nextval('hrm.employment_tax_details_employment_tax_detail_id_seq'::regclass)")]
        public int EmploymentTaxDetailId { get; set; }

        [Column("employment_tax_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int EmploymentTaxId { get; set; }

        [Column("employment_tax_detail_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string EmploymentTaxDetailCode { get; set; }

        [Column("employment_tax_detail_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string EmploymentTaxDetailName { get; set; }

        [Column("employee_tax_rate")]
        [ColumnDbType("decimal_strict", 0, false, "")]
        public decimal EmployeeTaxRate { get; set; }

        [Column("employer_tax_rate")]
        [ColumnDbType("decimal_strict", 0, false, "")]
        public decimal EmployerTaxRate { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}