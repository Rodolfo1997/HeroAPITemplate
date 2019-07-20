using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
    public class Hero
    {
        private IList<string> heroFriend;

        public Hero(string name, string power)
        {
            HeroId = Guid.NewGuid();
            Name = name;
            Power = power;
            heroFriend = new List<string>();
        }

        public Guid HeroId { get; private set; }
        public string Name { get; private set; }
        public string Power { get; private set; }

        public IReadOnlyCollection<string> HeroFriend
        {
            get
            {
                return heroFriend.ToArray();
            }
        }

        public void AddHeroFriend(string hero)
        {
            heroFriend.Add(hero);
        }
    }
}
