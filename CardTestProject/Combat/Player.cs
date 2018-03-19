using System;
using CardTestProject.Combat;

namespace CardTestProject
{
    public class Player : Entity
    {
        public bool EndTurn { get; set; }
        public int Energy { get; set; }
        public int BaseDrawAmount { get; set; }
        public int Gold { get; set; }
        public Deck Deck { get; set; }
        public DrawPile Draw { get; set; }
        public DiscardPile Discard { get; set; }
        public Hand Hand { get; set; }

        public Player()
        {
            Deck = new Deck();
            Draw = new DrawPile();
            Discard = new DiscardPile();
            Hand = new Hand();
            Name = "player";
            Gold = 0;
            ResetStats();
        }

        public void DrawCard()
        {
            if (Draw.Cards.Count > 0)
            {
                Card c = Draw.Cards[0];
                Hand.Add(c);
                Draw.Cards.Remove(c);
            }
            else
            {
                RecycleDiscard();
                DrawCard();
            }
        }

        public void DrawCard(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                DrawCard();
            }
        }

        public void RecycleDiscard()
        {
            foreach (Card c in Discard.Cards)
            {
                Draw.Add(c);
            }
            Discard.Cards.Clear();
            Draw.Shuffle();
        }

        public void DrawHand()
        {
            for (int i = 0; i < Hand.HandSize; i++)
            {
                DrawCard();
            }
        }

        public void DiscardHand()
        {
            for (int i = Hand.Cards.Count - 1; i >= 0; i--)
            {
                Card c = Hand.Cards[i];
                Discard.Add(c);
                Hand.Cards.Remove(c);
            }
        }

        public void DiscardCard(Card c)
        {
            Discard.Add(c);
            Hand.Cards.Remove(c);
        }

        public void ResetStats()
        {
            Strength = 0;
            Dexterity = 0;
            Block = 0;
            Energy = 3;
            EndTurn = false;
        }

        public override int GetBaseHealth()
        {
            return 100;
        }

        public override string ToString()
        {
            return $"{base.ToString()}energy: {Energy}\n";
        }
    }
}
