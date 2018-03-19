using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.CardEffects
{
    public abstract class CardEffect
    {
        public abstract void ActivateEffect(Entity attacker, Entity target);
        public abstract string UpdatedText(Entity e);
        public abstract override string ToString();
    }
}
