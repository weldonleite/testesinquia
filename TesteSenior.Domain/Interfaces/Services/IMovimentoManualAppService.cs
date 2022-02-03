using System.Collections.Generic;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Structure;

namespace TesteSenior.Domain.Interfaces.Services
{
    public interface IMovimentoManualAppService
    {
        /// <summary>
        /// Lista os movimentos
        /// </summary>
        /// <returns></returns>
        List<MovimentoManual> Listar();

        /// <summary>
        /// Grava os movimentos no banco de dados
        /// </summary>
        /// <param name="mov"></param>
        /// <returns></returns>
        Result GravarMovimento(MovimentoManual mov);
    }
}
