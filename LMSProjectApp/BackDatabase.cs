using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    internal class BackDatabase
    {
        private static List<Student> people = new List<Student>();
        private static List<Course> courses = new List<Course>();
        public static List<Student> People { get { return people; } }

        public static List<Student> Student
        {
            get
            {
                return people;
            }
        }

        public static List<Course> Courses
        {
            get
            {
                return courses;
            }
        }
    }
}
