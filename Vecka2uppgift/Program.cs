namespace Vecka2uppgift;
class Program
{
    static void Main(string[] args)
    {
        Menu(); 
    }

    static void Menu()
    {
        Console.Clear(); 
        while (true) 
        {
            int input = InputHelper.GetUserInput<int>($"Welcome! Press \n" +
                $"1. To go to assignment number1(List):\n" +
                $"2. To go to assignment number 2(Dictionary):\n" +
                $"3. To go to assignment number 3(Book Class):\n4. To exit the program:");
               switch (input)
            {
                case 1:
                    StudentInterface.Menu();
                    break;
                case 2:
                    ProductsInterface.Menu();
                    break;
                case 3:
                    BookInterface.Menu();
                    break;
                case 4:
                    CloseProgram();
                    break;
                default: 
                    Console.WriteLine("That number doesnt exist.");
                    break;
            } // end of switch
        } //end of while
    }

    public static void CloseProgram() // the program closes the environment.
    {
        Console.Clear();
        Console.WriteLine("The program will close!");
        Console.ReadLine();
        Environment.Exit(0);
    }
}
