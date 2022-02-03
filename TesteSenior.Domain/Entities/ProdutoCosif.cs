namespace TesteSenior.Domain.Entities
{
    public class ProdutoCosif
    {
        public Produto Produto { get; set; }

        public string CodCosif { get; set; }

        public string CodClassificacao { get; set; }

        public string Status { get; set; }

        public ProdutoCosif()
        {
            Produto = new Produto();
        }
    }
}
