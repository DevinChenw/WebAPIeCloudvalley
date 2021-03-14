using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIeCloudvalley.Business;
using WebAPIeCloudvalley.Models;

namespace WebAPIeCloudvalley.Controllers
{
    public class ValuesController : ApiController
    {
        private Logger Logger = LogManager.GetLogger("WebAPIeCloudvalley");

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// GetProductTotalUsageAmount
        /// </summary>
        /// <param name="pageCnt">查詢的頁數</param>
        /// <param name="pageRows">每頁筆數</param>
        /// <returns>ProductViewModel List</returns>
        [HttpGet]
        [Route("api/Order/GetProductTotalUsageAmount")]
        public ApiResponseMessage<List<ProductViewModel>> GetProductTotalUsageAmount(string usageaccountid, int pageCnt, int pageRows)
        {
            Logger.Info("Start API GetProductTotalUsageAmount List");
            if (usageaccountid == null)
            {
                var resp = new ApiResponseMessage<List<ProductViewModel>>();
                resp.StatusCode = HttpStatusCode.BadRequest;
                resp.Message.Add("Request data is empty");
                return resp;
            }

            ApiResponseMessage<List<ProductViewModel>> response = new ApiResponseMessage<List<ProductViewModel>>();

            response = ValuesHandler.GetProductTotalUsageAmountById(usageaccountid, pageCnt, pageRows);
            Logger.Info("End API GetProductTotalUsageAmount List");
            return response;
        }

        /// <summary>
        /// GetProductTotalUsageAmount
        /// </summary>
        /// <param name="pageCnt">查詢的頁數</param>
        /// <param name="pageRows">每頁筆數</param>
        /// <returns>ProductViewModel List</returns>
        [HttpGet]
        [Route("api/Order/GetProductGroupDateTotalUsageAmount")]
        public ApiResponseMessage<List<ProductViewModel>> GetProductGroupDateTotalUsageAmount(string usageaccountid, int pageCnt, int pageRows)
        {

            Logger.Info("Start API GetProductGroupDateTotalUsageAmount List");
            if (usageaccountid == null)
            {
                var resp = new ApiResponseMessage<List<ProductViewModel>>();
                resp.StatusCode = HttpStatusCode.BadRequest;
                resp.Message.Add("Request data is empty");
                return resp;
            }

            ApiResponseMessage<List<ProductViewModel>> response = new ApiResponseMessage<List<ProductViewModel>>();

            response = ValuesHandler.GetProductGroupDateTotalUsageAmountById(usageaccountid, pageCnt, pageRows);
            Logger.Info("End API GetProductGroupDateTotalUsageAmount List");
            return response;
        }
    }
}
