// ReSharper disable All
using MixERP.Net.Framework;
using MixERP.Net.Entities.Config;
using MixERP.Net.Schemas.Config.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;
using MixERP.Net.EntityParser;
namespace MixERP.Net.Api.Config
{
    /// <summary>
    /// Provides a direct HTTP access to execute the function PocoGetTables.
    /// </summary>
    [RoutePrefix("api/v1.5/public/procedures/poco-get-tables")]
    public class PocoGetTablesController : ApiController
    {
        /// <summary>
        /// Login id of application user accessing this API.
        /// </summary>
        public long _LoginId { get; set; }

        /// <summary>
        /// User id of application user accessing this API.
        /// </summary>
        public int _UserId { get; set; }

        /// <summary>
        /// Currently logged in office id of application user accessing this API.
        /// </summary>
        public int _OfficeId { get; set; }

        /// <summary>
        /// The name of the database where queries are being executed on.
        /// </summary>
        public string _Catalog { get; set; }

        private PocoGetTablesProcedure procedure;
        public class Annotation
        {
            public string Schema { get; set; }
        }

        public PocoGetTablesController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();
            this.procedure = new PocoGetTablesProcedure
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }
        /// <summary>
        ///     Creates meta information of "poco get tables" annotation.
        /// </summary>
        /// <returns>Returns the "poco get tables" annotation meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("annotation")]
        [Route("~/api/public/procedures/poco-get-tables/annotation")]
        public EntityView GetAnnotation()
        {
            return new EntityView
            {
                Columns = new List<EntityColumn>()
                {
                }
            };
        }

        /// <summary>
        ///     Creates meta information of "poco get tables" entity.
        /// </summary>
        /// <returns>Returns the "poco get tables" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/public/procedures/poco-get-tables/meta")]
        public EntityView GetEntityView()
        {
            return new EntityView
            {
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "table_schema",  PropertyName = "TableSchema",  DataType = "string",  DbDataType = "name",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "table_name",  PropertyName = "TableName",  DataType = "string",  DbDataType = "name",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "table_type",  PropertyName = "TableType",  DataType = "string",  DbDataType = "text",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "has_duplicate",  PropertyName = "HasDuplicate",  DataType = "bool",  DbDataType = "boolean",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        [AcceptVerbs("POST")]
        [Route("execute")]
        [Route("~/api/public/procedures/poco-get-tables/execute")]
        public IEnumerable<DbPocoGetTablesResult> Execute([FromBody] Annotation annotation)
        {
            try
            {
                this.procedure.Schema = annotation.Schema;


                return this.procedure.Execute();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}