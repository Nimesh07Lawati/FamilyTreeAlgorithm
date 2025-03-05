using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FamilyTree.ViewModel;

public class MainPageViewModel : BindableObject
{
    private readonly DataBaseHelper _dataBaseHelper;

    public MainPageViewModel()
    {
        _dataBaseHelper = new DataBaseHelper();
        SubmitCommand = new Command(OnSubmitClicked);
        DirectRelationCommand = new Command(OnDirectRelationClicked);
    }

    private int _personEntityID;
    public int PersonEntityID
    {
        get => _personEntityID;
        set
        {
            if (_personEntityID != value)
            {
                _personEntityID = value;
                OnPropertyChanged();
            }
        }
    }

    private string _personName;
    public string PersonName
    {
        get => _personName;
        set
        {
            if (_personName != value)
            {
                _personName = value;
                OnPropertyChanged();
            }
        }
    }

    private string _gender;
    public string Gender
    {
        get => _gender;
        set
        {
            if (_gender != value)
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
    }

    private string _dateOfBirth;
    public string DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (_dateOfBirth != value)
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }
    }

    private string _addressOfPerson;
    public string AddressOfPerson
    {
        get => _addressOfPerson;
        set
        {
            if (_addressOfPerson != value)
            {
                _addressOfPerson = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand SubmitCommand { get; }
    public ICommand DirectRelationCommand { get; }

    private void OnSubmitClicked()
    {
        try
        {
            Application.Current.MainPage.DisplayAlert("Hurray", "It is not working", "OK");
            var personEntity = new PersonEntity
            {
                PersonEntityId = PersonEntityID,
                PersonName = PersonName,
                Gender = Gender,
                BirthDate = DateOfBirth,
                PersonAddress = AddressOfPerson
            };
            _dataBaseHelper.InsertPerson(personEntity);
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Sorry", "It is not working", "OK");
        }
    }

    private void OnDirectRelationClicked()
    {
        Application.Current.MainPage.DisplayAlert("ok", "ok", "ok");
    }
}
