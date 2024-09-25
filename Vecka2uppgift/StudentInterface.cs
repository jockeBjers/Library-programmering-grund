using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vecka2uppgift
{
    public class StudentInterface
    {
        private static List<string> students = ["Tomma", "Aron", "Walter", "Erik", "Kotte", "Fabbe", "Tiger"];

        public static void Menu()
        {
            Console.Clear();
            while (true)
            {              
                int input = InputHelper.GetUserInput<int>("press\n1. to list all students\n2. To add student\n" +
                    "3. To remove student\n4. To search for student\n5. Exit program");
                switch (input) 
                {
                    case 1:
                        PrintAllStudents(); 
                        break;
                    case 2:
                        AddStudent(); 
                        break;
                    case 3:
                        RemoveStudent(); 
                        break;
                    case 4:
                        SearchStudent(); 
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

        public static void PrintAllStudents()
        {
            Console.Clear();
            Console.WriteLine("students in the list: ");
            students.Sort(); // Sorting the students by alphabetical order

            foreach (var student in students) // Iterating over the list
            {
                Console.Write(student + " "); // adding a " " as im printing the list on one line
            }
            Console.WriteLine();
            Console.WriteLine("Press to continue: ");
            Console.ReadLine(); 
        }

        public static void AddStudent()
        {
            Console.Clear();
            while (true)
            {
                string student = InputHelper.GetUserInput<string>("Write the name of a student you want to add: ");
                students.Add(student!); 

                if (!InputHelper.GetConfirmation("Would you like to add another student?"))
                {
                    break; 
                }
            }
            PrintAllStudents(); 
        }

        public static void RemoveStudent()
        {
            Console.Clear();
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
                    break;
                }
            }
            PrintAllStudents(); 
        }
        public static void SearchStudent() 
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