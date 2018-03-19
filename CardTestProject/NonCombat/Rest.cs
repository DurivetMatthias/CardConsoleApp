using CardTestProject.Exceptions;
using System;

namespace CardTestProject.NonCombat
{
    public class Rest : Event
    {
        public Rest(Player p)
        {
            Type = EventType.Rest;
            this.Player = p;
        }

        public override void Start()
        {
            Console.Clear();
            Console.WriteLine($"You entered a rest site");
            Player.Health += 25;
            if (Player.Health > 100) Player.Health = 100;
            throw new EndOfEventException();
        }
    }
}