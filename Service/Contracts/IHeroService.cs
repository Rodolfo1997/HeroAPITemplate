using Domain.Domain;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHeroService 
    {
        Task<Hero> InsertHero(Hero hero);
    }
}
