// ReSharper disable All
using MixERP.Net.Framework;
using MixERP.Net.Entities.Office;
using MixERP.Net.Schemas.Office.Data;
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
namespace MixERP.Net.Api.Office
{
    /// <summary>
    /// Provides a direct HTTP access to execute the function AddOffice.
    /// </summary>
    [RoutePrefix("api/v1.5/office/procedures/add-office")]
    public class AddOfficeController : ApiController
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

        private AddOfficeProcedure procedure;
        public class Annotation
        {
            public string OfficeCode { get; set; }
            public string OfficeName { get; set; }
            public string NickName { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string CurrencyCode { get; set; }
            public string CurrencySymbol { get; set; }
            public string CurrencyName { get; set; }
            public string HundredthName { get; set; }
            public string FiscalYearCode { get; set; }
            public string FiscalYearName { get; set; }
            public DateTime StartsFrom { get; set; }
            public DateTime EndsOn { get; set; }
            public bool SalesTaxIsVat { get; set; }
            public bool HasStateSalesTax { get; set; }
            public bool HasCountySalesTax { get; set; }
            public int QuotationValidDays { get; set; }
            public decimal IncomeTaxRate { get; set; }
            public int WeekStartDay { get; set; }
            public DateTime TransactionStartDate { get; set; }
            public bool IsPerpetual { get; set; }
            public string InvValuationMethod { get; set; }
            public string LogoFile { get; set; }
            public string AdminName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public AddOfficeController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();
            this.procedure = new AddOfficeProcedure
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }
        /// <summary>
        ///     Creates meta information of "add office" annotation.
        /// </summary>
        /// <returns>Returns the "add office" annotation meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("annotation")]
        [Route("~/api/office/procedures/add-office/annotation")]
        public EntityView GetAnnotation()
        {
            return new EntityView
            {
                Columns = new List<EntityColumn>()
                                {
                                        new EntityColumn { ColumnName = "_office_code",  PropertyName = "OfficeCode",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_office_name",  PropertyName = "OfficeName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_nick_name",  PropertyName = "NickName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_registration_date",  PropertyName = "RegistrationDate",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_currency_code",  PropertyName = "CurrencyCode",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_currency_symbol",  PropertyName = "CurrencySymbol",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_currency_name",  PropertyName = "CurrencyName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_hundredth_name",  PropertyName = "HundredthName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_fiscal_year_code",  PropertyName = "FiscalYearCode",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_fiscal_year_name",  PropertyName = "FiscalYearName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_starts_from",  PropertyName = "StartsFrom",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_ends_on",  PropertyName = "EndsOn",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_sales_tax_is_vat",  PropertyName = "SalesTaxIsVat",  DataType = "bool",  DbDataType = "boolean",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_has_state_sales_tax",  PropertyName = "HasStateSalesTax",  DataType = "bool",  DbDataType = "boolean",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_has_county_sales_tax",  PropertyName = "HasCountySalesTax",  DataType = "bool",  DbDataType = "boolean",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_quotation_valid_days",  PropertyName = "QuotationValidDays",  DataType = "int",  DbDataType = "integer",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_income_tax_rate",  PropertyName = "IncomeTaxRate",  DataType = "decimal",  DbDataType = "numeric",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_week_start_day",  PropertyName = "WeekStartDay",  DataType = "int",  DbDataType = "integer",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_transaction_start_date",  PropertyName = "TransactionStartDate",  DataType = "DateTime",  DbDataType = "date",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_is_perpetual",  PropertyName = "IsPerpetual",  DataType = "bool",  DbDataType = "boolean",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_inv_valuation_method",  PropertyName = "InvValuationMethod",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_logo_file",  PropertyName = "LogoFile",  DataType = "string",  DbDataType = "text",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_admin_name",  PropertyName = "AdminName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_user_name",  PropertyName = "UserName",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 },
                                        new EntityColumn { ColumnName = "_password",  PropertyName = "Password",  DataType = "string",  DbDataType = "character varying",  IsNullable = false,  IsPrimaryKey = false,  IsSerial = false,  Value = "",  MaxLength = 0 }
                                }
            };
        }

        /// <summary>
        ///     Creates meta information of "add office" entity.
        /// </summary>
        /// <returns>Returns the "add office" meta information to perform CRUD operation.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("meta")]
        [Route("~/api/office/procedures/add-office/meta")]
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
        [Route("~/api/office/procedures/add-office/execute")]
        public void Execute([FromBody] Annotation annotation)
        {
            try
            {
                this.procedure.OfficeCode = annotation.OfficeCode;
                this.procedure.OfficeName = annotation.OfficeName;
                this.procedure.NickName = annotation.NickName;
                this.procedure.RegistrationDate = annotation.RegistrationDate;
                this.procedure.CurrencyCode = annotation.CurrencyCode;
                this.procedure.CurrencySymbol = annotation.CurrencySymbol;
                this.procedure.CurrencyName = annotation.CurrencyName;
                this.procedure.HundredthName = annotation.HundredthName;
                this.procedure.FiscalYearCode = annotation.FiscalYearCode;
                this.procedure.FiscalYearName = annotation.FiscalYearName;
                this.procedure.StartsFrom = annotation.StartsFrom;
                this.procedure.EndsOn = annotation.EndsOn;
                this.procedure.SalesTaxIsVat = annotation.SalesTaxIsVat;
                this.procedure.HasStateSalesTax = annotation.HasStateSalesTax;
                this.procedure.HasCountySalesTax = annotation.HasCountySalesTax;
                this.procedure.QuotationValidDays = annotation.QuotationValidDays;
                this.procedure.IncomeTaxRate = annotation.IncomeTaxRate;
                this.procedure.WeekStartDay = annotation.WeekStartDay;
                this.procedure.TransactionStartDate = annotation.TransactionStartDate;
                this.procedure.IsPerpetual = annotation.IsPerpetual;
                this.procedure.InvValuationMethod = annotation.InvValuationMethod;
                this.procedure.LogoFile = annotation.LogoFile;
                this.procedure.AdminName = annotation.AdminName;
                this.procedure.UserName = annotation.UserName;
                this.procedure.Password = annotation.Password;


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