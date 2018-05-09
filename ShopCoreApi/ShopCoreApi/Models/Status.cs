using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCoreApi.Models
{
    public partial class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
