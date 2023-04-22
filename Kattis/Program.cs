using CalculatorLibrary;
using CalculatorApp;

namespace CalculatorApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Console Calulator in C#");
            Console.WriteLine("-----------------------");

            Calculator calculator = new Calculator();

            while (true)
            {
                ScanResult input = InputScanner.ScanInput();

                try
                {
                    double result = calculator.DoOperation(input.number1, input.number2, input.operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error");
                    }
                    else
                    {
                        Console.WriteLine($"Your result: {result:0.##}\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occured trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("-----------------------");

                Console.WriteLine("Press 'End' and Enter to close the app or press any other key and Enter to continue: ");
                if (Console.ReadKey().Key == ConsoleKey.End)
                {
                    break;
                }
                Console.WriteLine("\n");

                // Add a call to close the JSON writer before return 
                calculator.Finish();
                return;
            }
        }
    }
}