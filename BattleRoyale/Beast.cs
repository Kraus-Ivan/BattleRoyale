using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Beast : Fighter
    {
        public Beast(string name) : base(name) { }

        public override void Attack(Enemy attackedEnemy)
        {
            double a = Random.Shared.Next(_minDeviation, _maxDeviation) * _attackStrength;
            a /= 100;
            a = Math.Floor(a);
            attackedEnemy.Paralyze();
            attackedEnemy.ReceiveDamage((int)a);
        }
    }
}
