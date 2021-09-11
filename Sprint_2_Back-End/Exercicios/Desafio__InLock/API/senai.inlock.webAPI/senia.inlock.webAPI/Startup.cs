using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger para documentação
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Version 1.0",
                    Title = "Senai.Inlock.Tarde",
                    Description = "API para estudo acadademico"
               
                });
            });

            services.AddControllers();

            //Define a forma de autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

            // Define os parametros de validação do token
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Validar quem está emetindo o token
                    ValidateIssuer = true,

                    //Validar quem está recebendo o token
                    ValidateAudience = true,

                    //Valida o tempo de expiração do token
                    ValidateLifetime = true,

                    //Definindo a chave de segurança 
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-autenticacao-API-Inlock")),

                    //Tempo de expiração do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    //Define o nome do Issuer, quem emite o token
                    ValidIssuer = "Senai.Inlock",

                    //Define o nome do Audience, quem recebe o token
                    ValidAudience = "Senai.Inlock"

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

            //Swagger para documentação
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
                app.UseEndpoints(endpoints =>
                {
                    //Define o mapeamento dos Controllers.
                    endpoints.MapControllers();
                });
            });
        }
    }
}
