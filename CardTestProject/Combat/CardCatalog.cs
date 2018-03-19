using CardTestProject.CardEffects;
using CardTestProject.Exceptions;
using System;

namespace CardTestProject.Combat
{
    class CardCatalog : CardPile
    {
        public CardCatalog()
        {
            Cards.Add(new Card("Attack", 1, new DealDamageEffect(5)));
            Cards.Add(new Card("Defend", 1, new GainBlockEffect(5)));
            Cards.Add(new Card("Strength up", 1, new GainStrengthEffect(2)));
            Cards.Add(new Card("Dexterity up", 1, new GainDexterityEffect(2)));
            Cards.Add(new Card("Gamble", 0, new DiscardEffect(2), new GainEnergyEffect(2)));
            Cards.Add(new Card("Combo", 0, new DealDamageEffect(5), new DrawEffect(2)));
            Cards.Add(new Card("Outmanouver", 0, new GainBlockEffect(5), new DrawEffect(2)));
        }

        public Card GetCard(string name)
        {
            foreach (Card card in Cards)
            {
                if (card.Name.Equals(name)) return card;
            }
            throw new CardNotFoundException();
        }

        public Card GetCard(int index)
        {
            if (index >= 0 && index < Cards.Count) return Cards[index];
            else throw new CardNotFoundException();
        }

        public Card GetRandomCard()
        {
            int random = new Random().Next(2, Cards.Count);
            return Cards[random];
        }
    }
}
