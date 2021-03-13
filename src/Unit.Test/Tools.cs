using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using WebApi.Models;
using Xunit;

namespace Unit.Test
{
    public static class Tools
    {
        public static void ValidaValor(this string stg, decimal compare)
        {
            if (!string.IsNullOrWhiteSpace(stg))
            {
                if (decimal.TryParse(stg, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dec))
                    Assert.Equal(dec, compare);
                else
                    Assert.False(false, "Erro ao converter o retormo para decimal");
            }
            else
            {
                Assert.False(false, "O retorno está vazio ou nulo");
            }
        }

        public static void ValidaDecimal(this string stg)
        {
            if (!string.IsNullOrWhiteSpace(stg))
                Assert.True(decimal.TryParse(stg, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "Conversão bem sucedida para decimal");
            else
                Assert.False(false, "O retorno está vazio ou nulo");
        }

        public static void ValidaRetonroErro(this string stg)
        {
            if (!string.IsNullOrWhiteSpace(stg))
            {
                var erro = JsonConvert.DeserializeObject<ErroModels>(stg);
                if (erro == null)
                    Assert.False(false, "Não foi possivel converter o retorno para o objeto de erro");
                else
                    Assert.True(erro.Erro, $"O retorno de erro, mensagem: {erro.Mensagem}");
            }
            else
                Assert.False(false, "O retorno está vazio ou nulo");
        }
        
        public static void ValidaRespostaHTTP(this HttpResponseMessage responseMessage)
        {
            responseMessage.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
        
        public static void ValidaLink(this string stg)
        {
            if (!string.IsNullOrWhiteSpace(stg))
            {
                try
                {
                    new Uri(stg);
                    Assert.True(true, $"O retorno é uma URL valida");
                }
                catch (UriFormatException)
                {
                    Assert.False(false, "Formato inválido para uma URL");
                }
            }
            else
                Assert.False(false, "O retorno está vazio ou nulo");
        }
    }
}
