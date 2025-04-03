using LearningManagementSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIProject1.ViewModels
{
    class CourseViewModel
    {
        public Student SelectedStudent { get; set; }
        public ObservableCollection<Course> EnrolledCourses { get; set; }

        public CourseViewModel(Student student)
        {
            SelectedStudent = student;
            EnrolledCourses = new ObservableCollection<Course>(student.GetEnrolledCourses());
        }

    }
}
