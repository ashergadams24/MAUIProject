using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MAUIProject1.Services;
using LearningManagementSystem;

namespace MAUIProject1.ViewModels
{
    public partial class StudentViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students => StudentServices.Current.Students;
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Student));
            }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                NotifyPropertyChanged(nameof(SelectedStudent));
                NotifyPropertyChanged(nameof(EnrolledCourses));
            }
        }


        public void DisplayDetails(Shell s)
        {
            var idParam = SelectedStudent?.studentId ?? 0;
            s.GoToAsync($"//CourseView?studentId={idParam}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Course> EnrolledCourses
        {
            get
            {
                if (SelectedStudent != null)
                {
                    return new ObservableCollection<Course>(SelectedStudent.GetEnrolledCourses());
                }
                else
                {
                    return new ObservableCollection<Course>();
                }
            }
        }

        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void RefreshView()
        {

            NotifyPropertyChanged(nameof(Student));
            NotifyPropertyChanged(nameof(Course));
        }
    }
}
