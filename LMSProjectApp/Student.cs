using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class Student
    {
        public string? studentName { get; set; }
        public string? studentYear { get; set; }
        public PersonClassification Classification { get; set; }
        private string? studentGrades { get; set; }
        public int studentId { get; set; }


        Course course;
        private List<Course> enrolledCourses;

        public Student(Course course)
        {
            this.course = course;
            enrolledCourses = new List<Course>();
        }

        private static int LastId = 0;

        public Student()
        {
            studentName = string.Empty;
            studentName = string.Empty;
            studentYear = string.Empty;
            studentGrades = string.Empty;
            studentId = ++LastId;
        }

        public List<Course> GetEnrolledCourses()
        {
            return enrolledCourses;
        }

        public void AddEnrolledCourse(Course course)
        {
            if (enrolledCourses == null)
            {
                enrolledCourses = new List<Course>();
            }

            enrolledCourses.Add(course);
        }


        public void RemoveEnrolledCourse(Course course)
        {
            enrolledCourses.Remove(course);
        }

        public string? GetName
        {
            get { return studentName; }
            set { studentName = value; }
        }


        public string? GetYear
        {
            get { return studentYear; }
            set { studentYear = value; }
        }

        public string? GetGrades
        {
            get { return studentGrades; }
            set { studentGrades = value; }
        }                

        public int GetID
        {
            get { return studentId; } set { studentId = value; }
        }

        public void CreateStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            studentName = Console.ReadLine();
            Console.WriteLine("Enter Student Classification (freshman, sophomore, etc.): ");
            studentYear = Console.ReadLine();
            Console.WriteLine("Enter Student Grades: ");
            studentGrades = Console.ReadLine();

            course.AddStudentToCourse(this, false);
        }


        public override string ToString()
        {
            return $" [ " + studentId + " ] " + studentName + " - " + Classification;
        }

        public enum PersonClassification
        {
            Freshman, Sophomore, Junior, Senior
        }
    }
}
