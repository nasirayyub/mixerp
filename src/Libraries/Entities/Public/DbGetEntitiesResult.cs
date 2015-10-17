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

namespace MixERP.Net.Entities.Public
{
    [PrimaryKey("", autoIncrement = false)]
    [FunctionName("public.get_entities")]
    [ExplicitColumns]
    public sealed class DbGetEntitiesResult : PetaPocoDB.Record<DbGetEntitiesResult>, IPoco
    {
        [Column("table_schema")]
        [ColumnDbType("name", 0, false, "")]
        public string TableSchema { get; set; }

        [Column("table_name")]
        [ColumnDbType("name", 0, false, "")]
        public string TableName { get; set; }

        [Column("table_type")]
        [ColumnDbType("text", 0, false, "")]
        public string TableType { get; set; }

        [Column("has_duplicate")]
        [ColumnDbType("boolean", 0, false, "")]
        public bool HasDuplicate { get; set; }
    }
}