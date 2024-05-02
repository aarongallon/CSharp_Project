using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Canvas.Services;
using Library.Canvas;

namespace MAUI.Canvas.ViewModels;

public class InstructorViewViewModel: INotifyPropertyChanged
{
    private StudentService _studentService;
    private ObservableCollection<Person> _people;

    // Constructor that accepts a StudentService instance
    public InstructorViewViewModel(StudentService studentService)
    {
        _studentService = studentService;
        _people = new ObservableCollection<Person>(_studentService.Students);
        NotifyPropertyChanged(nameof(People));
    }

    public ObservableCollection<Person> People
    {
        get
        {
            return new ObservableCollection<Person>(_studentService.Students);
        }

        private set
        {
            if (_people != value)
            {
                _people = value;
                NotifyPropertyChanged();
            }
        }
    }
    public Person SelectedPerson{get; set;}
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public void AddClick(Shell s)
    {
        var idParam = SelectedPerson?.Id ?? 0;
        s.GoToAsync($"//PersonDetail?personId={idParam}");
    }
    public void RefreshView()
    {
        NotifyPropertyChanged(nameof(People));
    }
    public void RemoveClick()
    {
        if(SelectedPerson == null) {return;}
        // Remove the selected person from the observable collection
        StudentService.Current.Remove(SelectedPerson);
        NotifyPropertyChanged(nameof(People));

        RefreshView();
    }

    public void EditEnrollmentClick(Shell s)
        {
            var idParam = SelectedPerson?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }

    public void AddEnrollmentClick(Shell s)
    {
        s.GoToAsync($"//PersonDetail?personId=0");
    }
    
}



