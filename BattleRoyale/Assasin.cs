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

        public override void Attack(Enemy attackedEnemy)
        {
            double a = Random.Shared.Next(_minDeviation, _maxDeviation) * _attackStrength;
            a /= 100;
            a = Math.Floor(a);
            attackedEnemy.Assasinate();
            attackedEnemy.ReceiveDamage((int)a);
        }
    }
}
