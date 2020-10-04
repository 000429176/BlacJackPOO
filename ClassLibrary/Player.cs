using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Player : User
    {
        public void Init(Card c1, Card c2)
        {
            Hand = new List<Card>();
            AddCard(c1);
            AddCard(c2);
        }
    }
}
