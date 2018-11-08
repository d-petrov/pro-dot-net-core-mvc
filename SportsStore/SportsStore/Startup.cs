using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using SportsStore.Models.Fakes;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace SportsStore
{
    public class Startup
    {
        #region props
        public IConfiguration Configuration { get; }
        #endregion props
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                    options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"])
                );            
            services.AddMvc();
            services.AddTransient<IProductRepository,FakeProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#if DEBUG
            app.UseDeveloperExceptionPage();
#endif
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => 
            {
                routes.MapRoute(name:"default",
                                template:"{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
