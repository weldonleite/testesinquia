using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteSenior.ViewModels
{
    public class FormMovimentoViewModel
    {
        [Required(ErrorMessage ="Obrigatório")]
        [Range(1,12,ErrorMessage ="Meses válidos 1 a 12")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Ano inválido")]
        public int Ano { get; set; }

        public decimal Valor { get; set; }
        public ProdutoCosifViewModel ProdutoCosif { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Descricao { get; set; }
        public List<MovimentoManualViewModel> Movimentos { get; set; }

        public FormMovimentoViewModel()
        {
            ProdutoCosif = new ProdutoCosifViewModel();
            Movimentos = new List<MovimentoManualViewModel>();
        }
    }
}