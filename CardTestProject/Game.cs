using CardTestProject.NonCombat;
using System;

namespace CardTestProject
{
    class Game
    {
        public Player p { get; set; }
        public Map m { get; set; }

        public Game()
        {
            p = new Player();
            m = new Map(p);
        }

        public void Start()
        {
            while (p.Health>0)
            {
                Event e = m.NextEventMenu();
                e.MainLoop();
            }
        }
    }
}
