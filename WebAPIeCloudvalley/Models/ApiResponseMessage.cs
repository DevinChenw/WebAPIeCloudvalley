using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPIeCloudvalley.Models
{
    /// <summary>
    /// API回傳資訊
    /// </summary>
    /// <typeparam name="T">類型</typeparam>
    public class ApiResponseMessage<T> where T : class
    {
        public ApiResponseMessage() : this(null)
        {
        }
        public ApiResponseMessage(T data)
        {
            Message = new List<string>();
            Errors = new List<HttpError>();
            Data = data == null ? (T) Activator.CreateInstance(typeof(T)) : data;
        }
        /// <summary>
        /// 狀態代碼
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get { return Enumerable.Range(200, 100).Contains((int) StatusCode); } }
        /// <summary>
        /// 訊息列表
        /// </summary>
        public List<string> Message { get; set; }
        /// <summary>
        /// 相關錯誤
        /// </summary>
        public List<HttpError> Errors { get; set; }
        /// <summary>
        /// 開始頁
        /// </summary>
        public int? StartPage { get; set; }
        /// <summary>
        /// 結束頁
        /// </summary>
        public int? EndPage { get; set; }
        /// <summary>
        /// 每頁資料筆數
        /// </summary>
        public int? PageCount { get; set; }
        /// <summary>
        /// 結果
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalCount { get; set; }

    }
}
