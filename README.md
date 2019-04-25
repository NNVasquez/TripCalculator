# TripCalculator
Calculate trip costs

I do not believe this code has anything that would require special instructions for building and running.  I just open it in Visual Studio, build it, then run it.

The only thing that I can think of that could cause an issue is that I have ASP.Net Core 2.2 installed.  This being a Winforms application I don't think there should be an issue though.

To Run through, when the application starts: 
-Enter the names of the 3 students (clicking the "Change" button)
-For each student, enter their expenses in the "Expenses" box and click the "Add" button between each expense.  This should update the "Running Total" label.
-Once all expenses have been entered, click the "Calculate" button on the bottom right.  This should alter the "Results" label to give a sentence describing who owes who how much money.  The student who is owed money will show "is owed money"

-I did not allow for negative expenses in this iteration.  I also was not able to allow for "restarting" the application, so it must be closed and re-run for each "set of 3 students.
