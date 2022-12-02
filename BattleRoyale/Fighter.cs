using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Fighter : Enemy
    {
        public string Name { get; private set; }

        public Fighter(string name)
        {
            Name = name;
            AttackStrength = 50;
        }

        public override string ToString()
        {
            return string.Format("{0} - HP: {1}/{2} ({3})", Name, Hp, _MAXHP, IsAlive ? "živý" : "mrtvý");
        }
    }
}
