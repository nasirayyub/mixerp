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
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Employment Taxes.
    /// </summary>
    [RoutePrefix("api/v1.5/hrm/employment-tax")]
    public class EmploymentTaxController : ApiController
    {
        /// <summary>
        ///     The EmploymentTax data context.
        /// </summary>
        private readonly MixERP.Net.Core.Modules.HRM.Data.EmploymentTax EmploymentTaxContext;

        public EmploymentTaxController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();

            this.EmploymentTaxContext = new MixERP.Net.Core.Modules.HRM.Data.EmploymentTax
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
        ///     Creates meta information of "employment tax" entity.
        /// </summary>
        /// <returns>Returns the "employment tax" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/hrm/employment-tax/meta")]
        public EntityView GetEntityView()
        {
            return new EntityView
            {
                PrimaryKey = "employment_tax_id",
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "employment_tax_id",  PropertyName = "EmploymentTaxId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = true,  IsSerial = true,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "employment_tax_code",  PropertyName = "EmploymentTaxCode",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 12 },
                                        new EntityColumn { ColumnName = "employment_tax_name",  PropertyName = "EmploymentTaxName",  DataType = "string",  DbDataType = "varchar",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 128 },
                                        new EntityColumn { ColumnName = "tax_authority_id",  PropertyName = "TaxAuthorityId",  DataType = "int",  DbDataType = "int4",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_user_id",  PropertyName = "AuditUserId",  DataType = "int",  DbDataType = "int4",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "audit_ts",  PropertyName = "AuditTs",  DataType = "DateTime",  DbDataType = "timestamptz",  IsNullable = true,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Counts the number of employment taxes.
        /// </summary>
        /// <returns>Returns the count of the employment taxes.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/hrm/employment-tax/count")]
        public long Count()
        {
            try
            {
                return this.EmploymentTaxContext.Count();
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
        ///     Returns collection of employment tax for export.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("export")]
        [Route("~/api/hrm/employment-tax/export")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> Get()
        {
            try
            {
                return this.EmploymentTaxContext.Get();
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
        ///     Returns an instance of employment tax.
        /// </summary>
        /// <param name="employmentTaxId">Enter EmploymentTaxId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{employmentTaxId}")]
        [Route("~/api/hrm/employment-tax/{employmentTaxId}")]
        public MixERP.Net.Entities.HRM.EmploymentTax Get(int employmentTaxId)
        {
            try
            {
                return this.EmploymentTaxContext.Get(employmentTaxId);
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
        [Route("~/api/hrm/employment-tax/get")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> Get([FromUri] int[] employmentTaxIds)
        {
            try
            {
                return this.EmploymentTaxContext.Get(employmentTaxIds);
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
        ///     Creates a paginated collection containing 10 employment taxes on each page, sorted by the property EmploymentTaxId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/hrm/employment-tax")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> GetPagedResult()
        {
            try
            {
                return this.EmploymentTaxContext.GetPagedResult();
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
        ///     Creates a paginated collection containing 10 employment taxes on each page, sorted by the property EmploymentTaxId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/hrm/employment-tax/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.EmploymentTaxContext.GetPagedResult(pageNumber);
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
        ///     Counts the number of employment taxes using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered employment taxes.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/hrm/employment-tax/count-where")]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.EmploymentTaxContext.CountWhere(f);
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
        ///     Creates a filtered and paginated collection containing 10 employment taxes on each page, sorted by the property EmploymentTaxId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/hrm/employment-tax/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.EmploymentTaxContext.GetWhere(pageNumber, f);
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
        ///     Counts the number of employment taxes using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered employment taxes.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/hrm/employment-tax/count-filtered/{filterName}")]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.EmploymentTaxContext.CountFiltered(filterName);
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
        ///     Creates a filtered and paginated collection containing 10 employment taxes on each page, sorted by the property EmploymentTaxId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/hrm/employment-tax/get-filtered/{pageNumber}/{filterName}")]
        public IEnumerable<MixERP.Net.Entities.HRM.EmploymentTax> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.EmploymentTaxContext.GetFiltered(pageNumber, filterName);
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
        ///     Displayfield is a lightweight key/value collection of employment taxes.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of employment taxes.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/hrm/employment-tax/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.EmploymentTaxContext.GetDisplayFields();
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
        ///     A custom field is a user defined field for employment taxes.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of employment taxes.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/hrm/employment-tax/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.EmploymentTaxContext.GetCustomFields(null);
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
        ///     A custom field is a user defined field for employment taxes.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of employment taxes.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields/{resourceId}")]
        [Route("~/api/hrm/employment-tax/custom-fields/{resourceId}")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.EmploymentTaxContext.GetCustomFields(resourceId);
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
        ///     Adds or edits your instance of EmploymentTax class.
        /// </summary>
        /// <param name="employmentTax">Your instance of employment taxes class to add or edit.</param>
        [AcceptVerbs("PUT")]
        [Route("add-or-edit")]
        [Route("~/api/hrm/employment-tax/add-or-edit")]
        public object AddOrEdit([FromBody]Newtonsoft.Json.Linq.JArray form)
        {
            MixERP.Net.Entities.HRM.EmploymentTax employmentTax = form[0].ToObject<MixERP.Net.Entities.HRM.EmploymentTax>(JsonHelper.GetJsonSerializer());
            List<EntityParser.CustomField> customFields = form[1].ToObject<List<EntityParser.CustomField>>(JsonHelper.GetJsonSerializer());

            if (employmentTax == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                return this.EmploymentTaxContext.AddOrEdit(employmentTax, customFields);
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
        ///     Adds your instance of EmploymentTax class.
        /// </summary>
        /// <param name="employmentTax">Your instance of employment taxes class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{employmentTax}")]
        [Route("~/api/hrm/employment-tax/add/{employmentTax}")]
        public void Add(MixERP.Net.Entities.HRM.EmploymentTax employmentTax)
        {
            if (employmentTax == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.EmploymentTaxContext.Add(employmentTax);
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
        ///     Edits existing record with your instance of EmploymentTax class.
        /// </summary>
        /// <param name="employmentTax">Your instance of EmploymentTax class to edit.</param>
        /// <param name="employmentTaxId">Enter the value for EmploymentTaxId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{employmentTaxId}")]
        [Route("~/api/hrm/employment-tax/edit/{employmentTaxId}")]
        public void Edit(int employmentTaxId, [FromBody] MixERP.Net.Entities.HRM.EmploymentTax employmentTax)
        {
            if (employmentTax == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.EmploymentTaxContext.Update(employmentTax, employmentTaxId);
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

        private List<MixERP.Net.Entities.HRM.EmploymentTax> ParseCollection(dynamic collection)
        {
            return JsonConvert.DeserializeObject<List<MixERP.Net.Entities.HRM.EmploymentTax>>(collection.ToString(), JsonHelper.GetJsonSerializerSettings());
        }

        /// <summary>
        ///     Adds or edits multiple instances of EmploymentTax class.
        /// </summary>
        /// <param name="collection">Your collection of EmploymentTax class to bulk import.</param>
        /// <returns>Returns list of imported employmentTaxIds.</returns>
        /// <exception cref="MixERPException">Thrown when your any EmploymentTax class in the collection is invalid or malformed.</exception>
        [AcceptVerbs("PUT")]
        [Route("bulk-import")]
        [Route("~/api/hrm/employment-tax/bulk-import")]
        public List<object> BulkImport([FromBody]dynamic collection)
        {
            List<MixERP.Net.Entities.HRM.EmploymentTax> employmentTaxCollection = this.ParseCollection(collection);

            if (employmentTaxCollection == null || employmentTaxCollection.Count.Equals(0))
            {
                return null;
            }

            try
            {
                return this.EmploymentTaxContext.BulkImport(employmentTaxCollection);
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
        ///     Deletes an existing instance of EmploymentTax class via EmploymentTaxId.
        /// </summary>
        /// <param name="employmentTaxId">Enter the value for EmploymentTaxId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{employmentTaxId}")]
        [Route("~/api/hrm/employment-tax/delete/{employmentTaxId}")]
        public void Delete(int employmentTaxId)
        {
            try
            {
                this.EmploymentTaxContext.Delete(employmentTaxId);
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