using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SW.CqApi;
using SW.HttpExtensions;
using SW.Logger;
using SW.PrimitiveTypes;

namespace SW.Gds.Web
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
            var gdsOptions = new GdsOptions();
            if (Configuration != null) Configuration.GetSection(GdsOptions.ConfigurationSection).Bind(gdsOptions);
            services.AddSingleton(gdsOptions);

            services.AddControllers().
                AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });


            services.AddAuthentication().
                AddJwtBearer(configureOptions =>
                {
                    configureOptions.RequireHttpsMetadata = false;
                    configureOptions.SaveToken = true;
                    configureOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]))
                    };

                });

            services.AddCqApi(options =>
            {
                options.UrlPrefix = "api";
               // options.ProtectAll = true;
            });

            services.AddDbContext<GdsDbContext>(c =>
            {
                c.EnableSensitiveDataLogging(true);
                c.UseSnakeCaseNamingConvention();
                c.UseNpgsql(Configuration.GetConnectionString(GdsDbContext.ConnectionString), b =>
                {
                    b.MigrationsHistoryTable("_ef_migrations_history", GdsDbContext.Schema);
                    b.UseAdminDatabase("defaultdb");
                });
            });

            services.AddScoped<RequestContext>();

            services.AddMemoryCache();
            services.AddHttpClient<ExternalCurrencyRatesService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpAsRequestContext();
            app.UseRequestContextLogEnricher();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
