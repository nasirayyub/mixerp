using PetaPoco;
using System;

namespace MixERP.Net.Entities.HRM
{
    [PrimaryKey("holiday_id", autoIncrement = true)]
    [TableName("hrm.holidays")]
    [ExplicitColumns]
    public sealed class Holiday : PetaPocoDB.Record<Holiday>, IPoco
    {
        [Column("holiday_id")]
        [ColumnDbType("int8", 0, false, "nextval('hrm.holidays_holiday_id_seq'::regclass)")]
        public long HolidayId { get; set; }

        [Column("office_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int OfficeId { get; set; }

        [Column("holiday_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string HolidayName { get; set; }

        [Column("occurs_on")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? OccursOn { get; set; }

        [Column("ends_on")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? EndsOn { get; set; }

        [Column("comment")]
        [ColumnDbType("text", 0, true, "")]
        public string Comment { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}