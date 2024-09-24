using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class ProductsInterface
    {
        private static Dictionary<string, double> products = new();

        public static void Menu()
        {
            PreDefinedProducts(); // adds to the Dictionary when the program is initialized.
            Console.Clear();
            while (true) // The menu keeps looping until closed.
            {
                //Trying the input to see if it is an int or not
                int input = InputHelper.GetUserInput<int>("Press:\n1. to list product\n2. to add a product\n" +
                    "3. to update a product\n4. to remove a product\n5. to exit"); // To get user input
                                                                                   //Switch-case for the menu choices, choose by input.
                switch (input)
                {
                    case 1:
                        PrintAllProducts(); //method to print out all the products in the dictionary.
                        break;
                    case 2:
                        AddProduct(); //Method to add to the dictionary
                        break;
                    case 3:
                        UpdateProduct(); //Method to update the price of a product
                        break;
                    case 4:
                        RemoveProduct(); //Method to remove a product based on the key
                        break;
                    case 5:
                        Program.CloseProgram(); //Method to close the program
                        break;
                    default: //Message when a number is entered that doesnt exist in the switch case.
                        Console.WriteLine("That number doesnt exist.");
                        break;
                } // end of switch
            }
        }

        private static void PreDefinedProducts()
        {   //pre defined products to emulate a database.
            products.Add("Lizard", 300.99);
            products.Add("Snake", 499.99);
            products.Add("Bike", 89.99);
            products.Add("Flag", 149.99);
            products.Add("Sword", 29.99);
        }

        public static void PrintAllProducts()
        {
            Console.Clear();
            // Sorting the products by price 
            var sortedProducts = products
                .OrderBy(item => item.Value); // Order by the product price

            Console.WriteLine("Products sorted by price:");
            foreach (var item in sortedProducts)  //Loops through the sorted products and prints them out.
            {
                Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
            }
        }

        public static void AddProduct()
        {   //Add to the dictionary
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Add Product to the list, write stop to stop");
                Console.WriteLine("Enter the product name:");
                string productName = InputHelper.GetUserInput<string>(); // Take input from user

                // Check if the product already exists, 
                if (products.ContainsKey(productName)!)
                {
                    Console.WriteLine("Product already exists in the list!");
                    return; //If the product exists, we return nothing.
                }

                Console.WriteLine("Enter the price as [ 00,00 ]:");
                double price = InputHelper.GetUserInput<double>(); // We try the price input to see if it is a double or not
                // If the input is a valid double, then we pair it to the productName
                products[productName] = price; // and the productName is used as the key. Then added in the dictionary. 

                Console.WriteLine($"Product '{productName}' with price {price} has been added.");
                // writing out a confirmation that the product has been added succesfully.
                if (!InputHelper.GetConfirmation("Would you like to continue adding products?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        public static void UpdateProduct() // Method to update a value of a key in the Dictionary.
        {
            Console.Clear();
            while (true)
            {
                string productName = InputHelper.GetUserInput<string>("Enter the product name you want to update:");
                if (!products.ContainsKey(productName)!) //Find the productName in the Dictionary products.
                {
                    Console.WriteLine("Product not found.");
                    PrintAllProducts(); // As the product doesnt exist, we print out the list. 
                    UpdateProduct(); // Takes you back to the top of the method to try again to find a product.
                }
                Console.WriteLine($"Current price of '{productName}': {products[productName]}");
                //Prints out the matching ProductName, and the value of the product
                // Ask for the new price
                double newPrice = InputHelper.GetUserInput<double>("Enter the new price:");
                // Update the price
                products[productName] = newPrice; // Adding the new price to the productName
                Console.WriteLine($"The price of '{productName}' has been updated to {newPrice}."); // Confirm the new price.
                if (!InputHelper.GetConfirmation("Would you like to continue updating products?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        public static void RemoveProduct() //Method to remove a product from the dictionary.
        {
            Console.Clear();
            while (true)
            {
                string productName = InputHelper.GetUserInput<string>("Enter the product name you want to remove:"); //Initialize The variable to compare.
                // Check if the product exists
                if (!products.ContainsKey(productName)) // If the product isnt found a message is shown.
                {
                    Console.WriteLine("Product not found.");
                }
                else
                {
                    // Remove the product
                    products.Remove(productName); // Removing the productName from the dictionary.
                    Console.WriteLine($"Product '{productName}' has been removed."); //output to confirm the removal
                }
                if (!InputHelper.GetConfirmation("Would you like to continue removing products?"))
                {
                    break; // Exit loop and go back to menu
                }

            }
        }
    }
}