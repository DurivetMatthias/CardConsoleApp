using System;

namespace CardTestProject.NonCombat
{
    public class Shop : Event
    {
        public int CardRemovalCost { get; set; } = 300;

        public Shop(Player p)
        {
            Type = EventType.Shop;
            this.Player = p;
        }

        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You entered the shop");
                Console.WriteLine($"Gold: {Player.Gold}\n1: remove card \t({CardRemovalCost})\n2: show deck\t(0)\n");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        if(Player.Gold >= CardRemovalCost)
                        {
                            Player.Gold -= CardRemovalCost;
                            Console.WriteLine(Player.Deck);
                            Card c = Player.Deck.CardSelectMenu();
                            Player.Deck.Cards.Remove(c);
                        }
                        break;
                    case 2:
                        Console.WriteLine( Player.Deck);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}