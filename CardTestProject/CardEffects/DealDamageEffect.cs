namespace CardTestProject.CardEffects
{
    class DealDamageEffect : CardEffect
    {
        public int AttackAmount { get; set; }

        public DealDamageEffect(int amount)
        {
            AttackAmount = amount;
        }

        public override void ActivateEffect(Entity attacker, Entity target)
        {
            int actualDmg = AttackAmount + attacker.Strength;
            
            if (actualDmg > target.Block)
            {
                target.Health -= actualDmg - target.Block;
                target.Block = 0;
            }
            else target.Block -= actualDmg;
        }

        public override string ToString()
        {
            return $"Deal {AttackAmount} damage";
        }

        public override string UpdatedText(Entity e)
        {
            return $"Deal {AttackAmount + e.Strength} damage";
        }
    }
}
