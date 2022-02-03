using System.Collections.Generic;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Structure;

namespace TesteSenior.Domain.Interfaces.Repositories
{
    public interface IMovimentoManualRepository
    {
        /// <summary>
        /// Lista os movimentos cadastrados
        /// </summary>
        /// <returns></returns>
        List<MovimentoManual> Listar();

        /// <summary>
        /// Grava um movimento na tabela MOVIMENTO_MANUAL
        /// </summary>
        /// <param name="mov"></param>
        /// <returns></returns>
        Result GravarMovimento(MovimentoManual mov);
    }
}
