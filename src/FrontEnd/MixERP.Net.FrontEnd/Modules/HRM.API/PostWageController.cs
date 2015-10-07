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
using MixERP.Net.Framework;
using MixERP.Net.Entities.HRM;
using MixERP.Net.Core.Modules.HRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;
namespace MixERP.Net.Api.HRM
{
    /// <summary>
    /// Provides a direct HTTP access to execute the function PostWage.
    /// </summary>
    [RoutePrefix("api/v1.5/hrm/procedures/post-wage")]
    public class PostWageController : ApiController
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

        private PostWageProcedure procedure;
        public class Annotation
        {
            public int UserId { get; set; }
            public int OfficeId { get; set; }
            public long LoginId { get; set; }
            public DateTime AsOf { get; set; }
            public int EmployeeId { get; set; }
            public string StatementReference { get; set; }
            public decimal RegularHours { get; set; }
            public decimal RegularPayRate { get; set; }
            public decimal OvertimeHours { get; set; }
            public decimal OvertimePayRate { get; set; }
            public MixERP.Net.Entities.HRM.WageProcessingDetail[] Details { get; set; }
        }

        public PostWageController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();
            this.procedure = new PostWageProcedure
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        [AcceptVerbs("POST")]
        [Route("execute")]
        [Route("~/api/hrm/procedures/post-wage/execute")]
        public long Execute([FromBody] Annotation annotation)
        {
            try
            {
                this.procedure.UserId = annotation.UserId;
                this.procedure.OfficeId = annotation.OfficeId;
                this.procedure.LoginId = annotation.LoginId;
                this.procedure.AsOf = annotation.AsOf;
                this.procedure.EmployeeId = annotation.EmployeeId;
                this.procedure.StatementReference = annotation.StatementReference;
                this.procedure.RegularHours = annotation.RegularHours;
                this.procedure.RegularPayRate = annotation.RegularPayRate;
                this.procedure.OvertimeHours = annotation.OvertimeHours;
                this.procedure.OvertimePayRate = annotation.OvertimePayRate;
                this.procedure.Details = annotation.Details;


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