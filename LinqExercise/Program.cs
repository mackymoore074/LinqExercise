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

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of numbers");
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine("Average of numbers");
            //TODO: Print the Average of numbers
            List<int> number = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var Avg = number.Average();
            Console.WriteLine($"Average: {Avg}");

            Console.WriteLine("numbers in ascending order");
            //TODO: Order numbers in ascending order and print to the console
            List<int> numb = new List<int> { 12, 32, 63, 54, 25, 36, 27, 68, 49, 20 };
            var asc = numb.OrderBy(num => num);
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine(" numbers in descending order");
            //TODO: Order numbers in descending order and print to the console
            List<int> numbe = new List<int> { 12, 32, 63, 54, 25, 36, 27, 68, 49, 20 };
            var desc = numbe.OrderByDescending(num => num);
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("numbers greater than 6");
            //TODO: Print to the console only the numbers greater than 6
            List<int> numt = new List<int> { 1, 3, 7, 8, 2, 4, 9, 8, 11, 6, 13 };
            var greater = numt.Where(num => num > 6);
            foreach (var num in greater)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("Order numbers in any order (ascending or desc) but only print 4");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            List<int> numbs = new List<int> { 1, 3, 7, 8, 2, 4, 9, 8, 11, 6, 13 };
            var order = numbs.OrderBy(num => num).Take(4);
            foreach (var num in order)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine(" value at index 4 to your age");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            List<int> numB = new List<int> { 1, 3, 7, 8, 2, 4, 9, 8, 11, 6, 13 };
            numB[4] = 33;
            var change = numB.OrderByDescending(num => num);
            foreach (var num in change)
            {
                Console.WriteLine(num);
            }

            // List of employees ****Do not remove this****
            var myEmployees = new string[][]
            {
                new string[] {"Cruz", "Sanchez", "25", "10"},
                new string[] {"Steven", "Bustamento", "56", "5"},
                new string[] {"Micheal", "Doyle", "36", "8"},
                new string[] {"Daniel", "Walsh", "72", "22"},
                new string[] {"Jill", "Valentine", "32", "43"},
                new string[] {"Yusuke", "Urameshi", "14", "1"},
                new string[] {"Big", "Boss", "23", "14"},
                new string[] {"Solid", "Snake", "18", "3"},
                new string[] {"Chris", "Redfield", "44", "7"},
                new string[] {"Faye", "Valentine", "32", "10"},
                new string[] {"John", "Doe", "30", "10"},
                new string[] {"Jane", "Doe", "30", "10"}
            };
            var employees = CreateEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();

            Console.WriteLine("FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName");
            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var first = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var person in first)
            {
                Console.WriteLine(person.FullName);
            }

            Console.WriteLine();


            Console.WriteLine("FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var age = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            foreach (var person in age)
            {
                Console.WriteLine($"{person.FullName} {person.Age}");
            }

            Console.WriteLine();

            Console.WriteLine("Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35");
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumYOE = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35).Sum(person => person.YearsOfExperience);
             Console.WriteLine($"the Sum of the employees' YearsOfExperience  if their YOE is less than or equal to 10 AND Age is greater than 35 is {sumYOE}");

            Console.WriteLine();

            Console.WriteLine("Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.");
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgYOE = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35).Average(person => person.YearsOfExperience);
            Console.WriteLine($"the Average of the employees' YearsOfExperience  if their YOE is less than or equal to 10 AND Age is greater than 35 is {avgYOE}");

            Console.WriteLine("");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Doe", 30, 10)).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }


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
