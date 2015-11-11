// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http;
using MixERP.Net.Schemas.Core.Data;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using CustomField = PetaPoco.CustomField;

namespace MixERP.Net.Api.Core.Fakes
{
    public class ItemVariantDetailRepository : IItemVariantDetailRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetAll()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public MixERP.Net.Entities.Core.ItemVariantDetail Get(int itemVariantDetailId)
        {
            return new MixERP.Net.Entities.Core.ItemVariantDetail();
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> Get([FromUri] int[] itemVariantDetailIds)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetPaginatedResult()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public long CountWhere(List<EntityParser.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new EntityParser.Filter(), 1).ToList();
        }

        public IEnumerable<MixERP.Net.Entities.Core.ItemVariantDetail> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Core.ItemVariantDetail(), 1);
        }

        public IEnumerable<DisplayField> GetDisplayFields()
        {
            return Enumerable.Repeat(new DisplayField(), 1);
        }

        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public object AddOrEdit(dynamic itemVariantDetail, List<EntityParser.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic itemVariantDetail, int itemVariantDetailId)
        {
            if (itemVariantDetailId > 0)
            {
                return;
            }

            throw new ArgumentException("itemVariantDetailId is null.");
        }

        public object Add(dynamic itemVariantDetail)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> itemVariantDetails)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int itemVariantDetailId)
        {
            if (itemVariantDetailId > 0)
            {
                return;
            }

            throw new ArgumentException("itemVariantDetailId is null.");
        }


    }
}