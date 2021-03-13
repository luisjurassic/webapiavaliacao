using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    /// <summary>
    /// Classe responsavel por configurar a infraestrutura 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Metodo de inicialização.
        /// </summary>
        /// <param name="args">Argumentos de inicialização.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Cria o host e fornece as configuração necessários.
        /// </summary>
        /// <param name="args">Argumentos de configuração.</param>
        /// <returns>Retorna o host configurado.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
