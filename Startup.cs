using AutoMapper;
using Hotel_Management.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management
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
            services.AddControllers();
            services.AddDbContext<Databasecontext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Databasecontext")));
    
            services.AddIdentity<Customer, IdentityRole>().AddEntityFrameworkStores<Databasecontext>();
           
            var mappingConfig = new MapperConfiguration(c =>
              {
                  c.AddProfile(new MappingProfile());
              });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            





            //jws setting

            services.AddAuthentication(opt => {
                                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                            })
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = "http://localhost:5000",
                           ValidAudience = "http://localhost:5000",
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                       };
                   });
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod
             ().AllowAnyHeader());
            //app.UseCors(a => a.SetIsOriginAllowed(x => _ = true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
