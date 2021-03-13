using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi;
using WebApi.Models;
using Xunit;

namespace Unit.Test
{
    public class Api2Test
    {
        private readonly HttpClient _client;

        public Api2Test()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact(DisplayName = "1-Teste resposta calculo juros")]
        public async Task TesteRespostaCalculoJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/calculajuros");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.ValidaRespostaHTTP();
        }

        [Fact(DisplayName = "2-Teste sem parâmetros calculo juros")]
        public async Task TesteSemParametrosTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/calculajuros");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaRetonroErro();
        }

        [Fact(DisplayName = "3-Teste parâmetros errados calculo juros")]
        public async Task TesteParametrosErradosTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/calculajuros?valor=abc&mes=m");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaRetonroErro();
        }

        [Fact(DisplayName = "4-Teste tipo retonro calculo juros")]
        public async Task TesteTipoRetornoValorTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/calculajuros?valorinicial=100&meses=5");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaDecimal();
        }

        [Fact(DisplayName = "5-Teste valor calculo juros")]
        public async Task TesteValorTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/calculajuros?valorinicial=100&meses=5");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
          
            //Assert
            content.ValidaValor(105.10M);
        }
    }
}
