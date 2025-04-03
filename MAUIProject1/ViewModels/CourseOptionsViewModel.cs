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

        public ObservableCollection<Student> EnrolledStudents { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Student> NotEnrolledStudents
        {
            get
            {
                var all = StudentServices.Current.Students;
                return new ObservableCollection<Student>(all.Except(EnrolledStudents));
            }
        }

        public int ID { get; set; }

        public void AddCourse(Shell s)
        {
            if (ID <= 0)
            {
                var course = new Course
                {
                    courseName = Name,
                    Prefix = Prefix,
                    courseDescription = Description
                };
                foreach (var student in EnrolledStudents)
                {
                    course.AddStudentToCourse(student, false);
                }
                CourseServices.Current.Add(course);
            }
            else
            {
                var refToUpdate = CourseServices.Current.GetById(ID);
                if (refToUpdate != null)
                {
                    refToUpdate.courseName = Name;
                    refToUpdate.Prefix = Prefix;
                    refToUpdate.courseDescription = Description;
                    refToUpdate.GetStudentList()?.Clear();

                    foreach (var student in EnrolledStudents)
                    {
                        refToUpdate.AddStudentToCourse(student, false);
                    }
                }
            }

            Shell.Current.GoToAsync("//Instructor");
        }

        public void LoadById(int id)
        {
            if (id == 0) return;

            var course = CourseServices.Current.GetById(id);
            if (course != null)
            {
                Name = course.courseName;
                Description = course.courseDescription;
                Prefix = course.Prefix;
                ID = course.courseId;

                EnrolledStudents = new ObservableCollection<Student>(course.GetStudentList() ?? new List<Student>());
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Prefix));
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
        }

        public Command<Student> EnrollStudentCommand => new Command<Student>((student) =>
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
                NotifyPropertyChanged(nameof(EnrolledStudents));
                NotifyPropertyChanged(nameof(NotEnrolledStudents));
            }
        });

        public Command<Student> UnenrollStudentCommand => new Command<Student>((student) =>
        {
            if (EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Remove(student);
                NotifyPropertyChanged(nameof(EnrolledStudents));
                NotifyPropertyChanged(nameof(NotEnrolledStudents));
            }
        });

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
