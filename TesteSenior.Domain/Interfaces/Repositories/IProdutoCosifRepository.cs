using System.Collections.Generic;
using TesteSenior.Domain.Entities;

namespace TesteSenior.Domain.Interfaces.Repositories
{
    public interface IProdutoCosifRepository
    {
        /// <summary>
        /// Lista os Produtos Cosif por código de produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        List<ProdutoCosif> ListarPorProduto(string codProduto);
    }
}
