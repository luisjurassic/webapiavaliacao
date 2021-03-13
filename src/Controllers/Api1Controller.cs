using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    /// <summary>
    /// Classe controladora da Api 1
    /// </summary>
    [ApiController]
    [Route("api")]
    public class Api1Controller : ControllerBase
    {
        /// <summary>
        /// Variavel de leituro de logs.
        /// </summary>
        private readonly ILogger<Api1Controller> _logger;
        
        /// <summary>
        /// O valor fixo da taxa de juros
        /// </summary>
        private decimal TaxaJuros { get; } = 0.01M;

        /// <summary>
        /// Construtor da classe controladora da Api 1
        /// </summary> 
        /// <param name="logger">Registro de logs da classe.</param>
        public Api1Controller(ILogger<Api1Controller> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna a taxa de juros.
        /// </summary>
        /// <returns>Valor da taxa de juros em decimal.</returns>
        [HttpGet]
        [Route("taxajuros/")]
        public object GetTaxaJuros()
        {
            return TaxaJuros;
        }
    }
}
