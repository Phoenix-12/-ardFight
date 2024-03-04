using System.Collections.Generic;
using console_card_game;

namespace TEST
{
    public static class CardsGenerator
    {
        public static List<Card> GenerateCards(Hero heroType)
        {
            if (heroType == Hero.Preset1)
            {
                return
                [
                    CardManager.AllCards[0], CardManager.AllCards[0], CardManager.AllCards[0], CardManager.AllCards[1],
                    CardManager.AllCards[1], CardManager.AllCards[2], CardManager.AllCards[2]
                ];
            }
            if (heroType == Hero.Preset2)
            {
                return
                [
                    CardManager.AllCards[0], CardManager.AllCards[0], CardManager.AllCards[1], CardManager.AllCards[1],
                    CardManager.AllCards[1], CardManager.AllCards[1], CardManager.AllCards[2]
                ];
            }
            return [CardManager.AllCards[0]];
        } 
    }
}