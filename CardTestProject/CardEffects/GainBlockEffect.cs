using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    class GainBlockEffect : CardEffect
    {
        public int BlockAmount { get; set; }

        public GainBlockEffect(int amount)
        {
            BlockAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            attacker.Block += BlockAmount + attacker.Dexterity;
        }

        public override string ToString()
        {
            return $"Gain {BlockAmount} block";
        }

        public override string UpdatedText(Entity e)
        {
            return $"Gain {BlockAmount + e.Dexterity} block";
        }
    }
}
