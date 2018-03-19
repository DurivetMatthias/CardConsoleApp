using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class GainDexterityEffect : CardEffect
    {
        public int GainAmount { get; set; }

        public GainDexterityEffect(int amount)
        {
            GainAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            attacker.Dexterity += GainAmount;
        }

        public override string ToString()
        {
            return $"Gain {GainAmount} dexterity";
        }

        public override string UpdatedText(Entity e)
        {
            return ToString();
        }
    }
}
