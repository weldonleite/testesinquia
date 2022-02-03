using System;

namespace TesteSenior.Domain.Entities
{
    public class MovimentoManual
    {
        public int NumLancamento { get; set; }

        public string Descricao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public ProdutoCosif ProdutoCosif { get; set; }

        public DateTime DataMovimento { get; set; }

        public decimal Valor { get; set; }

        public string Usuario { get; set; }

        public MovimentoManual()
        {
            ProdutoCosif = new ProdutoCosif();
        }

        /// <summary>
        /// Valida os dados do model para cadastro do movimento 
        /// </summary>
        /// <param name="mov"></param>
        /// <returns></returns>
        public static bool ValidaModelCadastroMovimento(MovimentoManual mov)
        {
            bool ret = false;

            if (mov != null)
            {
                if (mov.Ano > 0)
                {
                    if (mov.Mes >=1 && mov.Mes <= 12)
                    {
                        if (mov.Valor > 0)
                        {
                            if (!string.IsNullOrEmpty(mov.Descricao))
                            {
                                if (mov.ProdutoCosif != null)
                                {
                                    if (!string.IsNullOrEmpty(mov.ProdutoCosif.CodCosif))
                                    {
                                        if (mov.ProdutoCosif.Produto !=null)
                                        {
                                            if (!string.IsNullOrEmpty(mov.ProdutoCosif.Produto.CodProduto))
                                            {
                                                ret = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }
}
