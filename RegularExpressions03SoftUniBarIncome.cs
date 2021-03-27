using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // RegularExpressions03SoftUniBarIncome

            string pattern = @"^[^|$%.]*%(?<coustomer>[A-z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$$";

            Regex barRegex = new Regex(pattern);

            Dictionary<List<string>, double> bar = new Dictionary<List<string>, double>();


            while (true)
            {
                string inputOrders = Console.ReadLine();
                if (inputOrders == "end of shift")
                {
                    break;
                }
                var currentMatch = barRegex.Match(inputOrders);
                if (currentMatch.Success == false)
                {
                    continue;
                }
                string currentCoustomer = currentMatch.Groups["coustomer"].ToString();
                string currentproduct = currentMatch.Groups["product"].ToString();
                int currentCounty = int.Parse(currentMatch.Groups["count"].ToString());
                double currentPrice = double.Parse(currentMatch.Groups["price"].ToString());

                bar.Add(new List<string>() { currentCoustomer, currentproduct }, currentCounty * currentPrice);


            }

            double totalIncome = 0;
            foreach (var item in bar)
            {
                Console.WriteLine($"{item.Key[0]}: {item.Key[1]} - {item.Value:F2}");
                totalIncome += item.Value;
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");


            //
        }
    }
}
