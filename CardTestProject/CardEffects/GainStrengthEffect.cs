using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class GainStrengthEffect : CardEffect
    {
        public int GainAmount { get; set; }

        public GainStrengthEffect(int amount)
        {
            GainAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            attacker.Strength += GainAmount;
        }

        public override string ToString()
        {
            return $"Gain {GainAmount} strength";
        }

        public override string UpdatedText(Entity e)
        {
            return ToString();
        }
    }
}
