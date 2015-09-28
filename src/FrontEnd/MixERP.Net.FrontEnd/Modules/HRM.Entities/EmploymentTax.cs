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
    [PrimaryKey("employment_tax_id", autoIncrement = true)]
    [TableName("hrm.employment_taxes")]
    [ExplicitColumns]
    public sealed class EmploymentTax : PetaPocoDB.Record<EmploymentTax>, IPoco
    {
        [Column("employment_tax_id")]
        [ColumnDbType("int4", 0, false, "nextval('hrm.employment_taxes_employment_tax_id_seq'::regclass)")]
        public int EmploymentTaxId { get; set; }

        [Column("employment_tax_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string EmploymentTaxCode { get; set; }

        [Column("employment_tax_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string EmploymentTaxName { get; set; }

        [Column("tax_authority_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int TaxAuthorityId { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}