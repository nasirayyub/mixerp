// ReSharper disable All
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.Api.Framework;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetaPoco;

namespace MixERP.Net.Api.HRM
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Employment Tax Details.
    /// </summary>
    [RoutePrefix("api/v1.5/hrm/employment-tax-detail")]
    public class EmploymentTaxDetailController : ApiController
    {
        /// <summary>
        ///     The EmploymentTaxDetail data context.
        /// </summary>
        private readonly MixERP.Net.Core.Modules.HRM.Data.EmploymentTaxDetail EmploymentTaxDetailContext;

        public EmploymentTaxDetailController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();

            this.EmploymentTaxDetailContext = new MixERP.Net.Core.Modules.HRM.Data.EmploymentTaxDetail
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Creates meta information of "employment tax detail" entity.
        /// </summary>
        /// <returns>Returns the "employment tax detail" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/hrm/employment-tax-detail/meta")]
        public EntityView GetEntityView()
        {
            return new EntityView
            {
                PrimaryKey = "employment_tax_detail_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "employment_tax_detail_id",  PropertyName = "EmploymentTaxDetailId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "employment_tax_id",  PropertyName = "EmploymentTaxId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "employment_tax_detail_code",  PropertyName = "EmploymentTaxDetailCode",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 12 },
                                        new EntityColumn { ColumnName = "employment_tax_detail_name",  PropertyName = "EmploymentTaxDetailName",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "employee_tax_rate",  PropertyName = "EmployeeTaxRate",  DataType = "decimal",  DbDataType = "decimal_strict",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "employer_tax_rate",  PropertyName = "EmployerTaxRate",  DataType = "decimal",  DbDataType = "decimal_strict",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of employment tax details.
        /// </summary>
        /// <returns>Returns the count of the employment tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/hrm/employment-tax-detail/count")]
        public long Count()
        {
            try
            {
                return this.EmploymentTaxDetailContext.Count();
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

        /// <summary>
        ///     Returns collection of employment tax detail for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/hrm/employment-tax-detail/export")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> Get()
        {
            try
            {
                return this.EmploymentTaxDetailContext.Get();
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

        /// <summary>
        ///     Returns an instance of employment tax detail.
        /// </summary>
        /// <param name="employmentTaxDetailId">Enter EmploymentTaxDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{employmentTaxDetailId}")]
        [Route("~/api/hrm/employment-tax-detail/{employmentTaxDetailId}")]
        public MixERP.Net.Entities.HRM.EmploymentTaxDetail Get(int employmentTaxDetailId)
        {
            try
            {
                return this.EmploymentTaxDetailContext.Get(employmentTaxDetailId);
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

        [AcceptVerbs("GET", "HEAD")]
        [Route("get")]
        [Route("~/api/hrm/employment-tax-detail/get")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> Get([FromUri] int[] employmentTaxDetailIds)
        {
            try
            {
                return this.EmploymentTaxDetailContext.Get(employmentTaxDetailIds);
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

        /// <summary>
        ///     Creates a paginated collection containing 10 employment tax details on each page, sorted by the property EmploymentTaxDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/hrm/employment-tax-detail")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> GetPagedResult()
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetPagedResult();
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

        /// <summary>
        ///     Creates a paginated collection containing 10 employment tax details on each page, sorted by the property EmploymentTaxDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/hrm/employment-tax-detail/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetPagedResult(pageNumber);
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

        /// <summary>
        ///     Counts the number of employment tax details using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered employment tax details.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/hrm/employment-tax-detail/count-where")]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.EmploymentTaxDetailContext.CountWhere(f);
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

        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 employment tax details on each page, sorted by the property EmploymentTaxDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/hrm/employment-tax-detail/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.EmploymentTaxDetailContext.GetWhere(pageNumber, f);
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

        /// <summary>
        ///     Counts the number of employment tax details using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered employment tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/hrm/employment-tax-detail/count-filtered/{filterName}")]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.EmploymentTaxDetailContext.CountFiltered(filterName);
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

        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 employment tax details on each page, sorted by the property EmploymentTaxDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/hrm/employment-tax-detail/get-filtered/{pageNumber}/{filterName}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTaxDetail> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetFiltered(pageNumber, filterName);
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

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of employment tax details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of employment tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/hrm/employment-tax-detail/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetDisplayFields();
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

        /// <summary>
        ///     A custom field is a user defined field for employment tax details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of employment tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/hrm/employment-tax-detail/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetCustomFields(null);
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

        /// <summary>
        ///     A custom field is a user defined field for employment tax details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of employment tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/hrm/employment-tax-detail/custom-fields/{resourceId}")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.EmploymentTaxDetailContext.GetCustomFields(resourceId);
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

        /// <summary>
        ///     Adds or edits your instance of EmploymentTaxDetail class.
        /// </summary>
        /// <param name="employmentTaxDetail">Your instance of employment tax details class to add or edit.</param>
        [AcceptVerbs("PUT")]
        [Route("add-or-edit")]
        [Route("~/api/hrm/employment-tax-detail/add-or-edit")]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            MixERP.Net.Entities.HRM.EmploymentTaxDetail employmentTaxDetail = form[0].ToObject<MixERP.Net.Entities.HRM.EmploymentTaxDetail>(JsonHelper.GetJsonSerializer());
            List<EntityParser.CustomField> customFields = form[1].ToObject<List<EntityParser.CustomField>>(JsonHelper.GetJsonSerializer());

            if (employmentTaxDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.EmploymentTaxDetailContext.AddOrEdit(employmentTaxDetail, customFields);
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

        /// <summary>
        ///     Adds your instance of EmploymentTaxDetail class.
        /// </summary>
        /// <param name="employmentTaxDetail">Your instance of employment tax details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{employmentTaxDetail}")]
        [Route("~/api/hrm/employment-tax-detail/add/{employmentTaxDetail}")]
        public void Add(MixERP.Net.Entities.HRM.EmploymentTaxDetail employmentTaxDetail)
        {
            if (employmentTaxDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.EmploymentTaxDetailContext.Add(employmentTaxDetail);
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

        /// <summary>
        ///     Edits existing record with your instance of EmploymentTaxDetail class.
        /// </summary>
        /// <param name="employmentTaxDetail">Your instance of EmploymentTaxDetail class to edit.</param>
        /// <param name="employmentTaxDetailId">Enter the value for EmploymentTaxDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{employmentTaxDetailId}")]
        [Route("~/api/hrm/employment-tax-detail/edit/{employmentTaxDetailId}")]
        public void Edit(int employmentTaxDetailId, [FromBody] MixERP.Net.Entities.HRM.EmploymentTaxDetail employmentTaxDetail)
        {
            if (employmentTaxDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.EmploymentTaxDetailContext.Update(employmentTaxDetail, employmentTaxDetailId);
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

        private List<MixERP.Net.Entities.HRM.EmploymentTaxDetail> ParseCollection(dynamic collection)
        {
            return JsonConvert.DeserializeObject<List<MixERP.Net.Entities.HRM.EmploymentTaxDetail>>(collection.ToString(), JsonHelper.GetJsonSerializerSettings());
        }

        /// <summary>
        ///     Adds or edits multiple instances of EmploymentTaxDetail class.
        /// </summary>
        /// <param name="collection">Your collection of EmploymentTaxDetail class to bulk import.</param>
        /// <returns>Returns list of imported employmentTaxDetailIds.</returns>
        /// <exception cref="MixERPException">Thrown when your any EmploymentTaxDetail class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("PUT")]
        [Route("bulk-import")]
        [Route("~/api/hrm/employment-tax-detail/bulk-import")]
        public List<object> BulkImport([FromBody]dynamic collection)
        {
            List<MixERP.Net.Entities.HRM.EmploymentTaxDetail> employmentTaxDetailCollection = this.ParseCollection(collection);

            if (employmentTaxDetailCollection == null || employmentTaxDetailCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.EmploymentTaxDetailContext.BulkImport(employmentTaxDetailCollection);
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

        /// <summary>
        ///     Deletes an existing instance of EmploymentTaxDetail class via EmploymentTaxDetailId.
        /// </summary>
        /// <param name="employmentTaxDetailId">Enter the value for EmploymentTaxDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{employmentTaxDetailId}")]
        [Route("~/api/hrm/employment-tax-detail/delete/{employmentTaxDetailId}")]
        public void Delete(int employmentTaxDetailId)
        {
            try
            {
                this.EmploymentTaxDetailContext.Delete(employmentTaxDetailId);
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