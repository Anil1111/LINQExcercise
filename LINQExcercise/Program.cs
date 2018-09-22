using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExcercise
{
    class Program
    {
        // Build a collection of customers who are millionaires
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }

        // Define a bank
        public class Bank
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            //// RESTRICTION/FILTERING OPERATION
            
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var LFruits = from fruit in fruits
                          where fruit.StartsWith("L")
                          select fruit;
            Console.WriteLine($"Furits that start with L:");
            foreach (var f in LFruits)
            {
                Console.WriteLine($"{f}");
            }

            Console.WriteLine();
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
             15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where(num => num % 4 == 0 && num % 6 == 0);
            Console.WriteLine("Multiples of 4 and 6:");
            foreach (var num in fourSixMultiples)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine();

            //// ORDERING OPERATIONS
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
              "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
              "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
              "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
              "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
              "Francisco", "Tre"
            };

            var descend = from name in names
                          orderby name descending
                          select name;

            Console.WriteLine("Aphabetically Odredered names:");
            foreach (var name in descend)
            {   
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();
            // Build a collection of these numbers sorted in ascending order
            List<int> unorderedNumbers = new List<int>()
            {
               15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var sortedNumbers = from num in unorderedNumbers
                                orderby num ascending
                                select num;
            Console.WriteLine("Sorted Numbers:");
            foreach (var num in sortedNumbers)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine();

            //// Aggregate Operations
            // Output how many numbers are in this list
            Console.WriteLine("Aggregate");
            List<int> listNumbers = new List<int>()
            {
              15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var total = listNumbers.Count();
           
            Console.WriteLine($"Total Count: {total}");
            // How much money have we made?
            List<double> purchases = new List<double>()      
            {
               2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            var totalPurchase = purchases.Sum();
            Console.WriteLine($"Sum: {totalPurchase}");
            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            var maxPrice = prices.Max();
            Console.WriteLine($"Max: {maxPrice}");

            /*
              Store each number in the following List until a perfect square
              is detected.
            */
            Console.WriteLine("Partioning");
            List<int> wheresSquaredo = new List<int>()
            {
               66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            //var squaredNumber = wheresSquaredo.Where(num => (int) (Math.Sqrt((double) num)*10) == ((int) (Math.Sqrt((double) num)*10)));
            var squredNumber = from num in wheresSquaredo
                               where (int)(Math.Sqrt((double)num) * 10) == ((int)(Math.Sqrt((double)num))) * 10
                               select num;
            foreach (var s in squredNumber)
            {
                Console.WriteLine($"{s}");
            }
            //var squaredNumber = wheresSquaredo.TakeWhile(num => Math.Sqrt(num)/1 != 0);


            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };
           
            Console.WriteLine();
            Console.WriteLine("trial join displays the full name of the bank");
            var joinedMillionaires = banks.GroupJoin(customers,
                                     b => b.Name,
                                     c => c.Bank,
                                     (bankName, name) => new
                                     {
                                         banks = bankName,
                                         name = name
                                     });
            foreach (var d in joinedMillionaires)
            {
                Console.WriteLine(d.banks.Name);
            }

          
            Console.WriteLine("No of millionaires in a bank");
            var totalMillionaires = customers.GroupBy(x => x.Bank);
            foreach (var group in totalMillionaires)
            {
                Console.WriteLine("{0} {1}", group.Key, group.Count(x => x.Balance >= 1000000));
            }
            Console.WriteLine();
            Console.WriteLine("Millionaire names with banks sorted by ascending order name of the last name");
            var millionaires = customers.Where(x => x.Balance >= 1000000).Join(banks,
                c => c.Bank,
                b => b.Symbol,
                (c, b) => new { CustomerName = c.Name, BankName = b.Name }).OrderBy(m => m.CustomerName.Split(" ")[1]);
            //var millionairesWithBank =  millionaires.Join(banks,
            //    c => c.Bank, 
            //    b => b.Symbol,
            //    (c,b)  => new { CustomerName = c.Name, BankName = b.Name });
         
            foreach (var m in millionaires)
            {
                Console.WriteLine($"{m.CustomerName}, {m.BankName}");
            }

            Console.ReadLine();
        }
    }
}
