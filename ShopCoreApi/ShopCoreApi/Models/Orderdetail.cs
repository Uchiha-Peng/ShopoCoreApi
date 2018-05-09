using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoreApi.Models
{
    public partial class Orderdetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProId { get; set; }
        public int ProNum { get; set; }
    }
}
