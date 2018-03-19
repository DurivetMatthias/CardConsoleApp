using CardTestProject.CardEffects;
using System;
using System.Collections.Generic;

namespace CardTestProject
{
    public enum Rarity
    {
        common,
        rare,
        legendary
    }

    public class Card
    {
        public int Cost { get; set; }
        public string Name { get; set; }
        public List<CardEffect> Effects { get; set; }
        public Rarity Rarity { get; set; }

        public Card(string title, int cost, CardEffect c1)
        {
            Name = title;
            Cost = cost;
            Effects = new List<CardEffect>
            {
                c1
            };
            Rarity = Rarity.common;
        }

        public Card(string title, int cost, CardEffect c1, CardEffect c2)
        {
            Name = title;
            Cost = cost;
            Effects = new List<CardEffect>
            {
                c1,
                c2
            };
            Rarity = Rarity.rare;
        }

        public Card(string title, int cost, CardEffect c1, CardEffect c2, CardEffect c3)
        {
            Name = title;
            Cost = cost;
            Effects = new List<CardEffect>
            {
                c1,
                c2,
                c3
            };
            Rarity = Rarity.legendary;
        }

        public void Execute(Player p, Enemy e)
        {
            if(p.Energy >= Cost)
            {
                p.Energy -= Cost;
                foreach (CardEffect effect in Effects)
                {
                    effect.ActivateEffect(p,e);
                }
            }
        }

        public string UpdatedToString(Entity e)
        {
            string result = $"-- Name: {Name} Cost: {Cost} --\n";
            foreach (CardEffect effect in Effects)
            {
                result += $"{effect.UpdatedText(e)}\n";
            }

            return result;
        }

        public override string ToString()
        {
            string result = $"-- Name: {Name} Cost: {Cost} --\n";
            foreach (CardEffect effect in Effects)
            {
                result += $"{effect}\n";
            }

            return result;
        }

        
    }
}
