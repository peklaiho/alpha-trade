﻿using System;

namespace AlphaTrade
{
    public class OrderBookEntry
    {
        public string Symbol;
        public long Id;
        public Side Side;
        public double Price;
        public int Size;
    }
}
