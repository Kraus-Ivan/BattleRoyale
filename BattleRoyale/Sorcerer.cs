using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Sorcerer : Fighter
    {
        private int _attacks = 0;
        private const int MANARESET = 3; // Po kolika kolech dochází k doplnění many
        protected bool _mana;
        public bool Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }
        public Sorcerer(string name) : base(name)
        {
            AttackStrength = 20;
            Mana = true;
        }

        public override void Attack(Enemy attackedEnemy)
        {
            double a;
            if (_attacks % MANARESET == 0)
                Mana = true;
            if (Mana)
            {
                a = Random.Shared.Next(_minDeviation, _maxDeviation) * (_attackStrength * 5);
                a /= 100;
                Mana = false;
            }
            else
            {
                a = Random.Shared.Next(_minDeviation, _maxDeviation) * _attackStrength;
                a /= 100;
            }
            a = Math.Floor(a);
            attackedEnemy.ReceiveDamage((int)a);
            _attacks++;
        }
    }
}