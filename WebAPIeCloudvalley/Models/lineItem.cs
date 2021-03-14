using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIeCloudvalley.Models
{
    /// <summary>
    /// lineItem
    /// </summary>
    public class lineItem
    {
        public lineItem()
        {

        }

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// ProductId
        /// </summary>
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }

        /// <summary>
        /// UnblendedRate
        /// </summary>
        [Display(Name = "Unblended Rate")]
        public decimal UnblendedRate { get; set; }

        /// <summary>
        /// UsageAmount
        /// </summary>
        [Display(Name = "Usage Amount")]
        public decimal UsageAmount { get; set; }

        /// <summary>
        /// UsageAccountId
        /// </summary>
        [Display(Name = "Usage Account Id")]
        public string UsageAccountId { get; set; }


        /// <summary>
        /// UsageStartDate
        /// </summary>
        [Display(Name = "Usage Start Date")]
        public DateTime UsageStartDate { get; set; }

        /// <summary>
        /// UsageEndDate
        /// </summary>
        [Display(Name = "Usage End Date")]
        public DateTime UsageEndDate { get; set; }

        /// <summary>
        /// UnblendedCost
        /// </summary>
        [Display(Name = "Unblended Cost")]
        public decimal UnblendedCost
        {
            get
            {
                return UnblendedRate * UsageAmount;
            }

            set
            {
                UnblendedCost = value;
            }
        }
    }
}