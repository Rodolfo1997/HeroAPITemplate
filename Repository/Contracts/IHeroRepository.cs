using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetHeroes();
        Task<Hero> InsertHero(Hero hero);
        Task<Hero> UpdateHero(Hero hero);
        Task<Hero> GetHero(Guid heroId);
        Task<bool> DeletHero(Guid heroId);
        Task<List<string>> HerosShield();
    }
}
