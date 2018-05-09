using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoreApi.Models
{
    public partial class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string ShoppingAddress { get; set; }
        public int Uid { get; set; }
    }
}
