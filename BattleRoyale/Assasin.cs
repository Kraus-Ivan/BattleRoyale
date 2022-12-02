using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Assasin : Fighter
    {
        public Assasin(string name) : base(name) { }

        public override int Attack(Enemy attackedEnemy)
        {
            double a = Random.Shared.Next(_minDeviation, _maxDeviation) * _attackStrength;
            a /= 100;
            a = Math.Floor(a);
            attackedEnemy.Assasinate();
            return attackedEnemy.ReceiveDamage((int)a);
        }
    }
}
