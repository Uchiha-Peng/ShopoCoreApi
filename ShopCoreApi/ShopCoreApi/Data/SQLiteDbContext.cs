using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopAPI.Models;
using ShopCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCoreApi.Data
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderdetail> Orderdetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Shopcart> Shopcart { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
