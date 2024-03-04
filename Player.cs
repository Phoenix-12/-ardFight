using System.Collections.Generic;

namespace TEST
{
    public class Player
    {
        public int ID;
        public Hero Hero;
        public int Experience = 0;
        public List<Card> Cards;
        
        
        public Player(int id, Hero hero)
        {
            ID = id;
            Hero = hero;
            RefreshCards();
        }

        public void RefreshCards()
        {
            Cards = CardsGenerator.GenerateCards(Hero);
        }

        public Card SpendCard(int cardIndex)
        {
            Card card = Cards[cardIndex];
            Cards.RemoveAt(cardIndex);
            return card;
        }
    }
}