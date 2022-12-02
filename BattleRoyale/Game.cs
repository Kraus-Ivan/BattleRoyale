using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleRoyale
{
    internal class Game
    {
        private int _round = 0;
        private Enemy[] _players;
        public Game(Enemy[] players)
        {
            _players = players;
        }
        
        public void Shuffle()
        {
            for (int i = 0; i < _players.Length; i++)
            {
                Enemy tmp = _players[i];
                int r = Random.Shared.Next(i, _players.Length);
                _players[i] = _players[r];
                _players[r] = tmp;
            }
        }

        public bool SomeOneAlive()
        {
            int alive = 0;
            foreach (Enemy enemy in _players)
            {
                if(enemy.IsAlive)
                    alive++;
            }
            return alive >= 2 ? true : false;
        }

        public Enemy Start()
        {
            Console.WriteLine("Pořadí: ");
            foreach (var item in _players)
            {
                Console.Write(item.ToString() + " \n");
            }
            Console.WriteLine("\n");
            do
            {
                _round++;
                Console.WriteLine("____________{0}.round____________", _round);
                foreach (Enemy player in _players)
                {
                    if (player.IsAlive)
                    {
                        if (player.IsAssasinated && (
                            _round % 4 == 0))
                        {
                            player.Assasinate();
                        }
                        if (player.IsAssasinated)
                        {
                            player.Hp -= 5;
                            Console.WriteLine("Na následek assasinování přišel {0} o 5 životů", player.ToString());
                            if (!SomeOneAlive())
                                WhoWon(_players);
                        }
                    }
                    if (player.IsAlive)
                    {
                        if (player.IsParalyzed)
                        {
                            player.Paralyze();
                            Console.WriteLine("{0} byl paralyzován, a proto nemohl v tomto kole hrát.", player.ToString());
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Enemy pickedOne = player.PickOpponent(_players);
                            player.Attack(pickedOne);
                            Console.WriteLine("{0} zaútočil na {1}", player.ToString(), pickedOne.ToString());
                            Console.WriteLine("\n");
                        }
                    }
                }
                foreach (Enemy player in _players)
                {
                    Console.WriteLine(player.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            } while (SomeOneAlive());
            return WhoWon(_players);
        }

        public Enemy WhoWon(Enemy[] _players)
        {
            foreach (Enemy player in _players)
            {
                if (player.IsAlive)
                {
                    Console.WriteLine("Zvítězil {0}", player.ToString());
                    return player;
                }
            }
            return null;
        }
    }
}
