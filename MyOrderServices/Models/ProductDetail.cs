using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyOrderServices.Models
{
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductCategary { get; set; }

        public string ProductCost { get; set; }

        public byte[] ProductImage { get; set; }

        public string ManufacteringDate { get; set; }

    }
}