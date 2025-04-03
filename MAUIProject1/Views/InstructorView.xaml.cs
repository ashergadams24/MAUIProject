using MAUIProject1.ViewModels;

namespace MAUIProject1.Views;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewModel();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel).ResetView();
        (BindingContext as InstructorViewModel).RefreshView();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    //Toolbars
    private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel).ShowEnrollments();
    }

    private void Toolbar_CoursesClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel).ShowCourses();
    }

    //Course Functions
    private void AddCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel).AddCourseClick(Shell.Current);
    }

    private void EditCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel).EditCourseClick(Shell.Current);
    }

    private void RemoveCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel).RemoveCourseClick();
    }

    //Enrollment Functions
    private void AddEnrollmentClick(object sender, EventArgs e) 
    {
        (BindingContext as InstructorViewModel).AddEnrollmentClick(Shell.Current);
    }

    private void EditEnrollmentClick(object sender, EventArgs e) 
    {
        (BindingContext as InstructorViewModel).EditEnrollmentClick(Shell.Current);
    }

    private void RemoveEnrollmentClick(object sender, EventArgs e) 
    {
        (BindingContext as InstructorViewModel).RemoveEnrollmentClick();
    }


}