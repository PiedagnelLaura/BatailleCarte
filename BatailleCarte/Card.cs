using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCarte
{
    using Models;
    class Card : IComparable<Card>
    {
        private Values _value;
        private Suits _suits;
        private ConsoleColor _cardColor =>
            _suits == Suits.spade || _suits == Suits.clubs ?
            ConsoleColor.Black : ConsoleColor.Red;

        public Card(Values value, Suits suits)
        {
            _value = value;
            _suits = suits;
        }

        public void ShowCard(int index)
        {
            ShowCard(index.ToString() + ". ");
        }

        public void ShowCard(string prefix = "")
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = _cardColor;
            Console.Write(prefix + ToString());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
        }

        public int CompareTo(Card? other)
        {
            if (other is null) return 1;

            int valueDiff = other._value - _value;

            return valueDiff;
        }

        public override string? ToString()
        {
            return $"{_value} of {_suits}";
        }
    }
}
