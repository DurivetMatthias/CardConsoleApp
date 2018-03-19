using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class DiscardEffect : CardEffect
    {
        public int DiscardAmount { get; set; }

        public DiscardEffect(int amount)
        {
            DiscardAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            for (int i = 0; i < DiscardAmount; i++)
            {
                Player player = (Player)attacker;
                player.DiscardCard(player.Hand.CardSelectMenu());
            }
        }

        public override string ToString()
        {
            return $"Discard {DiscardAmount} card(s)";
        }

        public override string UpdatedText(Entity e)
        {
            return ToString();
        }
    }
}
