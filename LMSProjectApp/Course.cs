using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LearningManagementSystem
{
    public class Course : INotifyPropertyChanged
    {
        //private string _courseName;
        public int courseId {  get; set; }
        //private string _Prefix;
        private static int lastId = 0;
        public string courseName
        {
            get; set;
        }

        public string Prefix
        {
            get; set;
        }

        //private string _courseCode;
        public string courseCode
        {
            get; set;
        }

        //private string _courseDescription;
        public string courseDescription
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string DisplayCourseName => $"{courseName} - {courseCode}";
        public List<Student>? studentList;
        private List<Modules>? moduleList;
        private List<Assignment>? assignmentList;
        MasterCourse masterCourse;

        public Course(MasterCourse masterCourse)
        {
            this.masterCourse = masterCourse;
            studentList = new List<Student>();
            moduleList = new List<Modules>();
            assignmentList = new List<Assignment>();
            lastId++;
            courseId = lastId;
        }

        public Course()
        {
            studentList = new List<Student>();
            moduleList = null;
            assignmentList = null;
            Prefix = string.Empty;
            courseName = string.Empty;
            courseCode = string.Empty;
            courseDescription = string.Empty;
            lastId++;
            courseId = lastId;
        }

        public List<Student>? GetStudentList()
        {
            return studentList;
        }

        public List<Modules>? GetModuleList()
        {
            return moduleList;
        }

        public List<Assignment>? GetAssignmentList()
        {
            return assignmentList;
        }


        public string? GetCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string? GetName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public string? GetDescription
        {
            get { return courseDescription; }
            set { courseDescription = value; }
        }

        public void CreateCourse()
        {
            Console.WriteLine("Enter Course Name: ");
            courseName = Console.ReadLine();

            Console.WriteLine("Enter Course Code: ");
            courseCode = Console.ReadLine();

            Console.WriteLine("Enter Course Description: ");
            courseDescription = Console.ReadLine();

            masterCourse.AddCourse(this);
        }



        public void StudentSearch()
        {
            Console.WriteLine("Enter Student First, Last, or Full Name: ");
            var search = Console.ReadLine();
            bool studentFound = false;

            foreach (var student in studentList)
            {
                if (student.GetName == search) //passes search if first, last, or "FirstName LastName" matches existing student
                {
                    Console.WriteLine("\nStudent successfully found \n" + student.GetName + " " + "\n\tClassification: " + student.GetYear + "\n\tGrades: " + student.GetGrades + "\n");

                    List<Course> enrolledCourses = student.GetEnrolledCourses();

                    if (enrolledCourses.Count > 0)
                    {
                        Console.WriteLine("\tEnrolled Courses:");
                        foreach (var course in enrolledCourses)
                        {
                            Console.WriteLine("\t\t" + course.GetName + course.GetCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tNo enrolled courses.");
                    }

                    studentFound = true;
                }
            }

            if (!studentFound)
            {
                Console.WriteLine("Student unable to be located.\n");
            }
        }


        public void UpdateStudent()
        {
            Console.WriteLine("Enter First or Last Name of the Student you want to update: ");
            var search = Console.ReadLine();
            bool courseFound = false;
            foreach (var student in studentList)
            {
                if (student.GetName == search)
                {
                    courseFound = true;
                    Console.WriteLine("Enter Updated Student First Name: ");
                    student.GetName = Console.ReadLine();
                    Console.WriteLine("Enter Updated Student Last Name: ");
                    Console.WriteLine("Enter Updated Student Classification: ");
                    student.GetYear = Console.ReadLine();
                    Console.WriteLine("Enter Updated Student Grades: ");
                    student.GetGrades = Console.ReadLine();

                    Console.WriteLine(student.GetName + " " + " was updated successfully.");

                }

            }
            if (!courseFound) { Console.WriteLine("Student not found."); }
        }

        public void AddStudentToCourse(Student student, bool printMessage)
        {
            studentList.Add(student);
            student.AddEnrolledCourse(this);
            if (printMessage == true)
            {
                Console.WriteLine($"{student.GetName} added to {courseName} {courseCode}\n");
            }
        }

        public void RemoveStudentFromCourse(Student student)
        {
            if (studentList.Contains(student))
            {
                studentList.Remove(student);
                student.RemoveEnrolledCourse(this);
                student.AddEnrolledCourse(this);
                Console.WriteLine($"{student.GetName} removed from {courseName}\n");
            }
            else
            {
                Console.WriteLine($"{student.GetName} is not enrolled in {courseName}\n");
            }
        }

        public int GetCourseID
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public override string ToString()
        {
            return $"[{courseId}] {Prefix} - {courseName}";
        }

        
        public void PrintStudentList()
        {
            foreach (Student student in studentList)
            {
                Console.WriteLine(student.GetName + " "+ "\n");
            }
        }

    }
}
