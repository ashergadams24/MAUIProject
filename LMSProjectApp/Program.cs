using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LearningManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            MasterCourse master = new MasterCourse();
            Course course = new Course(master);
            Student student = new Student(course);


            Console.WriteLine("Welcome to Canvas!\n");
            Student newStudent = null;

            while (!exit)
            {
                Console.WriteLine("Please make a selection from the following menu: ");
                Console.WriteLine("1. Create a Course"); //done
                Console.WriteLine("2. Create a Student"); //done
                Console.WriteLine("3. Add a Student to course roster"); //done
                Console.WriteLine("4. Remove a Student from course roster"); //done
                Console.WriteLine("5. Add a Module to a course"); //done
                Console.WriteLine("6. Add an Assignment to a course"); //done
                Console.WriteLine("7. List all courses"); //done
                Console.WriteLine("8. List all students"); //done
                Console.WriteLine("9. See a course's information"); //done
                Console.WriteLine("10. See a student's information"); //done
                Console.WriteLine("11. Update existing course"); //done
                Console.WriteLine("12. Update existing student"); //done
                Console.WriteLine("13. Exit program\n"); //done
                Console.WriteLine("Menu Selection: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": //Create a Course
                        Course newCourse = new Course(master); //passes course through Master class so that it can be added to list
                        newCourse.CreateCourse();
                        Console.WriteLine("\nAdded course " + newCourse.GetName + " " + newCourse.GetCode + '\n');
                        break;

                    case "2": //Create a Student
                        newStudent = new Student(course);
                        newStudent.CreateStudent();
                        master.studentList.Add(newStudent);
                        Console.WriteLine("\nCreated student " + student.GetName + " "  + '\n');
                        break;

                    case "3": // Add Student to Course
                        if (master.studentList.Count > 0)
                        {
                            Console.WriteLine("Existing Students:");
                            for (int i = 0; i < master.studentList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {master.studentList[i].GetName}");
                            }

                            Console.WriteLine("Enter the number of the student you want to add to a course: ");
                            if (int.TryParse(Console.ReadLine(), out int studentIndex) && studentIndex >= 1 && studentIndex <= master.studentList.Count)
                            {
                                Student selectedStudent = master.studentList[studentIndex - 1];

                                Console.WriteLine("Enter the course name to add the student to: ");
                                string courseNameToAdd = Console.ReadLine();

                                Course courseToAddStudent = master.GetCourseList()?.FirstOrDefault(c => c.GetName == courseNameToAdd);


                                if (courseToAddStudent != null)
                                {
                                    courseToAddStudent.AddStudentToCourse(selectedStudent, true);

                                }
                                else
                                {
                                    Console.WriteLine($"Course '{courseNameToAdd}' not found.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid student number.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existing students. Please create a student first before adding to a course.\n");
                        }
                        break;

                    case "4": // Remove Student From Course
                        if (master.studentList.Count > 0)
                        {
                            Console.WriteLine("Existing Students:");
                            for (int i = 0; i < master.studentList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {master.studentList[i].GetName}");
                            }

                            Console.WriteLine("Enter the number of the student you want to remove from a course: ");
                            if (int.TryParse(Console.ReadLine(), out int studentIndex) && studentIndex >= 1 && studentIndex <= master.studentList.Count)
                            {
                                Student selectedStudent = master.studentList[studentIndex - 1];

                                Console.WriteLine("Enter the course name to remove the student from: ");
                                string courseNameToRemoveStudent = Console.ReadLine();

                                Course courseToRemoveStudent = master.GetCourseList()?.FirstOrDefault(c => c.GetName == courseNameToRemoveStudent);

                                if (courseToRemoveStudent != null)
                                {
                                    courseToRemoveStudent.RemoveStudentFromCourse(selectedStudent);
                                }
                                else
                                {
                                    Console.WriteLine($"Course '{courseNameToRemoveStudent}' not found.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid student number.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existing students. Please create a student first before removing from a course.\n");
                        }
                        break;

                    case "5": //Create Module
                        Modules module = new Modules();
                        module.CreateModule();
                        master.AddModule(module);
                        break;

                    case "6": //Add an Assignment
                        Assignment assignment = new Assignment();
                        assignment.CreateAssignment();
                        master.AddAssignment(assignment);
                        break;

                    case "7": //Print all Courses
                        Console.WriteLine("Course List: \n");
                        master.PrintCourseList();
                        break;

                    case "8": //Print all Students
                        Console.WriteLine("Student List: \n");
                        course.PrintStudentList();
                        break;

                    case "9": //Search for a Course
                        master.CourseSearch();
                        break;

                    case "10": //Search for a Student
                        course.StudentSearch();
                        break;

                    case "11": //Update existing Course
                        master.UpdateCourse();
                        break;

                    case "12": //Update existing Student
                        course.UpdateStudent();
                        break;

                    case "13": //Exit
                        Console.WriteLine("Exiting program. Thank you!");
                        exit = true;
                        break;


                    default: //Error check
                        Console.WriteLine("Invalid choice. Please select a valid menu option.");
                        break;
                }
            }
        }
    }
}
