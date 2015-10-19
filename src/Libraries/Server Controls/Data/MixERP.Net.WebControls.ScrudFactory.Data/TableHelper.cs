using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using MixERP.Net.DbFactory;
using MixERP.Net.Entities.Public;
using MixERP.Net.i18n;
using Npgsql;
using PetaPoco;

namespace MixERP.Net.WebControls.ScrudFactory.Data
{
    public static class TableHelper
    {
        public static DataTable GetTable(string catalog, string schema, string tableName, string exclusion)
        {
            string sql;

            if (!string.IsNullOrWhiteSpace(exclusion))
            {
                var exclusions = exclusion.Split(',');
                var paramNames =
                    exclusions.Select((s, i) => "@Parameter" + i.ToString(CultureManager.GetCurrent()).Trim())
                        .ToArray();
                var inClause = string.Join(",", paramNames);

                sql = string.Format(CultureManager.GetCurrent(),
                    @"SELECT * FROM scrud.mixerp_table_view WHERE table_schema=@Schema AND table_name=@TableName AND column_name NOT IN({0}) ORDER BY ordinal_position ASC;",
                    inClause);

                using (var command = new NpgsqlCommand(sql))
                {
                    command.Parameters.AddWithValue("@Schema", schema);
                    command.Parameters.AddWithValue("@TableName", tableName);

                    for (var i = 0; i < paramNames.Length; i++)
                    {
                        command.Parameters.AddWithValue(paramNames[i], exclusions[i].Trim());
                    }

                    return DbOperation.GetDataTable(catalog, command);
                }
            }

            sql =
                "select * from scrud.mixerp_table_view where table_schema=@Schema AND table_name=@TableName ORDER BY ordinal_position ASC;";

            using (var command = new NpgsqlCommand(sql))
            {
                command.Parameters.AddWithValue("@Schema", schema);
                command.Parameters.AddWithValue("@TableName", tableName);

                return DbOperation.GetDataTable(catalog, command);
            }
        }

        public static IEnumerable<DbPocoGetTableFunctionDefinitionResult> GetColumns(string catalog, string schema,
            string table)
        {
            const string sql = "SELECT * FROM public.poco_get_table_function_definition(@0::text, @1::text)";
            return Factory.Get<DbPocoGetTableFunctionDefinitionResult>(catalog, sql, schema, table);
        }
    }
}