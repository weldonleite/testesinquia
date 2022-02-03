using System.Collections.Generic;
using TesteSenior.Domain.Entities;

namespace TesteSenior.Domain.Interfaces.Services
{
    public interface IProdutoCosifAppService
    {
        List<ProdutoCosif> ListarPorProduto(string codProduto);
    }
}
