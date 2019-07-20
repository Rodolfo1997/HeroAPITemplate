using Domain.Domain;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IHeroRepository
    {
        Task<Hero> InsertHero(Hero hero);
    }
}
