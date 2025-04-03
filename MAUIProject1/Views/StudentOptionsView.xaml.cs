using LearningManagementSystem;
using MAUIProject1.Services;
using MAUIProject1.ViewModels;
using System.Collections.Generic;

namespace MAUIProject1.Views;

[QueryProperty(nameof(PersonId), "studentId")]

public partial class StudentOptionsView : ContentPage
{
    public StudentOptionsView()
    {
        InitializeComponent();
    }

    public int PersonId
    {
        set; get;
    }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as StudentOptionsViewModel).AddPerson();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentOptionsViewModel(PersonId);
    }
}

