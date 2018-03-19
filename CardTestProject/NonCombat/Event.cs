using CardTestProject.Exceptions;
using System;

namespace CardTestProject.NonCombat
{
    public enum EventType
    {
        Combat,Rest,Shop,Boss
    }

    public abstract class Event
    {
        public EventType Type { get; set; }
        public Player Player { get; set; }

        public abstract void Start();
        public void MainLoop()
        {
            try
            {
                while (true) Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Event has ended\nENTER to return to Map\n");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}