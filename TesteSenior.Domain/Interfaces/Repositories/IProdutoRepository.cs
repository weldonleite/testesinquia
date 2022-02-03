using System.Collections.Generic;
using TesteSenior.Domain.Entities;

namespace TesteSenior.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Lista os produtos
        /// </summary>
        /// <returns></returns>
        List<Produto> Listar();
    }
}
