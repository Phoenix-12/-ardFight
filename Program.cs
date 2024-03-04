using console_card_game;
using TEST;


CardManager.AllCards.Add(new Card("Near Card", Card.CardType.Near));
CardManager.AllCards.Add(new Card("Distant Card", Card.CardType.Distant));
CardManager.AllCards.Add(new Card("Heavy Card", Card.CardType.Heavy));

Fight fight = new Fight();



void Start()
{
    fight.EndStep += Step;
    fight.FightEnd += FinishGame;
}

void Step(Player p1, Player p2, int ps1, int ps2, Step s)
{
    
}

void FinishGame(int winnerId)
{
    Console.WriteLine("Player ID winner: " + winnerId);
}


string ConvertCardsToString(List<Card> cards)
{
    void SetStringLenght(ref string str, int lenght)
    {
        while (str.Length < lenght)
        {
            str += " ";
        }
    }
    string result = "";
    int index = 0;
    string s1 = "";
    string s2 = "";
    string s3 = "";
    
    foreach (Card card in cards)
    {
        s1 += "[тип: " + card.Type.ToString() + "] ";
        s2 += "[урон: " + card.Damage + "] ";
        s3 += "[номер: " + index.ToString() + "] ";
        int maxLenght = Math.Max(s1.Length, Math.Max(s2.Length, s3.Length));
        SetStringLenght(ref s1, maxLenght);
        SetStringLenght(ref s2, maxLenght);
        SetStringLenght(ref s3, maxLenght);
        index++;
    }
    result += s1 + "\n" + s2 + "\n" + s3 + "\n";
    return result;
}

void ViewGameState()
{
    Console.Clear();
    Player p1 = fight.FirstPlayer;
    Player p2 = fight.SecondPlayer;
    int ps1 = fight.FirstPlayerScore;
    int ps2 = fight.SecondPlayerScore;
    console_card_game.Step step = fight.Step;
    
    Console.WriteLine("\n==========GAME STATE==========");
    Console.WriteLine("Колода игрока " + p1.ID.ToString() + ":\n" + ConvertCardsToString(p1.Cards));
    Console.WriteLine("Колода игрока " + p2.ID.ToString() + ":\n" + ConvertCardsToString(p2.Cards));
    Console.WriteLine("Очки первого: " + ps1.ToString());
    Console.WriteLine("Очки второго: " + ps2.ToString());
    Console.WriteLine("Чей ход: " + step.GetCurrentStep());
    Console.WriteLine("");
}

void ChooseCard()
{
    
}

Card ChooseCardFromPlayerDeck(Player player, int cardIndex)
{
    return player.SpendCard(cardIndex);
}

Start();
Random rnd = new Random();

while (fight.FirstPlayer.Cards.Count > 0)
{
    ViewGameState();
    Console.WriteLine("Выбор карты первым игроком:");
    int firstPlayerCardChoose = Convert.ToInt32(Console.ReadLine());                //rnd.Next(fight.FirstPlayer.Cards.Count);
    Console.WriteLine("Выбор карты вторым игроком:");
    int secondPlayerCardChoose = Convert.ToInt32(Console.ReadLine());                //rnd.Next(fight.FirstPlayer.Cards.Count);

    fight.MakeStep(firstPlayerCardChoose, secondPlayerCardChoose);
}
Console.WriteLine("Карты кончились");

