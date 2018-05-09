using ShopCoreApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoreApi.Models
{
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateTime { get; set; }
        public int Uid { get; set; }
        public int StatusId { get; set; }
        public string ShoppingAddress { get; set; }
    }
}
