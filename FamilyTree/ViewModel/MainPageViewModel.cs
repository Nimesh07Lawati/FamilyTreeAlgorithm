using FamilyTree.SqlLiteHelper;
using FamilyTree.Algorithm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FamilyTree.SqlliteModel;
using CommunityToolkit.Mvvm.Messaging;
using FamilyTree.SqlliteModel;

namespace FamilyTree.ViewModel;

public partial class MainPageViewModel : BindableObject
{

    private int _personId;
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    private int _fatherId;
    private string _fatherName;
    public string FatherName
    {
        get => _fatherName;
        set
        {
            _fatherName = value;
            OnPropertyChanged();
        }
    }

    private int _motherId;
    private string _motherName;
    public string MotherName
    {
        get => _motherName;
        set
        {
            _motherName = value;
            OnPropertyChanged();
        }
    }
    private int _wifeId;
    private string _wifeName;
    public string WifeName
    {
        get => _wifeName;
        set
        {
            _wifeName = value;
            OnPropertyChanged();
        }
    }

    private readonly DatabaseContext _database;
    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");
    public ICommand ButtonCLickedCommand { get; }
    public ICommand DeleteButtonCLickedCommand { get; }
    public ICommand GoToRelationPage { get; }
    public string SavedData;
    public MainPageViewModel()
    {
        _database = new DatabaseContext(dbPath);

        ButtonCLickedCommand = new Command(SavePersonCommand);
        GoToRelationPage = new Command(OnGoToRelationPageClicked);
        

    }
    private void SendFatherId()
    {
        WeakReferenceMessenger.Default.Send(new SharedProperties(FatherId)); 
    }
    public void OnGoToRelationPageClicked()
    {
        SendFatherId();
        Shell.Current.GoToAsync("///RelationPage");
     
    }
    public int PersonId
    {
        get => _personId;
        set { _personId = value; OnPropertyChanged(); }
    }

    public int FatherId
    {
        get => _fatherId;
        set { _fatherId = value; OnPropertyChanged(); }
    }

    public int MotherId
    {
        get => _motherId;
        set { _motherId = value; OnPropertyChanged(); }
    }

    public int WifeId
    {
        get => _wifeId;
        set { _wifeId = value; OnPropertyChanged(); }
    }
   
    public void SavePersonCommand()
    {
        try
        {
            if (PersonId == 0 || WifeId == 0 || MotherId == 0 || FatherId == 0)
            {
                Application.Current.MainPage.DisplayAlert("No", "The Fields are empty", "OK");
                return; // Exit the method early
            }


            var person = new Person
            {
                Id = PersonId,
                FatherId = FatherId,
                MotherId = MotherId,
                WifeId = WifeId,
                Name = Name,
                FatherName = FatherName, 
                MotherName = MotherName, 
                WifeName = WifeName
            };
           
            _database.SavePerson(person);
            PersonId = 0;
            FatherId = 0;
            MotherId = 0;
            WifeId = 0;
            FatherName=String.Empty;
            MotherName=String.Empty;
            WifeName = String.Empty;
            Application.Current.MainPage.DisplayAlert("Nice", "Saved in Database", "ok"); 
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Sorry", "Error Occured", "ok");
        }


    }

}
