using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCalculator
{
    public class Expense
    {
        public decimal DollarAmount { get; set; }

        public Expense(decimal amount)
        {
            if (amount < 00.00m)
                DollarAmount = 0.00m;
            else
                DollarAmount = amount;
        }
    }
}
