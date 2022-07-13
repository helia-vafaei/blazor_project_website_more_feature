using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P11.Server.DB;
using System.Linq;

namespace P11.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy",builder=>builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            var sqlConnectionString = "Host=ec2-54-158-232-223.compute-1.amazonaws.com;Port=5432;Database=d5hmkg26act904;Username=cbsomtztahkfkt;Password=5dbe86c70f2750c04e0fc538a3ad4f56b7fd93e6a3907c18ff2b36e879b17bd7;sslmode=Prefer;Trust Server Certificate=true;";
            services.AddDbContext<ClotheDBContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<ClotheProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
