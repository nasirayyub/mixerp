// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using PetaPoco;

namespace MixERP.Net.Schemas.Core.Data
{
    public interface IItemVariantDetailScrudViewRepository
    {
        /// <summary>
        /// Performs count on IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <returns>Returns the number of IItemVariantDetailScrudViewRepository.</returns>
        long Count();

        /// <summary>
        /// Return all instances of the "ItemVariantDetailScrudView" class from IItemVariantDetailScrudViewRepository. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "ItemVariantDetailScrudView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetailScrudView> Get();

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for IItemVariantDetailScrudViewRepository.</returns>
        IEnumerable<DisplayField> GetDisplayFields();

        /// <summary>
        /// Produces a paginated result of 10 items from IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <returns>Returns the first page of collection of "ItemVariantDetailScrudView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetailScrudView> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 items from IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "ItemVariantDetailScrudView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetailScrudView> GetPaginatedResult(long pageNumber);

        List<EntityParser.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "ItemVariantDetailScrudView" class using the filter.</returns>
        long CountWhere(List<EntityParser.Filter> filters);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filters from IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "ItemVariantDetailScrudView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetailScrudView> GetWhere(long pageNumber, List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "ItemVariantDetailScrudView" class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filter name from IItemVariantDetailScrudViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "ItemVariantDetailScrudView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetailScrudView> GetFiltered(long pageNumber, string filterName);


    }
}