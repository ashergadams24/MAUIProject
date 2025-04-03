using LearningManagementSystem;
using MAUIProject1.ViewModels;
using System.Collections.ObjectModel;

namespace MAUIProject1.Views;

public partial class CourseView : ContentPage
{
	public CourseView()
    {
		InitializeComponent();
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }
}