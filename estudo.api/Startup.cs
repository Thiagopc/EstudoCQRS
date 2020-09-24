using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo.domain.Command;
using estudo.domain.Entity;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Db;
using estudo.infra.Db.Map;
using estudo.infra.Db.Repository;
using estudo.infra.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace estudo.api
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

            services.AddScoped<IRepositoryBase<Product>,RepositoryBase<Product>>();
            services.AddScoped<IRepositoryBase<Outbox>,RepositoryBase<Outbox>>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<Context>();
            services.AddScoped<ProductCommandHandler>();
            services.AddScoped<QueryMongo>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
