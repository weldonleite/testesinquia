using System;
using System.Collections.Generic;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Services;
using TesteSenior.Repository;

namespace TesteSenior.Application
{
    public class ProdutoAppService : IProdutoAppService
    {
        ProdutoRepository prodRepo;

        public ProdutoAppService()
        {
            prodRepo = new ProdutoRepository();
        }
        public List<Produto> Listar()
        {
            return prodRepo.Listar();
        }
    }
}
