// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using PetaPoco;

namespace MixERP.Net.Schemas.Core.Data
{
    public interface IItemVariantDetailRepository
    {
        /// <summary>
        /// Counts the number of ItemVariantDetail in IItemVariantDetailRepository.
        /// </summary>
        /// <returns>Returns the count of IItemVariantDetailRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of ItemVariantDetail. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ItemVariantDetail.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetAll();

        /// <summary>
        /// Returns all instances of ItemVariantDetail to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ItemVariantDetail.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the ItemVariantDetail against itemVariantDetailId. 
        /// </summary>
        /// <param name="itemVariantDetailId">The column "item_variant_detail_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of ItemVariantDetail.</returns>
        MixERP.Net.Entities.Core.ItemVariantDetail Get(int itemVariantDetailId);

        /// <summary>
        /// Returns multiple instances of the ItemVariantDetail against itemVariantDetailIds. 
        /// </summary>
        /// <param name="itemVariantDetailIds">Array of column "item_variant_detail_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of ItemVariantDetail.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> Get(int[] itemVariantDetailIds);

        /// <summary>
        /// Custom fields are user defined form elements for IItemVariantDetailRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for ItemVariantDetail.</returns>
        IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding ItemVariantDetail.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for ItemVariantDetail.</returns>
        IEnumerable<DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of ItemVariantDetail class to IItemVariantDetailRepository.
        /// </summary>
        /// <param name="itemVariantDetail">The instance of ItemVariantDetail class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic itemVariantDetail, List<EntityParser.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of ItemVariantDetail class to IItemVariantDetailRepository.
        /// </summary>
        /// <param name="itemVariantDetail">The instance of ItemVariantDetail class to insert.</param>
        object Add(dynamic itemVariantDetail);

        /// <summary>
        /// Inserts or updates multiple instances of ItemVariantDetail class to IItemVariantDetailRepository.;
        /// </summary>
        /// <param name="itemVariantDetails">List of ItemVariantDetail class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> itemVariantDetails);


        /// <summary>
        /// Updates IItemVariantDetailRepository with an instance of ItemVariantDetail class against the primary key value.
        /// </summary>
        /// <param name="itemVariantDetail">The instance of ItemVariantDetail class to update.</param>
        /// <param name="itemVariantDetailId">The value of the column "item_variant_detail_id" which will be updated.</param>
        void Update(dynamic itemVariantDetail, int itemVariantDetailId);

        /// <summary>
        /// Deletes ItemVariantDetail from  IItemVariantDetailRepository against the primary key value.
        /// </summary>
        /// <param name="itemVariantDetailId">The value of the column "item_variant_detail_id" which will be deleted.</param>
        void Delete(int itemVariantDetailId);

        /// <summary>
        /// Produces a paginated result of 10 ItemVariantDetail classes.
        /// </summary>
        /// <returns>Returns the first page of collection of ItemVariantDetail class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 ItemVariantDetail classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of ItemVariantDetail class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetPaginatedResult(long pageNumber);

        List<EntityParser.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IItemVariantDetailRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of ItemVariantDetail class using the filter.</returns>
        long CountWhere(List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IItemVariantDetailRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of ItemVariantDetail class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetWhere(long pageNumber, List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IItemVariantDetailRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of ItemVariantDetail class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IItemVariantDetailRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of ItemVariantDetail class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetFiltered(long pageNumber, string filterName);



    }
}