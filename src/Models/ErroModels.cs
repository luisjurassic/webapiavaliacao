namespace WebApi.Models
{
    /// <summary>
    /// Classe modelo de erros.
    /// </summary>
    public class ErroModels 
    {
        /// <summary>
        /// Flag que indica se ocorreu erro.
        /// </summary>
        public bool Erro { get; set; }

        /// <summary>
        /// Mensagem de erro caso ocorra alguma exceção.
        /// </summary>
        public string Mensagem { get; set; }
    }
}
