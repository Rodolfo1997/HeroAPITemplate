using System.Data;
using System.Data.SqlClient;
using Repository.Contracts;

namespace Repository.Connection
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Database=HeroDB;Data Source=(localdb)\\MSSQLLocalDB;");
        }
    }
}
