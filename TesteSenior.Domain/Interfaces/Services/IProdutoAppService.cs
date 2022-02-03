using System.Collections.Generic;
using TesteSenior.Domain.Entities;

namespace TesteSenior.Domain.Interfaces.Services
{
    public interface IProdutoAppService
    {
        List<Produto> Listar();
    }
}
