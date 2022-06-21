using Hospital.Management.System.Business.Mappers;
using Hospital.Management.System.Data.EntityFramework;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Hospital.Management.System.IOC.Repositories;
using Hospital.Management.System.IOC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Hospital.Management.System
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
            services.RegisterServices();
            services.RegisterRepositories();
            services.AddDbContext<HospitalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, Role>(
                 options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequiredLength = 4;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireLowercase = false;
                 }).AddEntityFrameworkStores<HospitalDbContext>(

                ).AddDefaultTokenProviders();
    

            services.AddAutoMapper(typeof(UserMapper));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op =>
            //{
            //    op.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("AllOrigins",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                                       .AllowAnyOrigin()
                                      .AllowAnyMethod();
                    });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //app.UseApiResponseAndExceptionWrapper(
            //new AutoWrapperOptions
            //{
            //    ApiVersion = Configuration["ApiVersion"].ToString(),
            //    ShowStatusCode = true,
            //    LogRequestDataOnException = true,
            //    ShowApiVersion = true,
            //    //UseApiProblemDetailsException = true,

            //    EnableResponseLogging = true,
            //    UseCustomExceptionFormat = true
            //});
            app.UseCors("AllOrigins");

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
    
            });
        }
    }
}
