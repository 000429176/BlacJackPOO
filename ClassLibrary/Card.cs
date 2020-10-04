using System;

namespace ClassLibrary
{
    public class Card
    {
        // atributos de clase carta
        private char suit;
        private string symbol;
        private int score;
        private string color;

        public char Suit { get => suit; set => suit = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Score { get => score; set => score = value; }
        public string Color { get => color; set => color = value; }

        public Card(char suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;

            if (suit == '♦' || suit == '♥')
            {
                this.color = "red";

            }
            else
            {
                this.color = "black";
            }

            int value;
            try
            {
                value = Convert.ToInt32(symbol);
            }
            catch
            {
                if (symbol == "A")
                {
                    value = 1;
                }
                else
                {
                    value = 10;
                }
            }
            this.score = value;

        }
    }
}

