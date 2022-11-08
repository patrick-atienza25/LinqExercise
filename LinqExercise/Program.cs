using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers - DONE
            Console.WriteLine("Sum of numbers:");
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            //TODO: Print the Average of numbers - DONE
            Console.WriteLine("Average of numbers:");
            var avg = numbers.Average();
            Console.WriteLine(avg);
            //TODO: Order numbers in ascending order and print to the console - DONE
            Console.WriteLine("Numbers in ascending order:");
            var ascendingOrder = numbers.OrderBy(x => x);
            foreach (var num in ascendingOrder)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order and print to the console - DONE
            Console.WriteLine("Numbers in descending order:");
            var descendingOrder = numbers.OrderByDescending(x => x);
            foreach (var num in descendingOrder)
            {
                Console.WriteLine(num);
            }
            //TODO: Print to the console only the numbers greater than 6 - DONE
            Console.WriteLine("Numbers greater than 6:");
            numbers.Where(num => num > 6).ToList().ForEach(x => Console.WriteLine(x));
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Printing 4 numbers:");
            foreach (var num in numbers.OrderBy(x => x >= 1).Take(4))
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Change index 4 and print in descending:");
            numbers.SetValue(29, 4);
            numbers.OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName. - DONE
            Console.WriteLine("First names starting with C or S:");
            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower().StartsWith('s')).OrderBy(name => name.FullName);
            foreach (var person in filtered)
            {
                Console.WriteLine(person.FullName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(person => person.Age > 26).OrderBy(age => age).OrderBy(name => name.FirstName);
            foreach (var person in overTwentySix)
            {
                Console.WriteLine(person);
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var LessThan10 = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Total YOE: {LessThan10.Sum(x =>x.YearsOfExperience)}");
            Console.WriteLine($"Total YOE: {LessThan10.Average(x => x.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add employee:");
            employees = employees.Append(new Employee("Patrick", "Atienza", 29, 2)).ToList();

            employees.ForEach(x => Console.WriteLine(x.FullName));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
