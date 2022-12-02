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
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Na následek assasinování přišel {0} o 5 životů", player.ToString());
                            player.Hp -= 5;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (!SomeOneAlive())
                                WhoWon(_players);
                        }
                    }
                    if (player.IsAlive)
                    {
                        if (player.IsParalyzed)
                        {
                            player.Paralyze();
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("{0} byl paralyzován, a proto nemohl v tomto kole hrát.", player.ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Black;
                            Enemy pickedOne = player.PickOpponent(_players);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("{0} zaútočil na ", player.ToString());
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(" {0}", pickedOne.ToString());
                            int damage = player.Attack(pickedOne);
                            Console.Write(", ubral mu {0} HP", damage);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n");
                        }
                    }
                }
                foreach (Enemy player in _players)
                {
                    if (player.IsAlive)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(player.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
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
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Zvítězil {0}", player.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return player;
                }
            }
            return null;
        }
    }
}
