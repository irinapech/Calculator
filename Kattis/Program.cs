using System.Globalization;
using System.Runtime.CompilerServices;

class Calculator
{
    public static double DoOperation(double number1, double number2, string operation)
    {
        double result = double.NaN;

        switch (operation)
        {
            case "a":
                result = number1 + number2;
                break;
            case "s":
                result = number1 - number2;
                break;
            case "m":
                result = number1 * number2;
                break;
            case "d":
                if (number2 != 0)
                {
                    result = number1 / number2;
                }
                break;
            default:
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;

        Console.WriteLine("Console Calulator in C#");
        Console.WriteLine("-----------------------");

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

            try
            {
                result = Calculator.DoOperation(cleanNumber1, cleanNumber2, operation);
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
        return;
    }
}