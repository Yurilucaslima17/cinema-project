using AutoMapper;
using cinema_api.Data;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace cinema_api
{
    public class Startup
    {
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJFeGVtcGxlSXNzdWVyIiwiVXNlcm5hbWUiOiJTZWNyZXRVc2VyIiwiQXVkaWVuY2UiOiJFeGVtcGxlQXVkaWVuY2UiLCJleHAiOjE2MjQ4MjMzNjgsImlhdCI6MTYxMTc3Njk2OH0.Z-G_TPg-ZaSBNWsJ5R-CO5TpGKZ7-JBEIDWydcSy8Us";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CinemaContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IFilmRepo, SqlFilmRepo>();
            services.AddScoped<IRoomRepo, SqlRoomRepo>();
            services.AddScoped<ISectionRepo, SqlSectionRepo>();
            services.AddScoped<IUserRepo, SqlUserRepo>();


            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = SIGNING_KEY,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "https://localhost:44362",
                    ValidAudience = "https://localhost:44362",
                    ValidateLifetime = true
                };
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("CorsPolicy");
        }
    }
}
