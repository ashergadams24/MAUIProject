using LearningManagementSystem;
using MAUIProject1.Services;
using MAUIProject1.ViewModels;

namespace MAUIProject1.Views;


[QueryProperty(nameof(CourseID), "courseId")]
public partial class CourseOptionsView : ContentPage
{
	public CourseOptionsView()
	{
		InitializeComponent();
        BindingContext = new CourseOptionsViewModel();
    }

    public int CourseID { get; set; }  

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private async void OnAddCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseOptionsViewModel).AddCourse(Shell.Current);
        var viewModel = BindingContext as CourseOptionsViewModel;
        await DisplayAlert("Success", $"Course {viewModel.Name} added successfully.", "OK");

    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseOptionsViewModel(CourseID);
    }
}