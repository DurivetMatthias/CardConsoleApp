using CardTestProject.Exceptions;
using System;

namespace CardTestProject.NonCombat
{
    public class Combat : Event
    {
        public Enemy Enemy { get; set; }

        public Combat(Player p)
        {
            Enemy = RandomEnemyFactory.GetEnemy();
            Type = EventType.Combat;
            this.Player = p;
        }

        public void WriteGameState()
        {
            Console.Clear();
            Console.WriteLine($"drawpile: {Player.Draw.Cards.Count} - hand: {Player.Hand.Cards.Count} - discardpile: {Player.Discard.Cards.Count}");
            Console.WriteLine(Player.Hand.UpdatedToString(Player));
            Console.WriteLine(Player);
            Console.WriteLine(Enemy);
            Enemy.DeclareNextMove();
        }

        public override void Start()
        {
            Player.Draw.Cards = Player.Deck.Cards;
            Player.Draw.Shuffle();
            Player.ResetStats();

            while (Enemy.Health > 0)
            {
                Player.DrawHand();
                Player.EndTurn = false;
                Player.Energy = 3;
                Player.LoseBlock();
                Enemy.DecideNextMove();
                while (!Player.EndTurn && Enemy.Health > 0)
                {
                    
                    WriteGameState();
                    Card c = Player.Hand.CardSelectMenu();
                    if (c != null)
                    {
                        if (c.Cost <= Player.Energy)
                        {
                            Player.DiscardCard(c);//add in-play state/pile
                            c.Execute(Player, Enemy);
                        }
                        else Console.WriteLine("not enough energy\n");

                    }
                    else Player.EndTurn = true;
                }
                Player.DiscardHand();
                Enemy.LoseBlock();
                if (Enemy.Health > 0) Enemy.MakeMove(Player);
            }
            WriteGameState();
            Player.Gold += 100;
            throw new EndOfEventException();
        }
    }
}