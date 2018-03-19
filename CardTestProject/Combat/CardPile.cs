using System;
using System.Collections.Generic;

namespace CardTestProject
{
    public class CardPile
    {
        public List<Card> Cards { get; set; }

        public CardPile()
        {
            Cards = new List<Card>();
        }

        public void Shuffle()
        {
            List<Card> temp = new List<Card>();
            List<int> usedIndexes = new List<int>();
            
            for (int i = 0; i < Cards.Count; i++)
            {
                int random = new Random().Next(0,Cards.Count);
                while(usedIndexes.Contains(random)) random = new Random().Next(0, Cards.Count);

                temp.Add(Cards[random]);
                usedIndexes.Add(random);
            }

            Cards = temp;
        }

        public void Add(Card c)
        {
            Cards.Add(c);
        }

        public Card CardSelectMenu()
        {
            int cardnumber;
            try
            {
                cardnumber = int.Parse(Console.ReadLine());
                while (cardnumber > Cards.Count || cardnumber < 0)
                {
                    Console.WriteLine("wrong argument\n");
                    cardnumber = int.Parse(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                return null;
            }
            if (cardnumber == 0) return null;
            else return Cards[cardnumber-1];
        }

        public string UpdatedToString(Entity e)
        {
            string result = "";
            foreach (Card c in Cards)
            {
                result += c.UpdatedToString(e) + "\n";
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Card c in Cards)
            {
                result += c+"\n";
            }
            return result;
        }
    }
}
