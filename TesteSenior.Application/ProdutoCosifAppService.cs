using System.Collections.Generic;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Services;
using TesteSenior.Repository;

namespace TesteSenior.Application
{
    public class ProdutoCosifAppService : IProdutoCosifAppService
    {
        ProdutoCosifRepository cosifRepo;

        public ProdutoCosifAppService()
        {
            cosifRepo = new ProdutoCosifRepository();
        }

        public List<ProdutoCosif> ListarPorProduto(string codProduto)
        {
            return cosifRepo.ListarPorProduto(codProduto);
        }
    }
}
