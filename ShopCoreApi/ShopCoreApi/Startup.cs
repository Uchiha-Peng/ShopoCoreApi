using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShopCoreApi.Data;

namespace ShopCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 笔记

            ////重点一：
            ////services.Configure<SQLiteDbContext> 此方法作用是为非EF Core上下文对象从appsettings文件中读取配置字符串
            ////services.AddDbContext<SQLiteDbContext> 此方法作用是专门为EF Core上下文对象从appsettings文件中读取配置字符串的


            ////重点二：
            ////Configuration.GetSection("ConnectionStrings") 此方法作用是从appsettings文件中读取名为"ConnectionStrings"的这一节点的所有数据，如这里如果需要读取数据库连接字符串，则需要如下步骤
            //var aa = this.Configuration.GetSection("ConnectionStrings");
            //var cc = aa["SQLiteContext"];
            ////Configuration.GetConnectionString("SQLiteContext") 此方法的作用是从appsettings文件中读取名为"ConnectionStrings"的连接字符串，但是要求"ConnectionStrings"的父级节点的名称必须为"ConnectionStrings",否则将一直为Null，使用步骤如下
            //var bb = this.Configuration.GetConnectionString("SQLiteContext");

            ////services.Configure<SQLiteDbContext>(this.Configuration.GetSection("SQLiteConn"));

            #endregion
            services.AddDbContext<SQLiteDbContext>(options
                => options.UseSqlite(Configuration.GetConnectionString("SQLiteContext")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
