using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.NonCombat
{
    public static class RandomEventFactory
    {
        public static Event getEvent(Player p)
        {
            int random = new Random().Next(0, 20);
            if (random < 5) return new Rest(p);
            else if (random >= 5) return new Combat(p);
            else return null;
        }
    }
}
