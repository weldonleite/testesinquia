using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Repositories;

namespace TesteSenior.Repository
{
    public class ProdutoCosifRepository : RepositoryBase, IProdutoCosifRepository
    {
        public List<ProdutoCosif> ListarPorProduto(string codProduto)
        {
            List<ProdutoCosif> lstCosif = new List<ProdutoCosif>();
            query.Clear();
            query.Append(" SELECT P.COD_PRODUTO, ");
            query.Append(" ISNULL(P.DES_PRODUTO,'') AS DES_PRODUTO, ");
            query.Append(" ISNULL(P.STA_STATUS,'') AS STA_STATUS, ");
            query.Append(" C.COD_COSIF, ");
            query.Append(" ISNULL(C.COD_CLASSIFICACAO,'') AS COD_CLASSIFICACAO, ");
            query.Append(" ISNULL(C.STA_STATUS,'') AS STATUS_COD_COSIF ");
            query.Append(" FROM PRODUTO P INNER JOIN PRODUTO_COSIF C ON P.COD_PRODUTO = C.COD_PRODUTO ");
            query.Append(" WHERE P.COD_PRODUTO = @COD_PRODUTO ");

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@COD_PRODUTO", codProduto);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstCosif.Add(new ProdutoCosif
                            {
                                Produto = new Produto
                                {
                                    CodProduto = reader["COD_PRODUTO"].ToString().Trim(),
                                    Descricao = reader["DES_PRODUTO"].ToString().Trim()
                                },
                                CodCosif = reader["COD_COSIF"].ToString().Trim(),
                                CodClassificacao = reader["COD_CLASSIFICACAO"].ToString().Trim(),
                                Status = reader["STATUS_COD_COSIF"].ToString().Trim()
                            });
                        }
                    }
                }
            }
            return lstCosif;
        }
    }
}
