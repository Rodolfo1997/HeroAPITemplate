using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHeroService 
    {
        Task<IEnumerable<Hero>> GetHeroes();
        Task<Hero> InsertHero(Hero hero);
        Task<Hero> UpdateHero(Hero hero);
        Task<Hero> GetHero(Guid heroId);
        Task<bool> DeleteHero(Guid heroId);
    }
}
