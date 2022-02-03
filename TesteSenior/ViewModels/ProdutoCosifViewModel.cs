using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSenior.ViewModels
{
    public class ProdutoCosifViewModel
    {
        public ProdutoViewModel Produto { get; set; }

        public string CodCosif { get; set; }

        public string CodClassificacao { get; set; }

        public string Status { get; set; }

        public List<MovimentoManualViewModel> Movimentos { get; set; }

        public ProdutoCosifViewModel()
        {
            Produto = new ProdutoViewModel();
            Movimentos = new List<MovimentoManualViewModel>();
        }
    }
}