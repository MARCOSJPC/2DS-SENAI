using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroades_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Version 1.0",
                    Title = "Senai.Hroades.Tarde",
                    Description = "API para estudo acadademico"

                });
            });

            //Define o uso de controllers
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            //Define a forma de autentica��o
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

            // Define os parametros de valida��o do token
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Validar quem est� emetindo o token
                    ValidateIssuer = true,

                    //Validar quem est� recebendo o token
                    ValidateAudience = true,

                    //Valida o tempo de expira��o do token
                    ValidateLifetime = true,

                    //Definindo a chave de seguran�a 
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-autenticacao-API-HROADES")),

                    //Tempo de expira��o do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    //Define o nome do Issuer, quem emite o token
                    ValidIssuer = "Senai.Hroades",

                    //Define o nome do Audience, quem recebe o token
                    ValidAudience = "Senai.Hroades"

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger para documenta��o
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            // Autenticar 
            app.UseAuthentication();

            // Autorizar
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Mapear as controllers
                endpoints.MapControllers();
            });
        }
    }
}
