﻿using System;
using BackendApi.Business;
using BackendApi.Business.Implementations;
using BackendApi.Repositories;
using BackendApi.Repositories.Context;
using BackendApi.Repositories.Implementations;
using BackendApi.Security.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BackendApi
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
            #region Definindo a conexão com o banco de dados.
            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<BdContext>(options => options.UseMySql(connection));
            #endregion

            #region Configurando a autenticação e validação de.

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidateAudience = true; 
                paramsValidation.ValidateIssuer = true; 
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth => {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configurando o swagger.
            services.AddSwaggerGen(swgConfig => {
                swgConfig.SwaggerDoc("v1", 
                    new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Title = "Swagger - Documentação API - Teste Técnco",
                        Version = "v1"
                    });
            });

            // Configurando as injeções de dependência.
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<IUserBusiness, UserBusinessImpl>();
            services.AddScoped<ILoginBusiness, LoginBusinessImpl>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swgUIConfig => {
                swgUIConfig.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger - Documentação API - Teste Técnco");
            });

            var options = new RewriteOptions();
            options.AddRedirect("^$", "swagger");
            app.UseRewriter(options);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
