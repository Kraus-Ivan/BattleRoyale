using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Knight : Fighter
    {
        public Knight(string name) : base(name)
        {
            AttackStrength = 40;
            Protection = 0.35;
        }
    }
}
