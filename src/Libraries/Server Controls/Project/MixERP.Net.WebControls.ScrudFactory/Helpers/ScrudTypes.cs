using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    public static class ScrudTypes
    {
        #region Static Fields

        public static readonly string[] Bools = { "boolean", "bool", "True/False" };
        public static readonly string[] Dates = {"date", "time", "Date"};
        public static readonly string[] Decimals = {"numeric", "money", "money_strict", "money_strict2", "decimal_strict", "decimal_strict2", "currency"};
        public static readonly string[] Doubles = {"double", "double precision", "float", "Number"};
        public static readonly string[] Files = {"bytea"};
        public static readonly string[] Integers = {"integer", "integer_strict", "integer_strict2"};
        public static readonly string[] Longs = {"bigint"};
        public static readonly string[] Shorts = {"smallint"};
        public static readonly string[] Singles = {"real"};
        public static readonly string[] Strings = {"national character varying", "character varying", "national character", "character", "char", "varchar", "nvarchar", "text", "Text", "Long Text", "color", "transaction_type", "image"};
        public static readonly string[] Timestamps = {"timestamp with time zone", "timestamp without time zone"};

        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")] //Resharper is wrong
        public static string[] TextBoxTypes = Decimals.Union(Doubles).Union(Integers).Union(Longs).Union(Shorts).Union(Singles).Union(Strings).Union(Dates).ToArray();

        #endregion
    }
}