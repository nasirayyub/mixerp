// ReSharper disable All
using MixERP.Net.Framework;
using MixERP.Net.Entities.Audit;
using MixERP.Net.Schemas.Audit.Data;
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
namespace MixERP.Net.Api.Audit
{
    /// <summary>
    /// Provides a direct HTTP access to execute the function AddColumn.
    /// </summary>
    [RoutePrefix("api/v1.5/public/procedures/add-column")]
    public class AddColumnController : ApiController
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

        private AddColumnProcedure procedure;
        public class Annotation
        {
            public regclass TableName { get; set; }
            public string ColumnName { get; set; }
            public regtype DataType { get; set; }
            public string Default { get; set; }
            public string Comment { get; set; }
        }

        public AddColumnController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();
            this.procedure = new AddColumnProcedure
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }
        /// <summary>
        ///     Creates meta information of "add column" annotation.
        /// </summary>
        /// <returns>Returns the "add column" annotation meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("annotation")]
        [Route("~/api/public/procedures/add-column/annotation")]
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
        ///     Creates meta information of "add column" entity.
        /// </summary>
        /// <returns>Returns the "add column" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/public/procedures/add-column/meta")]
        public EntityView GetEntityView()
        {
            return new EntityView
            {
                Columns = new List<EntityColumn>()
                {
                }
            };
        }

        [AcceptVerbs("POST")]
        [Route("execute")]
        [Route("~/api/public/procedures/add-column/execute")]
        public void Execute([FromBody] Annotation annotation)
        {
            try
            {
                this.procedure.TableName = annotation.TableName;
                this.procedure.ColumnName = annotation.ColumnName;
                this.procedure.DataType = annotation.DataType;
                this.procedure.Default = annotation.Default;
                this.procedure.Comment = annotation.Comment;


                this.procedure.Execute();
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