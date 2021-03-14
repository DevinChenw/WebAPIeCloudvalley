using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIeCloudvalley.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        public Product()
        {

        }

        /// <summary>
        /// Id
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// ProductName
        /// </summary>
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
}