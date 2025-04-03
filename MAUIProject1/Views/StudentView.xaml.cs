/*
 Add:
1. When student is selected, view courses student is in
2. Student can select course and view assignments or modules
3. Assignments show due dates
4. Student can submit assignments
 */

using MAUIProject1.ViewModels;

namespace MAUIProject1.Views;

public partial class StudentView : ContentPage
{
    public StudentView()
    {
        InitializeComponent();
        BindingContext = new StudentViewModel();
    }

    private async void DisplayDetailsClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as StudentViewModel;
        if (viewModel.SelectedStudent != null)
        {
            (BindingContext as StudentViewModel).DisplayDetails(Shell.Current);
        }
        else { await DisplayAlert("Error", "No student selected", "OK"); }
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

}