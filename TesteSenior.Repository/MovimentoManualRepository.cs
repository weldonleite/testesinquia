using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Repositories;
using TesteSenior.Domain.Structure;

namespace TesteSenior.Repository
{
    public class MovimentoManualRepository : RepositoryBase, IMovimentoManualRepository
    {
        public Result GravarMovimento(MovimentoManual mov)
        {
            Result result = new Result();
            query.Clear();
            query.Append(" INSERT INTO MOVIMENTO_MANUAL ");
            query.Append(" (DAT_MES, DAT_ANO, COD_PRODUTO, COD_COSIF, VAL_VALOR, DES_DESCRICAO, DAT_MOVIMENTO, COD_USUARIO) ");
            query.Append(" VALUES (@DAT_MES, @DAT_ANO, @COD_PRODUTO, @COD_COSIF, @VAL_VALOR, @DES_DESCRICAO, GETDATE(), 'TESTE'); ");

            try
            {
                using (SqlConnection conn = new SqlConnection(_strConexao))
                {
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@DAT_MES", mov.Mes);
                        cmd.Parameters.AddWithValue("@DAT_ANO", mov.Ano);
                        cmd.Parameters.AddWithValue("@COD_PRODUTO", mov.ProdutoCosif.Produto.CodProduto);
                        cmd.Parameters.AddWithValue("@COD_COSIF", mov.ProdutoCosif.CodCosif);
                        cmd.Parameters.AddWithValue("@VAL_VALOR", mov.Valor);
                        cmd.Parameters.AddWithValue("@DES_DESCRICAO", mov.Descricao);
                        cmd.Connection.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result.Msg = "Movimento gravado com sucesso!";
                            result.TipoMsg = TipoMensagem.Sucesso;
                            result.Status = true;
                        }
                    }
                }
            }
            catch(Exception)
            {
                result.Msg = "Ocorreu um erro ao gravar o movimento!";
                result.TipoMsg = TipoMensagem.Erro;
                result.Status = false;
            }

            return result;
        }

        public List<MovimentoManual> Listar()
        {
            List<MovimentoManual> lstMov = new List<MovimentoManual>();
            query.Clear();
            query.Append("SP_LISTA_MOVIMENTO_MANUAL");

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstMov.Add(new MovimentoManual
                            {
                                NumLancamento = Convert.ToInt32(reader["NUM_LANCAMENTO"].ToString()),
                                Mes = Convert.ToInt32(reader["DAT_MES"].ToString()),
                                Ano = Convert.ToInt32(reader["DAT_ANO"].ToString()),
                                Descricao = reader["DESCR_MOVIMENTO"].ToString().Trim(),
                                DataMovimento = Convert.ToDateTime(reader["DAT_MOVIMENTO"].ToString()),
                                Valor = Convert.ToDecimal(reader["VAL_VALOR"].ToString()),
                                ProdutoCosif = new ProdutoCosif
                                {
                                    CodCosif = reader["COD_COSIF"].ToString().Trim(),
                                    Produto = new Produto
                                    {
                                        CodProduto = reader["COD_PRODUTO"].ToString().Trim(),
                                        Descricao = reader["DES_PRODUTO"].ToString().Trim()
                                    }
                                }
                            });
                        }
                    }
                }
            }
            return lstMov;
        }
    }
}
