using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class InputHelper
    {
        static public T GetUserInput<T>(string message = "") //Takes in any variable and returns the type
        {
            string typeName = typeof(T).Name.ToLower();
            Console.WriteLine($"{message}");
            //[{typeName}]
            // Try until users input is valid
            while (true)
            {
                string input = Console.ReadLine()!;

                // Null or empty input
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write($"> Anything please... ");
                    continue;
                }

                // Hack for reading float/double/decimals correctly
                if (typeName == "single" || typeName == "double" || typeName == "decimal")
                {
                    input = input.Replace('.', ',');
                }

                // try/switch for returning the correct converted type (Scary casting)
                try
                {
                    switch (typeName)
                    {
                        case "int16": return (T)(object)short.Parse(input);
                        case "int32": return (T)(object)int.Parse(input);
                        case "int64": return (T)(object)long.Parse(input);
                        case "uint16": return (T)(object)ushort.Parse(input);
                        case "uint32": return (T)(object)uint.Parse(input);
                        case "uint64": return (T)(object)ulong.Parse(input);
                        case "single": return (T)(object)float.Parse(input);
                        case "double": return (T)(object)double.Parse(input);
                        case "decimal": return (T)(object)decimal.Parse(input);
                        case "char": return (T)(object)char.Parse(input);
                        case "string": return (T)(object)input;
                        default: throw new Exception();
                    }
                }

                // Catch everything
                catch (Exception)
                {
                    Console.Write($"> Please enter valid {typeName}. {input} isn't a {typeName}... ");
                }
            }
        }

        public static bool GetConfirmation(string message)
        // As I have a lot of yes / no in my methods, I decided to make a simple helper to handle those cases 
        {
            Console.Write($"{message} (y/n): ");
            string input = Console.ReadLine()!.ToLower();
            while (input != "y" && input != "n")
            {
                Console.Write("Invalid input. Please enter 'y' or 'n': ");
                input = Console.ReadLine()!.ToLower();
            }
            return input == "y"; // if input is y, true is returned, else if n, its false.
        }
    }
}