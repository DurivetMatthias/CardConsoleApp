using CardTestProject.CardEffects;
using System;

namespace CardTestProject
{
    public class Enemy: Entity
    {
        public int AttackDmg { get; set; }
        public int BlockAmount { get; set; }
        public int NextAction { get; set; }

        public Enemy(int a,int b, string n)
        {
            AttackDmg = a;
            BlockAmount = b;
            Name = n;
        }

        public void MakeMove(Player p)
        {
            if (NextAction == 0)
            {
                MakeAttack(p);
            }
            else
            {
                MakeBlock(p);
            }
        }

        private void MakeBlock(Player p)
        {
            Console.WriteLine($"blocking: {BlockAmount}");
            Block += BlockAmount;

        }

        private void MakeAttack(Player p)
        {
            Console.WriteLine($"attacking: {AttackDmg + Strength}");
            new DealDamageEffect(AttackDmg).ActivateEffect(this, p);
        }

        public void DecideNextMove()
        {
            NextAction = new Random().Next(0, 2);
        }

        public void DeclareNextMove()
        {
            if (NextAction == 0)
            {
                Console.WriteLine($"this enemy will attack: {AttackDmg}\n");
            }
            else
            {
                Console.WriteLine($"this enemy will block: {BlockAmount}\n");
            }
        }

        public override int GetBaseHealth()
        {
            return 25;
        }
    }
}
