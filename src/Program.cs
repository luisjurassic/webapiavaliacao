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
        /// Metodo de inicializa��o.
        /// </summary>
        /// <param name="args">Argumentos de inicializa��o.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Cria o host e fornece as configura��o necess�rios.
        /// </summary>
        /// <param name="args">Argumentos de configura��o.</param>
        /// <returns>Retorna o host configurado.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
