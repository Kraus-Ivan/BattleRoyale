using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal abstract class Enemy
    {
        public const int _MAXHP = 100; 
        public int _hp = _MAXHP;
        protected bool _isAlive;  
        protected static int counter = 0;
        protected double _protection = 0.15;
        protected double _attackStrength = 30;
        protected bool _isParalyzed = false;
        protected int _minDeviation = 25; // dolní hranice praděpodobnosti netrefení ideálního útoku
        protected int _maxDeviation = 100; // horní hranice praděpodobnosti netrefení ideálního útoku
        protected bool _isAssasinated = false;

        public bool IsAssasinated
        {
            get { return _isAssasinated; }
            set { _isAssasinated = value; }
        }

        public bool IsParalyzed
        {
            get { return _isParalyzed; }
            protected set { _isParalyzed = value;}
        }
        
        public double Protection
        {
            get { return _protection; }
            protected set { _protection = value; }
        }

        public bool IsAlive
        { 
            get { if (Hp <= 0) { return _isAlive = false;}
                else { return _isAlive = true;};} 
        }

        public double AttackStrength
        {
            get { return _attackStrength; }
            protected set { _attackStrength = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set { if (value > _MAXHP) _hp = _MAXHP; else if (value < 0) _hp = 0; else _hp = value; } 
        }

        public void Assasinate()
        {
            if (IsAssasinated)
                IsAssasinated= false;
            else
                IsAssasinated = true;
        }

        public void Paralyze()
        {
            if (IsParalyzed)
                IsParalyzed = false;
            else
                IsParalyzed = true;
        }

        public virtual Enemy PickOpponent(Enemy[] enemies)
        {
            Enemy pickedOne;
            do
            {
                pickedOne = enemies[Random.Shared.Next(enemies.Length)];

            } while (!pickedOne.IsAlive || pickedOne == this);
            return pickedOne;
        }

        public virtual int Attack(Enemy attackedEnemy)
        {
            double a = Random.Shared.Next(_minDeviation, _maxDeviation) * _attackStrength;
            a /= 100;
            a = Math.Floor(a);
            return attackedEnemy.ReceiveDamage((int)a);
        }

        public int ReceiveDamage(int damage)
        {
            double d = damage * (1 - _protection);
            d = Math.Floor(d);
            Hp -= (int)d;
            return (int)d;
        }

        public override string ToString()
        {
            return string.Format("HP: {0}/{1} ({2})", Hp, _MAXHP, IsAlive ? "živý" : "mrtvý");
        }
    }
}
