using Domain.Domain;
using Repository.Contracts;
using Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository repository;

        public HeroService(IHeroRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Hero> InsertHero(Hero hero)
        {
            if(hero.Name.Equals("Iron Man"))
            {
                var friends = new List<string>{ "Iron Man1", "Iron Man2" };

                foreach (var friend in friends)
                {
                    hero.AddHeroFriend(friend);
                }
            }

            return await repository.InsertHero(hero);
        }
    }
}
