using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace Unit.Test
{
    public class Api1Test
    {
        private readonly HttpClient _client;

        public Api1Test()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact(DisplayName = "1-Teste resposta taxa juros")]
        public async Task TesteRespostaTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/taxajuros");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.ValidaRespostaHTTP();
        }

        [Fact(DisplayName = "2-Teste tipo retorno taxa juros")]
        public async Task TesteTipoRetornoTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/taxajuros");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaDecimal();
        }

        [Fact(DisplayName = "3-Teste valor taxa juros")]
        public async Task TesteValorTaxaJuros()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/taxajuros");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaValor(0.01M);
        }

        [Fact(DisplayName = "6-Teste resposta URL git")]
        public async Task TesteRespostaUrlGit()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/showmethecode");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.ValidaRespostaHTTP();
        }

        [Fact(DisplayName = "6-Teste tipo retorno URL git")]
        public async Task TesteTipoRetornoRespostaUrlGit()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/showmethecode");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            content.ValidaLink();
        }

        [Fact(DisplayName = "7-Teste URL git")]
        public async Task TesteUrlGit()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/showmethecode");

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            HttpClient client = new HttpClient();
            request = new HttpRequestMessage(new HttpMethod("GET"), content);
            response = await client.SendAsync(request);

            //Assert
            response.ValidaRespostaHTTP();
        }
    }
}
