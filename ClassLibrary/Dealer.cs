using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Dealer : User
    {
        private List<Card> deck = new List<Card>();

        public void Generate()
        {

            List<char> suits = new List<char>() { '♥', '♦', '♣', '♠' };
            List<string> symbols = new List<string>() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", };

            foreach (char suit in suits)
            {
                foreach (string symbol in symbols)
                {
                    Card c = new Card(suit, symbol);
                    deck.Add(c);
                }
            }
        }

        public void Randomize()
        {
            Random rand = new Random();

            // Algoritmo de fisher-yates 

            int n = deck.Count;
            for (int i = n - 1; i > 0; i--)
            {

                // Escoge entre 0 e i+1 un número 
                // todo este algoritmo mezcla la lista aleatoriamente
                int j = rand.Next(0, i + 1);

                // Usa temp como auxiliar para hacer el swap
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

        }

        public Card Deal()
        {
            // toma el primer elemento y lo remueve y lo retorna
            Card c = this.deck.First();
            this.deck.Remove(c);
            return c;
        }

        public void Init()
        {
            AddCard(Deal());
            AddCard(Deal());
        }
    }
}
