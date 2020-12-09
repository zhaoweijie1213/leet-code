using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeetCode.Data;
using LeetCode.Service;
using LeetCode.Service.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LeetCode
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
            services.AddHttpClient();
            //services.AddDbContext<MySqlDbContext>(options => options.UseMySQL(Configuration["ConnectionStrings:localhost_mysql"]));
      
            services.AddRazorPages();
            //数据库连接
            services.AddDbContext<MySqlDbContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("localhost_mysql")));
            services.AddTransient<HttpClientService>();
            services.AddSingleton<IMethod, Method>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //程序启动时运行
            var run = app.ApplicationServices.GetRequiredService<IMethod>();
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                //run.run();
                run.AddData();
                                                                                                                                            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
