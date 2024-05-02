using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;
using MAUI.Canvas.ViewModels;
using Canvas.Services;

namespace MAUI.Canvas.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		
		var studentService = StudentService.Instance;

		BindingContext = new InstructorViewViewModel(studentService);
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void AddEnrollmentClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.AddClick(Shell.Current);
	}


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.RefreshView();
	}

	private void RemoveEnrollmentClick(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.RemoveClick();
	}

	private void EditEnrollmentClick(object sender, EventArgs args)
	{
		(BindingContext as InstructorViewViewModel).EditEnrollmentClick(Shell.Current);
	}

	

}
	

