using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripCalculator
{
    public partial class Form1 : Form
    {
        public Person person1 { get; set; }
        public Person person2 { get; set; }
        public Person person3 { get; set; }

        public Expense tempExpense { get; set; }

        public string PersonOwed { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeCalculatorSetup();
        }

        private void TimeCalculatorSetup()
        {
            person1 = new Person("Student1");
            person2 = new Person("Student2");
            person3 = new Person("Student3");

            S1NameTextBox.Text = person1.Name;
            S2NameTextBox.Text = person2.Name;
            S3NameTextBox.Text = person3.Name;

            Person1RTTextBox.Text = "";
            Person2RTTextBox.Text = "";
            Person3RTTextBox.Text = "";

            ResultsLabel1.Text = string.Empty;
            ResultsLabel2.Text = string.Empty;
            ResultsLabel3.Text = string.Empty;

        }

        private void S1ChangeButton_Click(object sender, EventArgs e)
        {
            string text = S1NameTextBox.Text;

            if (EmptyNameTextBoxCheck(text))
            {
                person1.ChangeName(text);
                S1NameTextBox.Text = person1.Name;
            }
        }

        private void S2ChangeButton_Click(object sender, EventArgs e)
        {
            string text = S2NameTextBox.Text;

            if (EmptyNameTextBoxCheck(text))
            {
                person2.ChangeName(text);
                S2NameTextBox.Text = person2.Name;
            }
        }

        private void S3ChangeButton_Click(object sender, EventArgs e)
        {
            string text = S3NameTextBox.Text;

            if (EmptyNameTextBoxCheck(text))
            {
                person3.ChangeName(text);
                S3NameTextBox.Text = person3.Name;
            }
        }       

        private Boolean EmptyNameTextBoxCheck(string text)
        {
            bool isBadString = string.IsNullOrWhiteSpace(text);

            if(isBadString)
            {
                string message = "Please use non-empty strings";
                string title = "Empty String Error";
                MessageBox.Show(message, title);
            }
            return !isBadString;
        }

        private Boolean ExpenseTextBoxCheck(string text)
        {
            Decimal convertAttempt;

            bool isBadString = string.IsNullOrWhiteSpace(text);
            bool isNotCurrency;
            bool isAbove0;

            string message;
            string title;

            if (isBadString)
            {
                message = "Please use non-empty strings";
                title = "Empty String Error";
                MessageBox.Show(message, title);
            }

            //Checking if can convert to currency
            if(Decimal.TryParse(text, out convertAttempt))
            {
                isNotCurrency = false;
            }
            else
            {
                message = "Please use a currency as an expense";
                title = "Currency Conversion Error";
                MessageBox.Show(message, title);

                isNotCurrency = true;
            }

            if (!isNotCurrency && convertAttempt < 0.00m)
            {
                message = "Please use a positive currency";
                title = "Currency Conversion Error";
                MessageBox.Show(message, title);

                isAbove0 = false;
            }
            else
                isAbove0 = true;

            return !isBadString && !isNotCurrency && isAbove0;
        }

        private void S1AddButton_Click(object sender, EventArgs e)
        {
            String text = S1ExpTextBox.Text;

            if (ExpenseTextBoxCheck(text))
            {
                tempExpense = new Expense(Decimal.Parse(text));
                person1.AddExpense(tempExpense);

                Person1RTTextBox.Text = "$"+ person1.RunningTotal.ToString();
                
                S1ExpTextBox.Text = "";
            }           
        }

        private void S2AddButton_Click(object sender, EventArgs e)
        {
            String text = S2ExpTextBox.Text;

            if (ExpenseTextBoxCheck(text))
            {
                tempExpense = new Expense(Decimal.Parse(text));
                person2.AddExpense(tempExpense);

                Person2RTTextBox.Text = "$" + person2.RunningTotal.ToString();

                S2ExpTextBox.Text = "";
            }
        }

        private void S3AddButton_Click(object sender, EventArgs e)
        {
            String text = S3ExpTextBox.Text;

            if (ExpenseTextBoxCheck(text))
            {
                tempExpense = new Expense(Decimal.Parse(text));
                person3.AddExpense(tempExpense);

                Person3RTTextBox.Text = "$" + person3.RunningTotal.ToString();

                S3ExpTextBox.Text = "";
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            List<Person> people = new List<Person>();

            Decimal averageExpense;

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);

            averageExpense = TripCalculations.AverageCurrentExpensesEveryone(people);

            foreach(Person p in people)
            {
                p.FinalAmountOwed = TripCalculations.AmountPersonOwes(averageExpense, p.RunningTotal);

                if (p.FinalAmountOwed == 0.00m)
                    PersonOwed = p.Name;
            }

            //At this point, each person should "know" how much they owe.
            GiveResults();
        }

        private void GiveResults()
        {
            ResultsLabel1.Text = GetResultString(person1);
            ResultsLabel2.Text = GetResultString(person2);
            ResultsLabel3.Text = GetResultString(person3);
        }

        private string GetResultString(Person person)
        {
            string result;

            if (person.FinalAmountOwed > 0.00m)
            {
                result = person.Name + " owes " + PersonOwed + " $" + person.FinalAmountOwed;
            }
            else
                result = person.Name + " is owed money.";
            return result;
        }
    }
}
