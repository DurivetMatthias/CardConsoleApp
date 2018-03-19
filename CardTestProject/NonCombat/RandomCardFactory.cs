using CardTestProject.CardEffects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.NonCombat
{
    public static class RandomCardFactory
    {
        public static int Damage { get; set; } = 5;
        public static int Block { get; set; } = 5;
        public static int Strength { get; set; } = 2;
        public static int Dexterity { get; set; } = 2;
        public static int Draw { get; set; } = 2;
        public static int Energy { get; set; } = 1;

        public static Card GetRandomCard()
        {
            Random r = new Random();
            int costRandom = r.Next(1, 101);
            int rarity = r.Next(0, 100);
            int cost;

            int threeRate = 5;
            int twoRate = 35;

            if (costRandom < threeRate) cost = 3;
            else if (costRandom < threeRate + twoRate) cost = 2;
            else cost = 1;

            float effectModifier = cost;

            List<CardEffect> Effects = new List<CardEffect>
            {
                new DealDamageEffect((int)Math.Ceiling(Damage*effectModifier)),
                new GainBlockEffect((int)Math.Ceiling(Block*effectModifier)),
                new GainStrengthEffect((int)Math.Ceiling(Strength*effectModifier)),
                new GainDexterityEffect((int)Math.Ceiling(Dexterity*effectModifier)),
                new DrawEffect((int)Math.Ceiling(Draw*effectModifier)),
                new GainEnergyEffect((int)Math.Ceiling(Energy*effectModifier))
            };

            int legendaryRate = 5;
            int rareRate = 20;

            if (rarity < legendaryRate) return new Card("custom card", cost, Effects[r.Next(0, Effects.Count)], Effects[r.Next(0, Effects.Count)], Effects[r.Next(0, Effects.Count)]);
            else if (rarity < legendaryRate+rareRate) return new Card("custom card", cost, Effects[r.Next(0, Effects.Count)], Effects[r.Next(0, Effects.Count)]);
            else return new Card("custom card", cost, Effects[r.Next(0, Effects.Count)]);
        }
    }
}
