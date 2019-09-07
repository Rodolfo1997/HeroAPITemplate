using System.Data;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
