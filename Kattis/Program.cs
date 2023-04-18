using System.Globalization;
using System.Runtime.CompilerServices;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calulator in C#");
            Console.WriteLine("-----------------------");

            Calculator calculator = new Calculator();

            while (!endApp)
            {
                string numberInput1 = "";
                string numberInput2 = "";
                double result = 0;

                Console.WriteLine("Type a number and then press Enter");
                numberInput1 = Console.ReadLine();

                double cleanNumber1 = 0;
                while (!double.TryParse(numberInput1, out cleanNumber1))
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                    numberInput1 = Console.ReadLine();
                }

                Console.WriteLine("Type a number and then press Enter");
                numberInput2 = Console.ReadLine();

                double cleanNumber2 = 0;
                while (!double.TryParse(numberInput2, out cleanNumber2))
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                    numberInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");

                string operation = Console.ReadLine();

                while (string.IsNullOrEmpty(operation))
                {
                    Console.WriteLine("This is not a valid input. Please choose an operator from the foloowing list");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    operation = Console.ReadLine();
                }

                try
                {
                    result = calculator.DoOperation(cleanNumber1, cleanNumber2, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occured trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("-----------------------");

                Console.WriteLine("Press 'n' and Enter to close the app or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n")
                    endApp = true;
                Console.WriteLine("\n");
            }
            // Add a call to close the JSON writer before return 
            calculator.Finish();
            return;
        }
    }
}