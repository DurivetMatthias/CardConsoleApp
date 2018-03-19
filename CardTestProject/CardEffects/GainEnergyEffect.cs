using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class GainEnergyEffect : CardEffect
    {
        public int GainAmount { get; set; }

        public GainEnergyEffect(int amount)
        {
            GainAmount = amount;
        }
        public override void ActivateEffect(Entity attacker, Entity target)
        {
            Player player = (Player)attacker;
            player.Energy += GainAmount;
        }

        public override string ToString()
        {
            return $"Gain {GainAmount} energy";
        }

        public override string UpdatedText(Entity e)
        {
            return ToString();
        }
    }
}
