using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIeCloudvalley.Models;

namespace WebAPIeCloudvalley.Business
{
    public class ValuesHandler
    {
        private static Logger Logger = LogManager.GetLogger("WebAPIeCloudvalley");

        ///<summary>
        /// GetlineItemUnblendedCostById
        /// </summary>
        /// <param name="usageaccountid">usageaccountid</param>
        /// <param name="pageCnt">查詢的頁數</param>
        /// <param name="pageRows">每頁筆數</param>
        /// <returns> ApiResponseMessage  ProductViewModel List</returns>
        public static ApiResponseMessage<List<ProductViewModel>> GetProductTotalUsageAmountById(string usageaccountid, int pageCnt, int pageRows)
        {
            Logger.Debug("Start GetlineItemUnblendedCostById");
            ApiResponseMessage<List<ProductViewModel>> response = new ApiResponseMessage<List<ProductViewModel>>();
            List<ProductViewModel> result = response.Data;
            try
            {
                response = GetProductGroupTotalUsageAmount(usageaccountid, pageCnt, pageRows);
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Errors.Add(new System.Web.Http.HttpError(ex, false));
            }
            Logger.Debug("End GetlineItemUnblendedCostById");
            return response;
        }

        /// <summary>
        /// GetProductGroupDateTotalUsageAmountById
        /// </summary>
        /// <param name="usageaccountid">usageaccountid</param>
        /// <returns> ApiResponseMessage  ProductViewModel List</returns>
        public static ApiResponseMessage<List<ProductViewModel>> GetProductGroupDateTotalUsageAmountById(string usageaccountid, int pageCnt, int pageRows)
        {
            Logger.Debug("Start GetProductGroupDateTotalUsageAmountById");
            ApiResponseMessage<List<ProductViewModel>> response = new ApiResponseMessage<List<ProductViewModel>>();
            List<ProductViewModel> result = response.Data;
            try
            {
                response = GetProductGroupDateTotalUsageAmount(usageaccountid, pageCnt, pageRows);
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Errors.Add(new System.Web.Http.HttpError(ex, false));
            }
            Logger.Debug("End GetProductGroupDateTotalUsageAmountById");
            return response;
        }

        /// <summary>
        /// GetProductGroupTotalUsageAmount
        /// </summary>
        /// <param name="pageCnt">查詢的頁數</param>
        /// <param name="pageRows">每頁筆數</param>
        /// <returns> ApiResponseMessageProductViewModel List</returns>
        private static ApiResponseMessage<List<ProductViewModel>> GetProductGroupTotalUsageAmount(string usageaccountid,int pageCnt, int pageRows )
        {
            var result = new ApiResponseMessage<List<ProductViewModel>>();
            result.Data = GetProducts().Join(GetLineItems(), p => p.Id, l => l.ProductId, (p, l) => new { p, l })
                .Where(x => x.l.UsageAccountId == usageaccountid)
                .GroupBy(g => g.p.ProductName)
                .Select(s => new ProductViewModel
                {
                    ProductName = s.Key,
                    TotalUsageAmount = s.Sum(t => t.l.UnblendedCost)
                }).Skip((pageCnt - 1) * pageRows).Take(pageRows).ToList();

            return result;
        }

        /// <summary>
        /// GetProductGroupDateTotalUsageAmount
        /// </summary>
        /// <returns> ApiResponseMessage ProductViewModel List</returns>
        private static ApiResponseMessage<List<ProductViewModel>> GetProductGroupDateTotalUsageAmount(string usageaccountid, int pageCnt, int pageRows)
        {
            var result = new ApiResponseMessage<List<ProductViewModel>>();
            result.Data = GetProducts().Join(GetLineItems(), p => p.Id, l => l.ProductId, (p, l) => new { p, l })
                .Where(x => x.l.UsageAccountId == usageaccountid)
                .GroupBy(g => new { g.p.ProductName,g.l.UsageEndDate })
                .Select(s => new ProductViewModel
                {
                    ProductName = s.Key.ProductName,
                    UsageStartDate = s.Key.UsageEndDate,
                    TotalUsageAmount = s.Sum(t => t.l.UnblendedCost)
                }).Skip((pageCnt - 1) * pageRows).Take(pageRows).ToList();

            return result;
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <returns>Product List</returns>
        private static List<Product> GetProducts()
        {
            var result = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "AWS Backup",
                },

                new Product
                {
                    Id = 2,
                    ProductName = "AWS Config",
                },

                new Product
                {
                    Id = 3,
                    ProductName = "Amazon Registrar",
                },

                new Product
                {
                    Id = 4,
                    ProductName = "Amazon Elastic File System",
                },

                new Product
                {
                    Id = 5,
                    ProductName = "Amazon Elastic Compute Cloud",
                }
            };

            return result;
        }

        /// <summary>
        /// GetLineItems
        /// </summary>
        /// <returns>lineItem List</returns>
        private static List<lineItem> GetLineItems()
        {
            var result = new List<lineItem>
            {
                new lineItem
                {
                    ProductId = 1,
                    UsageAccountId = "order1",
                    UnblendedRate = 8,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 1,
                    UsageAccountId = "order1",
                    UnblendedRate = 9,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 2,
                    UsageAccountId = "order1",
                    UnblendedRate = 8,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 2,
                    UsageAccountId = "order1",
                    UnblendedRate = 6,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 2,
                    UsageAccountId = "order2",
                    UnblendedRate = 5,
                    UsageAmount = 100,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 2,
                    UsageAccountId = "order2",
                    UnblendedRate = 4,
                    UsageAmount = 20,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/12"),
                },
                new lineItem
                {
                    ProductId = 3,
                    UsageAccountId = "order2",
                    UnblendedRate = 10,
                    UsageAmount = 20,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/12"),
                },
                new lineItem
                {
                    ProductId = 3,
                    UsageAccountId = "order2",
                    UnblendedRate = 20,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 5,
                    UsageAccountId = "order6",
                    UnblendedRate = 80,
                    UsageAmount = 10,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                },
                new lineItem
                {
                    ProductId = 5,
                    UsageAccountId = "order7",
                    UnblendedRate = 8,
                    UsageAmount = 6,
                    UsageStartDate = Convert.ToDateTime("2021/1/1"),
                    UsageEndDate =  Convert.ToDateTime("2021/3/1"),
                }

            };

            return result;
        }
    }
}