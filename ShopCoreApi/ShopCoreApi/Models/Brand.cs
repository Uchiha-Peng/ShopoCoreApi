using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoreApi.Models
{
    public partial class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
