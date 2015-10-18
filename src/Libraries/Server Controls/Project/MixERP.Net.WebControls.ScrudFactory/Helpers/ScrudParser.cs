using MixERP.Net.Common;
using System.Linq;

namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    internal class ScrudParser
    {
        public static object ParseValue(string value, string dataType)
        {
            if (ScrudTypes.Strings.Contains(dataType))
            {
                return Conversion.TryCastString(value);
            }

            if (ScrudTypes.Shorts.Contains(dataType))
            {
                return Conversion.TryCastShort(value);
            }

            if (ScrudTypes.Integers.Contains(dataType))
            {
                return Conversion.TryCastInteger(value);
            }

            if (ScrudTypes.Longs.Contains(dataType))
            {
                return Conversion.TryCastLong(value);
            }

            if (ScrudTypes.Decimals.Contains(dataType))
            {
                return Conversion.TryCastDecimal(value);
            }

            if (ScrudTypes.Doubles.Contains(dataType))
            {
                return Conversion.TryCastDouble(value);
            }

            if (ScrudTypes.Singles.Contains(dataType))
            {
                return Conversion.TryCastSingle(value);
            }

            if (ScrudTypes.Dates.Contains(dataType))
            {
                return Conversion.TryCastDate(value);
            }

            if (ScrudTypes.Bools.Contains(dataType))
            {
                return Conversion.TryCastBoolean(value);
            }


            return null;
        }
    }
}