using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIeCloudvalley.Models
{
    public class ProductViewModel
    {
        /// <summary>
        /// ProductName
        /// </summary>
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        /// <summary>
        /// UsageStartDate
        /// </summary>
        [Display(Name = "Usage Start Date")]
        public DateTime UsageStartDate { get; set; }

        /// <summary>
        /// TotalUsageAmount
        /// </summary>
        [Display(Name = "Total Usage Amount")]
        public decimal TotalUsageAmount { get; set; }
    }
}