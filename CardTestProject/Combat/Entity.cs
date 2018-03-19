using System;

namespace CardTestProject
{
    public abstract class Entity
    {
        public int Block { get; set; } = 0;
        public int Health { get; set; }
        public int Strength { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public string Name { get; set; }

        public Entity()
        {
            Health = GetBaseHealth();
        }

        public void LoseBlock()
        {
            Block = 0;
        }

        public void gainStrength(int amount)
        {
            Strength += amount;
        }

        public abstract int GetBaseHealth();

        public override string ToString()
        {
            return $"-- { Name} --\nhp: { Health}\nblock: { Block}\nstrength: { Strength}\ndexterity: { Dexterity}\n";
        }
    }
}
