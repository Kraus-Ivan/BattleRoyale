using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Berserker : Fighter
    {
        private bool _picked = false;
        private Enemy pickedOne;

        public Berserker(string name) : base(name)
        {
            pickedOne = this;
        }

        public override Enemy PickOpponent(Enemy[] enemies)
        {
            if (!_picked)
            {
                _picked = true;
                pickedOne = enemies[Random.Shared.Next(enemies.Length)];
            }

            while (!pickedOne.IsAlive || pickedOne == this)
            {
                pickedOne = enemies[Random.Shared.Next(enemies.Length)];
            }
            return pickedOne;
        }
    }
}
