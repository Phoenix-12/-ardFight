public class Card(string name, Card.CardType type, int damage = 1, string description = "")
{
    public readonly string Name = name;
    public readonly int Damage = damage;
    public enum CardType
    {
        Near,
        Distant,
        Heavy
    };

    public readonly string Description = description;
    public readonly CardType Type = type;
}