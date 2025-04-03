using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class MasterCourse
    {
        Course course = new Course();
        public List<Course> courseList = new List<Course>();
        public List<Student> studentList = new List<Student>();


        public List<Course>? GetCourseList()
        {
            return courseList;
        }

        public void AddCourse(Course course)
        {
            courseList.Add(course); //updates with each time case 1 (CreateCourse) is run
        }

        public void PrintCourseList()
        {
            foreach (Course course in courseList)
            {
                Console.WriteLine("\t" + course + "\n");
            }
        }

        public void CourseSearch()
        {
            Modules modules = new Modules();
            Assignment assignments = new Assignment();
            Student students = new Student();

            Console.WriteLine("Enter Course Name or Code: ");
            var search = Console.ReadLine();
            bool courseFound = false;
            foreach (var course in courseList)
            {
                if (course.GetCode == search || course.GetName == search || search == course.GetName + " " + course.GetCode || search == course.GetName + course.GetCode)
                { //if statement condition checks if entered code, name, "Name Code" or "NameCode" matches existing value 
                    Console.WriteLine("Course successfully found \n" + course + "\n");

                    List<Modules>? moduleList = course.GetModuleList();
                    List<Assignment>? assignmentList = course.GetAssignmentList();
                    List<Student>? studentList = course.GetStudentList();

                    if (modules != null && moduleList.Count > 0)
                    {
                        Console.WriteLine("\tModules: ");
                        foreach (var module in moduleList)
                        {
                            Console.WriteLine("\t\t" + module.GetName + ": " + module.GetDescription);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tNo modules in this course.");
                    }

                    if (assignments != null && assignmentList.Count > 0)
                    {
                        Console.WriteLine("\tAssignments: ");
                        foreach (var assignment in assignmentList)
                        {
                            Console.WriteLine("\t\t" + assignment.GetAssgnName + ": " + assignment.GetAssgnDescription + "\n\t\tTotal Points Available: " + assignment.GetTAP + "\n\t\tDue Date: " + assignment.GetDueDate);
                        }
                    }
                    else { Console.WriteLine("\tNo assignments in this course."); }

                    if(students != null && studentList.Count > 0)
                    {
                        Console.WriteLine("\tStudents in Course: ");
                        foreach (var student in studentList)
                        {
                            Console.WriteLine("\t\t" + student.GetName + " " + "\n");
                        }
                    }
                    else { Console.WriteLine("\tNo students in this course.");  }
                    courseFound = true;

                }
                if(!courseFound)  
                {
                    Console.WriteLine("No course matching description.\n");
                }
            }
        }
        
        public void AddModule(Modules module)
        {
            Console.WriteLine("Enter Name or Code of the Course you want to add the Module to: ");
            var search = Console.ReadLine();
            bool courseFound = false;

            foreach (var course in courseList)
            {
                if (course.GetName == search || course.GetCode == search || course.GetName + " " + course.GetCode == search)
                {
                    courseFound = true;
                    course.GetModuleList()?.Add(module);
                    Console.WriteLine(module.GetName + " added to " + course.GetName + "\n");
                    break; 
                }
            }

            if (!courseFound)
            {
                Console.WriteLine("Course not found.");
            }
        }

        public void AddAssignment(Assignment assignment)
        {
            Console.WriteLine("Enter Name or Code of the Course you want to add the Assignment to: ");
            var search = Console.ReadLine();
            bool courseFound = false;

            foreach (var course in courseList)
            {
                if (course.GetName == search || course.GetCode == search || course.GetName + " " + course.GetCode == search)
                {
                    courseFound = true;
                    course.GetAssignmentList()?.Add(assignment);
                    Console.WriteLine(assignment.GetAssgnName + " added to " + course.GetName + "\n");
                    break;
                }
            }

            if (!courseFound)
            {
                Console.WriteLine("Course not found.");
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Enter Name or Code of the Course you want to update: ");
            var search = Console.ReadLine();
            bool courseFound = false;
            foreach (var course in courseList)
            {
                if (course.GetName == search || course.GetCode == search || course.GetName + " " + course.GetCode == search)
                {
                    courseFound = true;
                    Console.WriteLine("Enter Updated Course Name: ");
                    course.GetName = Console.ReadLine();
                    Console.WriteLine("Enter Updated Course Code: ");
                    course.GetCode = Console.ReadLine();
                    Console.WriteLine("Enter Updated Course Description: ");
                    course.GetDescription = Console.ReadLine();
                    Console.WriteLine(course.GetName + " " + course.GetCode + " was updated successfully.\n");

                }
                if (!courseFound) { Console.WriteLine("Course not found."); }
            }
        }
    }
}
