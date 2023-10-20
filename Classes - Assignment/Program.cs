using Making_a_Class;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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

            string fName = "", lName = "";
            int selection = 0, studentIndex = 0, studentRemove = 0, editSelection = 0, studentEdit = 0;
            bool quit = false, exists = false, validInput = false, newInput = true;

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
                Console.WriteLine("6. Edit a Student");
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
                            Console.WriteLine($"The Student you have entered is: {students[studentIndex]}.");
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

                        Console.WriteLine();
                        Console.Write("Enter the First Name of the new Student: ");

                        while (validInput == false)
                        {
                            fName = Console.ReadLine().Trim().ToUpper();

                            for (int i = 0; i < fName.Length; i++)
                            {
                                if (!alphabet.Contains(fName[i]))
                                {
                                    Console.Write("Error, Invalid Input in first name, re-enter input: ");
                                    validInput = true;
                                }
                            }


                            if (!validInput)
                            {
                                validInput = true;
                            }
                            else
                            {
                                validInput = false;
                            }

                        }
                        validInput = false;

                        Console.Write("Enter the Last Name of the new Student: ");

                        while (validInput == false)
                        {
                            lName = Console.ReadLine().Trim().ToUpper();

                            for (int i = 0; i < lName.Length; i++)
                            {
                                if (!alphabet.Contains(lName[i]))
                                {
                                    Console.Write("Error, Invalid Input in Last name, re-enter input: ");
                                    validInput = true;
                                }
                            }

                            if (!validInput)
                            {
                                validInput = true;
                            }
                            else
                            {
                                validInput = false;
                            }

                        }
                        validInput = false;

                        newInput = true;

                        for (int i = 0; i < students.Count(); i++)
                        {
                            if (lName.Equals(students[i].LastName) && fName.Equals(students[i].FirstName))
                            {
                                newInput = false;
                            }
                        }

                        if (newInput == true)
                        {
                            students.Add(new Student(fName, lName));
                            Console.WriteLine("Student Added");
                        }
                        else
                        {
                            Console.WriteLine("Student Already Exists, Student Will not be Added.");
                        }
                    }
                    else if (selection == 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Which student would you like to remove: ");

                        for (int i = 1; i < students.Count() + 1; i++)
                        {
                            Console.WriteLine($"{i}. {students[i - 1]}, Student Number: {students[i - 1].StudentNumber}.");
                        }

                        Console.WriteLine();
                        Console.Write("Type in the Student Number referring to the student you want to remove: ");

                        if (int.TryParse(Console.ReadLine().Trim(), out studentRemove) && students.Exists(x => x.StudentNumber == studentRemove))
                        {
                          for (int i = 0; i < students.Count(); i++)
                          {
                                if (studentRemove == students[i].StudentNumber)
                                {
                                    fName = students[i].FirstName;
                                    lName = students[i].LastName;
                                    students.Remove(students[i]);
                                }
                          }

                            Console.WriteLine($"{fName} {lName} has been kicked out of your class." );


                        }
                        else
                        {
                            Console.WriteLine("This Student Number does not exist please try again.");
                        }
                    }
                    else if (selection == 5)
                    {

                    }
                    else if (selection == 6)
                    {
                        Console.WriteLine();
                        Console.WriteLine("What would you like to edit from a student? ");
                        Console.WriteLine("1. The First Name of a Student");
                        Console.WriteLine("2. The Last Name of a Student");
                        Console.WriteLine("3. Reset the Student number of a Student");
                        Console.Write("Enter the integer corresponding with what you want to edit: ");

                        if (int.TryParse(Console.ReadLine(), out editSelection))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Your students include:");

                            for (int i = 0; i < students.Count() ; i++)
                            {
                                Console.WriteLine($"{students[i]} + Student Number: {students[i].StudentNumber}.");
                            }

                            Console.Write("Enter the Student number corresponding with your selection: ");
                            validInput = false;
                            while (!validInput)
                            {
                                if (int.TryParse(Console.ReadLine().Trim(), out studentEdit) && students.Exists(x => x.StudentNumber == studentEdit))
                                {
                                    validInput = true;

                                    for (int i = 0; i < students.Count(); i++)
                                    {
                                        if (studentEdit == students[i].StudentNumber)
                                        {
                                            studentIndex = i;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Write("Invalid student number, try again: ");
                                }
                            }


                            if (editSelection == 1)
                            {

                            }
                            else if (editSelection == 2)
                            {


                            }
                            else if (editSelection == 3)
                            {
                                students[studentIndex].ResetStudentNumber();
                                Console.WriteLine($"{students[studentIndex]}'s Student number has been remade, his new student number is: {students[studentIndex].StudentNumber}.");
                                
                                
                            }
                            else
                            {
                                Console.WriteLine("ERROR");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input invalid, try again.");
                        }
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



