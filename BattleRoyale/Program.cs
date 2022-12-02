using BattleRoyale;
using System;
using System.Diagnostics.Metrics;

bool pokracovat = false;

do
{
    Enemy fighter = new Fighter("Fighter");
    Enemy knight = new Knight("Knight");
    Enemy sorcerer = new Sorcerer("Sorcerer");
    Enemy beast = new Beast("Beast");
    Enemy berserker = new Berserker("Berserker");
    Enemy assasin = new Assasin("Assasin");

    Enemy[] players = { fighter, knight, sorcerer, beast, berserker, assasin};
    Game game = new Game(players);

    game.Shuffle();
    game.Start();

    Console.Write("Chcete pokračovat? (y/n):");
    if (Console.ReadLine().ToLower() == "y")
        pokracovat = true;
} while (pokracovat);


/*
int fighterWins = 0;
int knightWins = 0;
int sorcererWins = 0;
int beastWins = 0;
int berserkerWins = 0;
int assasinWins = 0;
for (int i = 0; i < 1000; i++)
{
    Enemy fighter = new Fighter("Fighter");
    Enemy knight = new Knight("Knight");
    Enemy sorcerer = new Sorcerer("Sorcerer");
    Enemy beast = new Beast("Beast");
    Enemy berserker = new Berserker("Berserker");
    Enemy assasin = new Assasin("Assasin");

    Enemy[] players = { fighter, knight, sorcerer, beast, berserker, assasin};
    Game game = new Game(players);

    game.Shuffle();
    Enemy winner = game.WhoWon(players);
    if (winner.ToString().Contains("Fighter"))
        fighterWins++;
    else if (winner.ToString().Contains("Knight"))
        knightWins++;
    else if (winner.ToString().Contains("Sorcerer"))
        sorcererWins++;
    else if (winner.ToString().Contains("Beast"))
        beastWins++;
    else if(winner.ToString().Contains("Berserker"))
        berserkerWins++;
    else if(winner.ToString().Contains("Assasin"))
        assasinWins++;
}

Console.WriteLine("FighterWins: {0}", fighterWins);
Console.WriteLine("KnightWins: {0}", knightWins);
Console.WriteLine("SorcererWins: {0}", sorcererWins);
Console.WriteLine("BeastWins: {0}", beastWins);
Console.WriteLine("Berserker: {0}", berserkerWins);
Console.WriteLine("Assasin: {0}", assasinWins);
*/
