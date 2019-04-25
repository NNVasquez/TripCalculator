using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCalculator
{
    public class Person
    {
        public string Name { get; set; }
        public List<Expense> Expenses { get; set; }
        public decimal RunningTotal { get; set; }
        public decimal FinalAmountOwed { get; set; }

        public Person(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                Name = "Name can't be Empty "+DateTime.Now.ToString();
            }
            else
                Name = name;

            Expenses = new List<Expense>();
            RunningTotal = 0.00m;
            FinalAmountOwed = 0.00m;
        }

        public void AddExpense(Expense exp)
        {
            Expenses.Add(exp);
            RunningTotal = RunningTotal + exp.DollarAmount;
        }

    }
}
