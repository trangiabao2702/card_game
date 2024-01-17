using System;

namespace jsonCardGame
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sprite { get; set; }
        public bool inDeck { get; set; }
    }
    public class playerCards
    {
        public Card cards { get; set; }
    }

    public class Player
    {
        public string Rank;
        public string Name { get; set; }
        public Card[] cards { get; set; }
    }
}