using System;
using System.Collections.Generic;

namespace CardTestProject.NonCombat
{
    public class Map
    {
        public List<List<Event>> Trails { get; set; }
        public int CurrentTrail { get; set; }
        public int CurrentFloor { get; set; }
        public Player p { get; set; }
        public bool FirstFloor { get; set; }

        public Map(Player p)
        {
            this.p = p;
            CurrentFloor = -1;
            CurrentTrail = -1;
            FirstFloor = true;
            Trails = new List<List<Event>>();

            for (int i = 0; i < 4; i++)
            {
                Trails.Add(new List<Event>());
                Trails[i].Add(new Shop(p));
                for (int j = 0; j < 9; j++)
                {
                    Trails[i].Add(RandomEventFactory.getEvent(p));
                }
            }
        }

        public Event NextEventMenu()
        {
            Console.Clear();

            for (int floor = 9; floor >= 0; floor--) 
            {
                for (int trail = 0; trail < Trails.Count; trail++)
                {
                    if(CurrentFloor == floor && CurrentTrail == trail) Console.Write($"\t({Trails[trail][floor]})\t");
                    else Console.Write($"\t{Trails[trail][floor]}\t");
                }
                Console.WriteLine();
            }

            int selectedTrail = int.Parse(Console.ReadLine()) - 1;
            while((Math.Abs(selectedTrail - CurrentTrail) > 1 && !FirstFloor) || (selectedTrail<0 || selectedTrail >= Trails.Count))
            {
                Console.WriteLine("wrong argument\n");
                selectedTrail = int.Parse(Console.ReadLine()) - 1;
            }
            CurrentFloor++;
            CurrentTrail = selectedTrail;
            return Trails[selectedTrail][CurrentFloor];
        }
    }
}
