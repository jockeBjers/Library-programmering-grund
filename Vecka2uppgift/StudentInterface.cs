using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class StudentInterface
    {
        //Creating a list with students added to it.
        private static List<string> students = new() { "Tomma", "Aron", "Walter", "Erik", "Kotte", "Fabbe", "Tiger" };

        public static void Menu()
        {
            Console.Clear();
            // The Menu keeps looping until closed. 
            while (true)
            {
                //Trying the input to see if it is an int or not                
                int input = InputHelper.GetUserInput<int>("press\n1. to list all students\n2. To add student\n" +
                    "3. To remove student\n4. To search for student\n5. Exit program");
                switch (input) //switch to chose from the menu by input.
                {
                    case 1:
                        PrintAllStudents(); // Go to method for printing out the list
                        break;
                    case 2:
                        AddStudent(); // Go to method to add new students
                        break;
                    case 3:
                        RemoveStudent(); // Go to method to remove students
                        break;
                    case 4:
                        SearchStudent(); // Search student list by name
                        break;
                    case 5:
                        Program.CloseProgram();  // closes the program when called.
                        break;
                    default: //Message when a number is entered that doesnt exist in the switch case.
                        Console.WriteLine("That number doesnt exist.");
                        break;
                } // end of switch
            }
        }

        public static void PrintAllStudents()
        {
            Console.Clear();
            //Iterates through the list with a foreach, printing out all the students.
            Console.WriteLine("students in the list: ");
            students.Sort(); // Sorting the students by alphabetical order

            foreach (var student in students) // Iterating over the list
            {
                Console.Write(student + " "); // adding a " " as im printing the list on one line
            }
            Console.WriteLine();
            Console.WriteLine("Press to continue: ");
            Console.ReadLine(); // method closes and takes you back to the menu after a button click.
        }
        public static void AddStudent()
        {
            Console.Clear();
            // prompts you to add students until you write stop
            while (true)
            {
                string student = InputHelper.GetUserInput<string>("Write the name of a student you want to add: ");
                students.Add(student!); // Adding the student to the list students. 

                if (!InputHelper.GetConfirmation("Would you like to add another student?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
            PrintAllStudents(); //prints out the list of students including the new added students.
        }
        public static void RemoveStudent()
        {
            Console.Clear();
            // prompts you to add students until you write stop
            while (true)
            {
                string student = InputHelper.GetUserInput<string>("Write the name of the student you want to remove: ");
                if (students.Remove(student!)) // If student found, will be removed
                {
                    Console.WriteLine("Student removed successfully.");
                }
                else
                {
                    Console.WriteLine("Name does not exist.");
                }
                if (!InputHelper.GetConfirmation("Would you like to remove another student?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
            PrintAllStudents(); //prints out the updated list
        }
        public static void SearchStudent() // Search for student
        {
            Console.Clear();
            while (true)
            {
                string student = InputHelper.GetUserInput<string>("Write the name of the student you want to search for");
                if (students.Contains(student)) //Check to see if the list contains a name that matches the user input
                {
                    Console.WriteLine($"{student} is a student here!"); // if found
                }
                else
                {
                    Console.WriteLine($"{student} is not a student here."); // if not
                }
                if (!InputHelper.GetConfirmation("Would you like to search for another student?"))
                {
                    break; // Exit loop and go back to menu
                }
            }
        }
    }
}