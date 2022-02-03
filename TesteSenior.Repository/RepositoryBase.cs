using System.Text;

namespace TesteSenior.Repository
{
    public class RepositoryBase
    {
        protected string _strConexao { get; set; }
        protected StringBuilder query;

        public RepositoryBase()
        {
            _strConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            query = new StringBuilder();
        }
    }
}
