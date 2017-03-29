using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MixERP.Net.Entities.Core;
using MixERP.Net.Entities.Transactions;
using PetaPoco;
using StockDetail = MixERP.Net.Entities.Transactions.Models.StockDetail;
using StockMaster = MixERP.Net.Entities.Transactions.Models.StockMaster;

namespace MixERP.Net.Core.Modules.Sales.Data.Transactions
{
    public static class Order
    {
        public static IEnumerable<DbListClosingStockResult> ListClosingStock(string catalog, int storeId, int[] itemIds)
        {
            var sql = new Sql("SELECT * FROM transactions.list_closing_stock(@0::integer)", storeId);
            sql.Where("item_id IN (@ItemIds)", new {ItemIds = itemIds});
            return Factory.Get<DbListClosingStockResult>(catalog, sql);
        }

        public static IEnumerable<dynamic> GetSupplyPlannerView(string catalog, long orderId)
        {
            const string sql = "SELECT * FROM transactions.supply_planner_view WHERE non_gl_stock_master_id=@0";
            return Factory.Get<dynamic>(catalog, sql, orderId);
        }

        public static long Add(string catalog, int officeId, int userId, long loginId, DateTime valueDate,
            string partyCode, int priceTypeId, Collection<StockDetail> details, string referenceNumber,
            string statementReference, Collection<long> transactionIdCollection, Collection<Attachment> attachments,
            bool nonTaxable, int salesPersonId, int shipperId, string shippingAddressCode, int storeId)
        {
            var stockMaster = new StockMaster();

            stockMaster.PartyCode = partyCode;
            stockMaster.PriceTypeId = priceTypeId;
            stockMaster.SalespersonId = salesPersonId;
            stockMaster.ShipperId = shipperId;
            stockMaster.ShippingAddressCode = shippingAddressCode;
            stockMaster.StoreId = storeId;

            var nonGlStockMasterId = NonGlStockTransaction.Add(catalog, "Sales.Order", valueDate, officeId, userId,
                loginId, referenceNumber, statementReference, stockMaster, details, transactionIdCollection, attachments,
                nonTaxable);
            return nonGlStockMasterId;
        }

        public static SalesOrderView GetSalesOrderView(string catalog, long tranId)
        {
            const string sql = "SELECT * FROM transactions.sales_order_view WHERE tran_id = @0;";
            return Factory.Get<SalesOrderView>(catalog, sql, tranId).FirstOrDefault();
        }
    }
}