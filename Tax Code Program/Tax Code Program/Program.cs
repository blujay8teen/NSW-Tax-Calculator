using System;

namespace Tax_Code_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "NSW Tax Calculator";
            Console.WriteLine("=== NSW Tax Calculator ===\n");

            // Prompting the user for their taxable income
            Console.Write("Enter your annual taxable income (in AUD): $");
            string input = Console.ReadLine();

            // Validating and parsing the input
            if (decimal.TryParse(input, out decimal taxableIncome) && taxableIncome >= 0)
            {
                // Calculate the tax
                decimal tax = CalculateTax(taxableIncome);

                // Optionally, calculate the Medicare levy
                decimal medicareLevy = taxableIncome * 0.02m;

                // Calculate total tax payable
                decimal totalTaxPayable = tax + medicareLevy;

                // Calculate net income after tax
                decimal netIncome = taxableIncome - totalTaxPayable;

                // Display the results
                Console.WriteLine($"\nYour calculated income tax is: ${tax:N2}");
                Console.WriteLine($"Medicare Levy (2%): ${medicareLevy:N2}");
                Console.WriteLine($"Total Tax Payable: ${totalTaxPayable:N2}");
                Console.WriteLine($"Total income after tax is taken off: ${netIncome:N2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive numeric value.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Calculates the income tax based on Australian resident tax rates.
        /// </summary>
        /// <param name="income">The taxable income.</param>
        /// <returns>The calculated tax.</returns>
        static decimal CalculateTax(decimal income)
        {
            decimal tax = 0;

            if (income <= 18200)
            {
                tax = 0;
            }
            else if (income <= 45000)
            {
                tax = (income - 18200) * 0.19m;
            }
            else if (income <= 120000)
            {
                tax = 5092 + (income - 45000) * 0.325m;
            }
            else if (income <= 180000)
            {
                tax = 29467 + (income - 120000) * 0.37m;
            }
            else // income > 180000
            {
                tax = 51667 + (income - 180000) * 0.45m;
            }

            return tax;
        }
    }
}
