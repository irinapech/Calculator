namespace CalculatorApp
{
    public static class InputScanner
    {
        public static ScanResult ScanInput()
        {
            Console.WriteLine("Type a number and then press Enter");
            double firstNumberInput;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out firstNumberInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                }
            }

            Console.WriteLine("Type a number and then press Enter");
            double secondNumberInput;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out secondNumberInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a valid input. Please enter an integer value: ");
                }
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\tA - Add");
            Console.WriteLine("\tS - Subtract");
            Console.WriteLine("\tM - Multiply");
            Console.WriteLine("\tD - Divide");
            Console.WriteLine("\t5 - Remainder");

            string operation;

            while (true)
            {
                if (TryParseKey(Console.ReadKey(true).Key, out operation))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a valid input.\nChoose an operator from the following list:");
                    Console.WriteLine("\tA - Add");
                    Console.WriteLine("\tS - Subtract");
                    Console.WriteLine("\tM - Multiply");
                    Console.WriteLine("\tD - Divide");
                    Console.WriteLine("\t5 - Remainder");
                }
            }

            return new ScanResult()
            {
                number1 = firstNumberInput,
                number2 = secondNumberInput,
                operation = operation
            };
        }

        static bool TryParseKey(ConsoleKey key, out string result)
        {
            result = key switch
            {
                ConsoleKey.A => "a",
                ConsoleKey.S => "s",
                ConsoleKey.M => "m",
                ConsoleKey.D => "d",
                ConsoleKey.D5 => "r",
                _ => string.Empty
            };

            return result != string.Empty;
        }
    }
}