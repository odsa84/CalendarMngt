using System.Text;
using AutoMapper;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace CalendarMngt
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

            services.AddDbContext<cita_doctorContext>(options =>
            options.UseMySql("Server=localhost;port=3306;Database=cita_doctor;user id=root;"));
            //options.UseMySql("Server=sq65ur5a5bj7flas.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;Database=v16m117wkauqwy98;Uid=t3otnyhohimkqij7;Pwd=obuxw7wepy9a24em;SslMode=None;ConnectionTimeout=0"));
            //options.UseMySql("Server=db4free.net;port=3306;Database=cita_doctor;user id=odsa_84;password=123456789"));
            //options.UseMySql("Server=198.71.227.93;port=3306;Database=cita_doctor;user id=odsa_84;password=osvaldo2020*;SslMode=None;ConnectionTimeout=0"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<cita_doctorContext>();

            services.AddTransient<IRepositorioClinica, RepositorioClinica>();
            services.AddTransient<IRepositorioAuth, RepositorioAuth>();
            services.AddTransient<IRepositorioDoctor, RepositorioDoctor>();
            services.AddTransient<IRepositorioTitulo, RepositorioTitulo>();
            services.AddTransient<IRepositorioEspecialidad, RepositorioEspecialidad>();
            services.AddTransient<IRepositorioCliente, RepositorioCliente>();
            services.AddTransient<IRepositorioCalendario, RepositorioCalendario>();
            services.AddTransient<IRepositorioEstado, RepositorioEstado>();
            services.AddTransient<IRepositorioProvincia, RepositorioProvincia>();
            services.AddTransient<IRepositorioCiudad, RepositorioCiudad>();
            services.AddTransient<IRepositorioHorasLaborales, RepositorioHorasLaborales>();

            services.AddAutoMapper(typeof(Startup));

            //Creación de política para Cors Domain
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                    .AllowAnyHeader()));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            /*services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers();*/

            /*
             check and validate a JWT so that if an HTTP Request contains a header key for Authentication
             with a value in the form of Bearer {TOKEN}, we want the app to automatically check and validate
             the token and if everything is okay, to automatically login the user and mark the current 
             HTTP Request as authenticated
             */
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:4200",
                    ValidAudience = "http://localhost:4200",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"))
                };
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseCors("AllowAll");            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedUser.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);            

        }
    }
}
