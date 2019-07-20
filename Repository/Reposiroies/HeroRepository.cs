using Domain.Domain;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Reposiroies
{
    public class HeroRepository : IHeroRepository
    {
        public async Task<Hero> InsertHero(Hero hero)
        {
            return hero;
        }
    }
}
