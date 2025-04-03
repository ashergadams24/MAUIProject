using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem;
using MAUIProject1.Services;

namespace MAUIProject1.ViewModels
{
    class CourseOptionsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> AvailableStudents => StudentServices.Current.Students;
        //public Student SelectedStudent { get; set;}

        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Student));
                NotifyPropertyChanged(nameof(Course));
            }
        }

        private Course course;
        public CourseOptionsViewModel(int Id = 0) {
            
            if (Id > 0)
            {
                LoadById(Id);
            }
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }
        
        public string Prefix
        {
            get; set;
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description} + " +
                    $"Announcements:\n" +
                    $"Roster:\n" +
                    $"Assignments:\n" +
                    $"Modules:\n";

            }
        }

        public int ID { get; set; }

        public void AddCourse(Shell s)
        {
            if (ID <= 0)
            {
                CourseServices.Current.Add(new Course { courseName = Name, Prefix = Prefix, courseDescription = Description });
            }
            else
            {
                var refToUpdate = CourseServices.Current.GetById(ID) as Course;
                refToUpdate.courseName = Name;
                refToUpdate.Prefix = Prefix;
                refToUpdate.courseDescription = Description;
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var course = CourseServices.Current.GetById(id) as Course;
            if (course != null)
            {
                Name = course.courseName;
                Description = course.courseDescription;
                Prefix = course.Prefix;
                ID = course.courseId;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Prefix));
        }

        /*
        public void AddStudentToCourse(Student student)
        {
            if (!SelectedStudents.Contains(student))
            {
                SelectedStudents.Add(student);
                CourseServices.Current.AddStudentToCourse(course, student);
            }
        }

        public void RemoveStudentFromCourse(Student student)
        {
            if (SelectedStudents.Contains(student))
            {
                SelectedStudents.Remove(student);
                CourseServices.Current.RemoveStudentFromCourse(course, student);
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {

            NotifyPropertyChanged(nameof(Student));
            NotifyPropertyChanged(nameof(Course));
        }
    }
}
