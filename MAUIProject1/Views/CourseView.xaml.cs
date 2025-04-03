using MAUIProject1.ViewModels;
using LearningManagementSystem;

namespace MAUIProject1.Views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class CourseView : ContentPage
{
    private Student student;

    public CourseView()
    {
        InitializeComponent();
    }

    public int StudentId
    {
        get => 0;
        set
        {
            student = StudentServices.Current.GetById(value);
            if (student != null)
            {
                BindingContext = new CourseViewModel(student);
            }
        }
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }
}
