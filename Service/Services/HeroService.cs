using Domain.Domain;
using Microsoft.Extensions.Caching.Memory;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HeroService : IHeroService
    {
        private readonly IMemoryCache memoryCache;
        private readonly IHeroRepository repository;

        public HeroService(IHeroRepository repository, IMemoryCache memoryCache)
        {
            this.repository = repository;
            this.memoryCache = memoryCache;
        }

        public async Task<Hero> GetHero(Guid heroId)
        {
            return await repository.GetHero(heroId);
        }

        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            return await repository.GetHeroes();
        }

        public async Task<Hero> InsertHero(Hero hero)
        {
            var herosShield = await HerosShield();

            if (herosShield.Contains(hero.Name))
            {
                var friends = new List<string>
                {
                    herosShield[new Random().Next(0, herosShield.Count())],
                    herosShield[new Random().Next(0, herosShield.Count())]
                };

                foreach (var friend in friends)
                {
                    hero.AddHeroFriend(friend);
                }
            }

            return await repository.InsertHero(hero);
        }

        public async Task<Hero> UpdateHero(Hero hero)
        {
            return await repository.UpdateHero(hero);
        }

        public async Task<bool> DeleteHero(Guid heroId)
        {
            return await repository.DeletHero(heroId);
        }

        private async Task<List<String>> HerosShield()
        {
            List<string> list;

            if (!memoryCache.TryGetValue("HerosShield", out var herosShield))
            {
                var expirationTime = TimeSpan.FromMinutes(30);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                list = (await repository.HerosShield());

                memoryCache.Set("HerosShield", list, expirationTime);
            }
            else
            {
                list = (List<string>)herosShield;
            }

            return list;

        }
    }
}
