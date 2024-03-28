
using Canvas.Services;
using Library.Canvas;
using MAUI.Canvas.ViewModels;
using static Library.Canvas.Person;

namespace MAUI.Canvas.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
		BindingContext = new PersonDetailViewModel();
	}

	private void OkClick(object sender, EventArgs e)
    {
       var context = BindingContext as PersonDetailViewModel;
	   PersonClassification classification;
	   switch (context.ClassificationString)
	   {
		 case "S":
		 classification = PersonClassification. Senior;
         break;
		 case "J":
		 classification = PersonClassification. Junior;
	     break;
		 case "O":
		 classification = PersonClassification. Sophmore;
		 break;
		 case "F":
		 default:
         classification = PersonClassification. Freshman;
	    break;
        }
		var studentService = new StudentService();
		studentService.Add(new Person {Name = context.Name, Classification = classification});
		Shell.Current.GoToAsync("//MainPage");
	}
};