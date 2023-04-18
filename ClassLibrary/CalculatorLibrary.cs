using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            //StreamWriter logFile = File.CreateText("calculator.log");
            //Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("Starting Calculator Log");
            //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));

            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double number1, double number2, string operation)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(number1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(number2);
            writer.WritePropertyName("Operation");

            switch (operation)
            {
                case "a":
                    result = number1 + number2;
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", number1, number2, result));
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = number1 - number2;
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", number1, number2, result));
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = number1 * number2;
                    //Trace.WriteLine(String.Format("{0} * {1} = {2}", number1, number2, result));
                    writer.WriteValue("Multiple");
                    break;
                case "r":
                    if (number2 != 0)
                    {
                        result = number1 % number2;
                        writer.WriteValue("Remainder");
                    }
                    break;
                case "d":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                        //Trace.WriteLine(String.Format("{0} / {1} = {2}", number1, number2, result));
                        writer.WriteValue("Divide");
                    }
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
            
            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}