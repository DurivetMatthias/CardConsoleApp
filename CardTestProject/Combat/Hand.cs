namespace CardTestProject
{
    public class Hand: CardPile
    {
        public int HandSize { get; set; }

        public Hand()
        {
            HandSize = 5;
        }
    }
}
