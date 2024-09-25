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
            PreDefinedProducts(); 
            Console.Clear();
            while (true) 
            {
                int input = InputHelper.GetUserInput<int>("Press:\n1. to list product\n2. to add a product\n" +
                    "3. to update a product\n4. to remove a product\n5. to exit"); 
                switch (input)
                {
                    case 1:
                        PrintAllProducts(); 
                        break;
                    case 2:
                        AddProduct(); 
                        break;
                    case 3:
                        UpdateProduct(); 
                        break;
                    case 4:
                        RemoveProduct(); 
                        break;
                    case 5:
                        Program.CloseProgram(); 
                        break;
                    default: 
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
                double price = InputHelper.GetUserInput<double>(); // If the input is a valid double, then we pair it to the productName
                products[productName] = price; // and the productName is used as the key. Then added in the dictionary. 

                Console.WriteLine($"Product '{productName}' with price {price} has been added.");
                if (!InputHelper.GetConfirmation("Would you like to continue adding products?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        public static void UpdateProduct() 
        {
            Console.Clear();
            while (true)
            {
                string productName = InputHelper.GetUserInput<string>("Enter the product name you want to update:");
                if (!products.ContainsKey(productName)!) //Find the productName in the Dictionary products.
                {
                    Console.WriteLine("Product not found.");
                }
                Console.WriteLine($"Current price of '{productName}': {products[productName]}");
                //Prints out the matching ProductName, and the value of the product
                // Ask for the new price
                double newPrice = InputHelper.GetUserInput<double>("Enter the new price:");
                products[productName] = newPrice; // Adding the new price to the productName
                Console.WriteLine($"The price of '{productName}' has been updated to {newPrice}."); // Confirm the new price.
                if (!InputHelper.GetConfirmation("Would you like to continue updating products?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }

        public static void RemoveProduct() 
        {
            Console.Clear();
            while (true)
            {
                string productName = InputHelper.GetUserInput<string>("Enter the product name you want to remove:"); 
                // Check if the product exists
                if (!products.ContainsKey(productName)) // If the product isnt found a message is shown.
                {
                    Console.WriteLine("Product not found.");
                }
                else
                {
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