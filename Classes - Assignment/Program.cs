using Making_a_Class;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes___Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {   // Raihan Carder

            List<Student> students = new List<Student>();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            string fName, lName;
            int selection = 0, studentIndex = 0;
            bool quit = false, exists = false, validInput = false;

            students.Add(new Student("Andrew", "Monteith"));
            students.Add(new Student("Jack", "Eitel"));
            students.Add(new Student("Ethan", "Jones"));
            students.Add(new Student("Geoffrey", "Dolbear"));
            students.Add(new Student("Travis", "Dylan"));

            Console.Title = "Google Classroom";

            while (!quit)
            {
                Console.WriteLine("Welcome to your Classroom information");
                Console.WriteLine();
                Console.WriteLine($"Your class currently has {students.Count} students.");
                Console.WriteLine("What Information would you like to access?");
                Console.WriteLine("1. See students currently enrolled in your class.");
                Console.WriteLine("2. Student Details");
                Console.WriteLine("3. Add a Student");
                Console.WriteLine("4. Remove a student");
                Console.WriteLine("5. Search for a student");
                Console.WriteLine("6. xxx");
                Console.WriteLine("7. Sort Students by Last Name");
                Console.WriteLine("8. Quit");

                Console.Write("What would you like to do: ");
                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    if (selection == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The students in your class are: ");
                        Console.WriteLine();
                        foreach (Student student in students)
                            Console.WriteLine(student);
                    }
                    else if (selection == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Which student's details would you like to accsess: ");
                        Console.WriteLine();

                        for (int i = 1; i < students.Count() + 1; i++)
                        {
                            Console.WriteLine($"{i}. {students[i - 1]}");
                        }

                        Console.WriteLine();
                        Console.Write("Type the first Name of the Corresponding Student: ");
                        fName = Console.ReadLine().ToUpper().Trim();
                        Console.Write("Type the last Name of the Corresponding Student: ");
                        lName = Console.ReadLine().ToUpper().Trim();

                        for (int i = 0; i < students.Count(); i++)
                        {
                            if (students[i].FirstName == fName && students[i].LastName == lName)
                            {
                                exists = true;
                                studentIndex = i;
                            }
                        }

                        Console.WriteLine();

                        if (exists == true)
                        {
                            Console.WriteLine($"The Student you have entered is: {fName} {lName}.");
                            Console.WriteLine($"{fName} is {students[studentIndex].StudentAge} years old.");
                            Console.WriteLine($"Their student number is {students[studentIndex].StudentNumber}.");
                            Console.WriteLine($"Their email is {students[studentIndex].Email}.");
                        }
                        else
                        {
                            Console.WriteLine("Student could not be found please try again.");
                        }
                    }
                    else if (selection == 3)
                    {
                        Console.Write("Enter the first Name of the new Student: ");
                        fName = Console.ReadLine().Trim().ToUpper();
   

                    }
                    else if (selection == 4)
                    {

                    }
                    else if (selection == 5)
                    {

                    }
                    else if (selection == 6)
                    {

                    }
                    else if (selection == 7)
                    {
                        students.Sort();
                        Console.WriteLine("Here's your new sorted Class List by last name:");
                        foreach (Student student in students)
                            Console.WriteLine(student);

                    }
                    else if (selection == 8)
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Input is not within the range of integers of 1-8, Try again.");
                    }
                } 
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Input invalid.");
                }

                    Console.WriteLine();
                    Console.Write("Click Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
            }


            Console.WriteLine("Thank you for using Google Classroom for all your classroom needs.");
            Console.ReadLine();


        }
    }
}



