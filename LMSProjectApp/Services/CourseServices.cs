using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem;

namespace MAUIProject1.Services
{
    public class CourseServices
    {
        public ObservableCollection<Course> Courses { get; private set; } = new ObservableCollection<Course>();

        private static CourseServices? _instance;

        public void Add(Course course)
        {
            BackDatabase.Courses.Add(course);
            Courses.Add(course);
        }

        public static CourseServices Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseServices();
                }
                return _instance;
            }
        }

        public Course? GetById(int courseId)
        {
            return BackDatabase.Courses.FirstOrDefault(p => p.courseId == courseId);
        }

        public void Remove(Course course)
        {
            BackDatabase.Courses.Remove(course);
            Courses.Remove(course);
        }

        public void AddStudentToCourse(Course course, Student student)
        {
            if (!course.studentList.Contains(student))
            {
                course.AddStudentToCourse(student, true);
            }
        }

        public void RemoveStudentFromCourse(Course course, Student student)
        {
            if (course.studentList.Contains(student))
            {
                course.RemoveStudentFromCourse(student);
            }
        }
    }
}
