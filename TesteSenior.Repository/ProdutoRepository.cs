using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Repositories;

namespace TesteSenior.Repository
{
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    { 
        public List<Produto> Listar()
        {
            query.Clear();
            List<Produto> lstProduto = new List<Produto>();

            query.Append(" SELECT COD_PRODUTO, ");
            query.Append(" ISNULL(DES_PRODUTO,'') AS DES_PRODUTO, ");
            query.Append(" ISNULL(STA_STATUS,'') AS STA_STATUS ");
            query.Append(" FROM PRODUTO ");

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstProduto.Add(new Produto
                            {
                                CodProduto = reader["COD_PRODUTO"].ToString().Trim(),
                                Descricao = reader["DES_PRODUTO"].ToString().Trim(),
                                Status = reader["STA_STATUS"].ToString().Trim()
                            });
                        }
                    }
                }
            }

            return lstProduto;
        }
    }
}
