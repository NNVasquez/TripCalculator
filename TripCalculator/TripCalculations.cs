using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCalculator
{
    public static class TripCalculations
    {

        public static decimal TotalCurrentExpensesSinglePerson(Person p)
        {
            decimal result = 0.00m;

            foreach(Expense e in p.Expenses)
            {
                result = result + e.DollarAmount;
            }

            return result;

        }

        public static decimal AverageCurrentExpensesEveryone(List<Person> people)
        {
            decimal result = 0.00m;

            foreach (Person p in people)
            {
                result += p.RunningTotal;
            }

            result = result / people.Count;

            return decimal.Round(result,2) ;
        }

        public static decimal AmountPersonOwes(decimal averageAmountSpent,decimal rTotal)
        {
            decimal result = 0.00m;

            result = averageAmountSpent - rTotal;

            if (result < 0.00m)
                result =  0.00m;

            return result;
        }

    }
}
