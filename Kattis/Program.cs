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
                Console.WriteLine("\tA - Add");
                Console.WriteLine("\tS - Subtract");
                Console.WriteLine("\tM - Multiply");
                Console.WriteLine("\tD - Divide");
                Console.WriteLine("\t5 - Remainder");

                string operation = "";

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.A)
                {
                    operation = "a";
                }
                if (key == ConsoleKey.S)
                {
                    operation = "s";
                }
                if (key == ConsoleKey.M)
                {
                    operation = "m";
                }
                if (key == ConsoleKey.D)
                {
                    operation = "d";
                }
                if (key == ConsoleKey.D5)
                {
                    operation = "r";
                }

                while (string.IsNullOrEmpty(operation))
                {
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\tA - Add");
                    Console.WriteLine("\tS - Subtract");
                    Console.WriteLine("\tM - Multiply");
                    Console.WriteLine("\tD - Divide");
                    Console.WriteLine("\t5 - Remainder");

                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.A)
                    {
                        operation = "a";
                    }
                    if (key == ConsoleKey.S)
                    {
                        operation = "s";
                    }
                    if (key == ConsoleKey.M)
                    {
                        operation = "m";
                    }
                    if (key == ConsoleKey.D)
                    {
                        operation = "d";
                    }
                    if (key == ConsoleKey.D5)
                    {
                        operation = "r";
                    }
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
                    Console.WriteLine("Press 'End' and Enter to close the app or press any other key and Enter to continue: ");
                    if (Console.ReadKey().Key == ConsoleKey.End)
                        endApp = true;
                    Console.WriteLine("\n");
                }

                Console.WriteLine("-----------------------");

                Console.WriteLine("Press 'End' and Enter to close the app or press any other key and Enter to continue: ");
                if (Console.ReadKey().Key == ConsoleKey.End)
                    endApp = true;
                Console.WriteLine("\n");
            }
            // Add a call to close the JSON writer before return 
            calculator.Finish();
            return;
        }
    }
}