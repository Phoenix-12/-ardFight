namespace console_card_game;

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();

    public static Card GetCard(int index)
    {
        return AllCards[index];
    }
}