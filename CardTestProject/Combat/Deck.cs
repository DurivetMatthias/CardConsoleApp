using CardTestProject.NonCombat;

namespace CardTestProject.Combat
{
    public class Deck : CardPile
    {
        public Deck()
        {
            AddBaseCards();
        }

        public void AddBaseCards()
        {
            CardCatalog catalog = new CardCatalog();
            /*for (int i = 0; i < 4; i++)
            {
                Cards.Add(catalog.GetCard(0));
            }
            for (int i = 0; i < 4; i++)
            {
                Cards.Add(catalog.GetCard(1));
            }
            Cards.Add(catalog.GetCard(2));
            Cards.Add(catalog.GetCard(3));*/

            for (int i = 0; i < 10; i++)
            {
                Cards.Add(RandomCardFactory.GetRandomCard());
            }
        }
    }
}
