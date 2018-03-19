using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class DrawEffect : CardEffect
    {
        public int DrawAmount { get; set; }

        public DrawEffect(int amount)
        {
            DrawAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            Player player = (Player) attacker;
            player.DrawCard(DrawAmount);
        }

        public override string ToString()
        {
            return $"Draw {DrawAmount} card(s)";
        }

        public override string UpdatedText(Entity e)
        {
            return ToString();
        }
    }
}
