using Microsoft.Maui.Controls;
using LearningManagementSystem;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MAUIProject1.Services;
using System.Collections.ObjectModel;

namespace MAUIProject1.ViewModels
{
    public partial class InstructorViewModel : INotifyPropertyChanged
    {
        public InstructorViewModel() {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
        }
        public ObservableCollection<Course> Courses => CourseServices.Current.Courses;
        public ObservableCollection<Student> Students => StudentServices.Current.Students;

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ResetView()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
        }

        public void RefreshView()
        {

            NotifyPropertyChanged(nameof(Student));
            NotifyPropertyChanged(nameof(Courses));
        }
        public bool IsEnrollmentsVisible
        {
            get; set;
        }

        public bool IsCoursesVisible
        {
            get; set;
        }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public Student SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }

        //Course Functions
        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseOptions?courseId=0");
        }

        public void EditCourseClick(Shell s)
        {
            var idParam = SelectedCourse?.courseId ?? 0;
            s.GoToAsync($"//CourseOptions?courseId={idParam}");
        }

        public void RemoveCourseClick()
        {
            if(SelectedCourse == null) { return; }

            CourseServices.Current.Remove(SelectedCourse);
            RefreshView();
        }

        //Enrollment Functions
        public void EditEnrollmentClick(Shell s)
        {
            var idParam = SelectedPerson?.studentId ?? 0;
            Shell.Current.GoToAsync($"//StudentOptions?studentId={idParam}");
        }

        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//StudentOptions?studentId=0");
        }

        public void RemoveEnrollmentClick()
        {
            if (SelectedPerson == null) { return; }

            StudentServices.Current.Remove(SelectedPerson);
            RefreshView();
        }
    }
}