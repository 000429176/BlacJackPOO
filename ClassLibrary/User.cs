﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class User
    {

        private List<Card> hand = new List<Card>(); 

        public List<Card> Hand { get => hand; set => hand = value; }

        public void AddCard(Card c)
        {
            hand.Add(c);
        }

    }
}
