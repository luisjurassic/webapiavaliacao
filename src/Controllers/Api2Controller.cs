using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// Classe controladora da Api 2
    /// </summary>
    [ApiController]
    [Route("api")]
    public class Api2Controller : ControllerBase
    {
        /// <summary>
        /// Variavel de leituro de logs.
        /// </summary>
        private readonly ILogger<Api2Controller> _logger;

        /// <summary>
        /// Variavel da classe de ajuda.
        /// </summary>
        private Helper Helper { get; }

        /// <summary>
        /// O link do repositório git.
        /// </summary>
        private static string LinkCode { get; } = "https://github.com/luisjurassic/webapiavaliacao";

        /// <summary>
        /// Construtor da classe controladora da Api 2
        /// </summary>
        /// <param name="logger">Registro de logs da classe.</param>
        public Api2Controller(ILogger<Api2Controller> logger)
        {
            _logger = logger;
            Helper = new Helper();
        }

        /// <summary>
        /// Realiza o calculo de juros sobre o <paramref name="valorinicial"/>.
        /// </summary>
        /// <param name="valorinicial">O valor.</param>
        /// <param name="meses">Quantidade de tempo em meses.</param>
        /// <returns>O valor com juros relativo ao tempo em meses.</returns>
        [HttpGet]
        [Route("calculajuros/")]
        public async Task<object> GetCalculaJuros([FromQuery] decimal valorinicial, [FromQuery] int meses)
        {
            try
            {
                if (valorinicial <= 0)
                    throw new ArgumentException("Informe o parâmetro de valor inicial.");
                if (meses <= 0)
                    throw new ArgumentException("Informe o parâmetro de tempo em meses.");

                decimal juros = await Helper.TaxaJuros(Request);
                decimal pow = (decimal)Math.Pow((double)(1 + juros), meses);
                decimal resultado = Math.Round(valorinicial * pow, 2);

                return resultado;
            }
            catch (Exception ex)
            {
                ErroModels erro = new ErroModels
                {
                    Erro = true,
                    Mensagem = ex.Message
                };
                return erro;
            }
        }

        /// <summary>
        /// Retornar a url de onde encontra-se o código fonte do projeto.
        /// </summary>
        /// <returns>A url do repositório git.</returns>
        [HttpGet]
        [Route("showmethecode/")]
        public object GetShowMeCode()
        {
            return LinkCode;
        }
    }
}
