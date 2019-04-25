using NUnit.Framework;
using TripCalculator;
using System.Collections.Generic;

namespace Tests
{
    public class ObjectTests
    {
        Person p;
        Expense e1;
        Expense e2;
        Expense e3;

        [SetUp]
        public void Setup()
        {
            //Total should be 7.75
            p = new Person("John");
            e1 = new Expense(1.50m);
            e2 = new Expense(2.50m);
            e3 = new Expense(3.75m);

            p.Expenses.Add(e1);
            p.Expenses.Add(e2);
            p.Expenses.Add(e3);
        }

        [Test]
        public void PersonNameShouldBeRecorded()
        {
            Assert.AreEqual("John", p.Name);
        }

        [Test]
        public void PersonNameShouldNotBeEmpty()
        {
            Person emptyName = new Person("");
            Assert.IsNotEmpty(emptyName.Name);
        }

        [Test]
        public void PersonNameShouldNotBeEmptyString()
        {
            Person emptyName = new Person(string.Empty);
            Assert.IsNotEmpty(emptyName.Name);
        }

        [Test]
        public void ExpensesShouldBeAboveZero()
        {
            Expense negativeTry = new Expense(-1.00m);

            Assert.GreaterOrEqual(negativeTry.DollarAmount, 0.00);
        }

        [Test]
        public void PersonNameCanBeChanged()
        {
            p.ChangeName("John2");

            Assert.AreEqual("John2", p.Name);
        }
    }

    public class CalculationTests
    {
        //People
        Person p1;
        Person p2;
        Person p3;

        //Expenses
        Expense e1p1;
        Expense e2p1;
        Expense e3p1;

        Expense e1p2;
        Expense e2p2;
        Expense e3p2;

        Expense e1p3;
        Expense e2p3;
        Expense e3p3;

        [SetUp]
        public void Setup()
        {  
            p1 = new Person("John");
            p2 = new Person("Mike");
            p3 = new Person("Patty");

            //Total should be 7.75
            e1p1 = new Expense(1.50m);
            e2p1 = new Expense(2.50m);
            e3p1 = new Expense(3.75m);

            //Total should be 66.75
            e1p2 = new Expense(10.50m);
            e2p2 = new Expense(20.50m);
            e3p2 = new Expense(35.75m);

            //Total should be 15.25
            e1p3 = new Expense(2.00m);
            e2p3 = new Expense(4.50m);
            e3p3 = new Expense(8.75m);

            p1.AddExpense(e1p1);
            p1.AddExpense(e2p1);
            p1.AddExpense(e3p1);

            p2.AddExpense(e1p2);
            p2.AddExpense(e2p2);
            p2.AddExpense(e3p2);

            p3.AddExpense(e1p3);
            p3.AddExpense(e2p3);
            p3.AddExpense(e3p3);

        }

        [Test]
        public void ExpensesCanBeAddedToPersons()
        {
            Assert.AreEqual(3, p1.Expenses.Count);
        }

        [Test]
        public void RunningTotalShouldBeKeptForExpenses()
        {
            Person p4 = new Person("Steve");

            Expense e1p4 = new Expense(3.44m);
            Expense e2p4 = new Expense(2.55m);

            p4.AddExpense(e1p4);
            p4.AddExpense(e2p4);

            Assert.AreEqual(5.99, p4.RunningTotal);
        }

        [Test]
        public void ExpensesShouldBeCombinedForAnAverage()
        {
            List<Person> people = new List<Person>();

            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            decimal averageExpenses = TripCalculations.AverageCurrentExpensesEveryone(people);

            Assert.AreEqual(29.92m, averageExpenses);
        }

        [Test]
        public void PersonsShouldKnowMoneyOwedByThem()
        {
            List<Person> people = new List<Person>();

            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            decimal averageExpenses = TripCalculations.AverageCurrentExpensesEveryone(people);

            foreach(Person p in people)
            {
                p.FinalAmountOwed = TripCalculations.AmountPersonOwes(averageExpenses, p.RunningTotal);
            }

            Assert.AreEqual(22.17m, p1.FinalAmountOwed);
        }

        [Test]
        public void PersonWhoPaidMostOwesZeroDollars()
        {
            List<Person> people = new List<Person>();

            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            decimal averageExpenses = TripCalculations.AverageCurrentExpensesEveryone(people);

            foreach (Person p in people)
            {
                p.FinalAmountOwed = TripCalculations.AmountPersonOwes(averageExpenses, p.RunningTotal);
            }

            Assert.AreEqual(0.00m, p2.FinalAmountOwed);
        }
    }
}