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
    [PrimaryKey("deduction_setup_id", autoIncrement = true)]
    [TableName("hrm.deduction_setups")]
    [ExplicitColumns]
    public sealed class DeductionSetup : PetaPocoDB.Record<DeductionSetup>, IPoco
    {
        [Column("deduction_setup_id")]
        [ColumnDbType("int4", 0, false, "nextval('hrm.deduction_setups_deduction_setup_id_seq'::regclass)")]
        public int DeductionSetupId { get; set; }

        [Column("deduction_setup_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string DeductionSetupCode { get; set; }

        [Column("deduction_setup_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string DeductionSetupName { get; set; }

        [Column("account_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int AccountId { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}