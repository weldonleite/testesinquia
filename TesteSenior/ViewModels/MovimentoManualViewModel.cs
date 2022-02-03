using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSenior.ViewModels
{
    public class MovimentoManualViewModel
    {
        public int NumLancamento { get; set; }

        public string Descricao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public ProdutoCosifViewModel ProdutoCosif { get; set; }

        public DateTime DataMovimento { get; set; }

        public decimal Valor { get; set; }

        public string Usuario { get; set; }

        public MovimentoManualViewModel()
        {
            ProdutoCosif = new ProdutoCosifViewModel();
        }
    }
}