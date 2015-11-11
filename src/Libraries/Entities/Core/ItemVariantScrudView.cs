// ReSharper disable All
using PetaPoco;
using System;

namespace MixERP.Net.Entities.Core
{
    [PrimaryKey("", autoIncrement = false)]
    [TableName("core.item_variant_scrud_view")]
    [ExplicitColumns]
    public sealed class ItemVariantScrudView : PetaPocoDB.Record<ItemVariantScrudView>, IPoco
    {
        [Column("item_variant_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? ItemVariantId { get; set; }

        [Column("photo")]
        [ColumnDbType("image", 0, true, "")]
        public string Photo { get; set; }

        [Column("item_variant_code")]
        [ColumnDbType("varchar", 12, true, "")]
        public string ItemVariantCode { get; set; }

        [Column("item_variant_name")]
        [ColumnDbType("varchar", 200, true, "")]
        public string ItemVariantName { get; set; }

        [Column("item")]
        [ColumnDbType("text", 0, true, "")]
        public string Item { get; set; }
    }
}