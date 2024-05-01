
using System.Security.Cryptography;
using Canvas.Services;
using Library.Canvas;
using MAUI.Canvas.ViewModels;
using static Library.Canvas.Person;

namespace MAUI.Canvas.Views;

[QueryProperty(nameof(PersonId), "personId")]

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
		
		BindingContext = new PersonDetailViewModel();
	}
	public int PersonId { set; get; }

	private void OkClick(object sender, EventArgs e)
	{
		(BindingContext as PersonDetailViewModel).AddPerson();
	}
	// private void OkClick(object sender, EventArgs e)
    // {
    //    var context = BindingContext as PersonDetailViewModel;
	//    PersonClassification classification;
	//    switch (context.ClassificationString)
	//    {
	// 	 case "S":
	// 	 classification = PersonClassification. Senior;
    //      break;
	// 	 case "J":
	// 	 classification = PersonClassification. Junior;
	//      break;
	// 	 case "O":
	// 	 classification = PersonClassification. Sophmore;
	// 	 break;
	// 	 case "F":
	// 	 default:
    //      classification = PersonClassification. Freshman;
	//     break;
    //     }
	// 	var studentService = StudentService.Instance;
	// 	studentService.Add(new Person {Name = context.Name, Classification = classification});
	// 	Shell.Current.GoToAsync("//Instructor");
	// }
	private void OnArriving(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new PersonDetailViewModel(PersonId);
	}
	private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = null;
    }
	private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
	
};