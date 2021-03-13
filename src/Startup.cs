using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace WebApi
{
    /// <summary>
    /// Classe de inicialização do aplicação
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe de inicialização
        /// </summary>        
        /// <param name="env">Informações do ambiente de hospedagem da aplicação</param>
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Propriedades de configuração da aplicação.
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configura os serviços que iram rodar com a aplicação.
        /// </summary>
        /// <param name="services">A coleção de serviços.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllers();

            try
            {
                services.AddSwaggerGen(swagger =>
                  {
                      swagger.SwaggerDoc("v1", new OpenApiInfo
                      {
                          Title = "WebAPI Avaliação .NET Core",
                          Version = "v1",
                          Description = "Documentação WebAPI da avaliação desenvolvedor .Net Core",
                          Contact = new OpenApiContact
                          {
                              Name = "Luis Jorge(Jurassic)",
                              Url = new Uri("https://bitbucket.org/luisjurassic"),
                              Email = "luis_jurassic@hotmail.com"
                          }
                      });

                      string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                      string xmlDoc = Path.Combine(AppContext.BaseDirectory, xmlFile);

                      swagger.IncludeXmlComments(xmlDoc);
                  });
            }
            catch { }
        }

        /// <summary>
        /// Configura a aplicação.
        /// </summary>
        /// <param name="app">Classe que fornece as configurações da aplicação.</param>
        /// <param name="env">Informações do ambiente de hospedagem da aplicação.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI Avaliação .NET Core");
                c.RoutePrefix = "api/docs";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}