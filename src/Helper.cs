using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
    /// <summary>
    /// Classe de ajuda para requisições HTTP.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Classe base para enviar e receber solicitações HTTP através de uma url.
        /// </summary>
        private HttpClient Client { get; }

        /// <summary>
        /// Contrutor da classe de ajuda.
        /// </summary>       
        public Helper()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (requist, certificate, chain, ssl) => { return true; }
            };
            Client = new HttpClient(clientHandler);
        }

        /// <summary>
        /// Chama a API 1 para realizar a consulta da taxa de juros.
        /// </summary>
        /// <param name="request">O objeto de solicitação HTTP.</param>
        /// <returns>Retorna o valor da taxa de juros</returns>
        public async Task<decimal> TaxaJuros(HttpRequest request)
        {
            var uri = new Uri($"{request.Scheme}://{request.Host}/api/taxajuros");
            var response = await Client.GetStringAsync(uri);

            decimal retorno = JsonConvert.DeserializeObject<decimal>(response);

            return retorno;
        }
    }
}