using FamilyTree.SqlLiteHelper;
using System.Windows.Input;
using FamilyTree.SqlliteModel;
using FamilyTree.Algorithm.SearchAlgorithm;
using System.Collections.ObjectModel;
using FamilyTree.RelationDefinition;

namespace FamilyTree.ViewModel;

public partial class FirstPersonViewModel : BindableObject
{
    private readonly DatabaseContext _database;
	private int _firstPersonId;
    private int _firstPersonFatherId;
    private int _firstPersonMotherId;
	private string _firstPersonName;
	private string _firstPersonFatherName;
	private string _firstPersonMotherName;
    private int _searchId;
    public int SearchId
    {
        get => _searchId;
        set {
            _searchId = value;
            OnPropertyChanged();
        }
    }

	public  int FirstPersonId { get => _firstPersonId; 
        set
        {
            _firstPersonId = value;
            OnPropertyChanged();
        }
    }
    public int FirstPersonFatherId
    {
        get => _firstPersonFatherId; set
        {
            _firstPersonFatherId = value;
            OnPropertyChanged();
        }
    }
    public int FirstPersonMotherId
    {
        get => _firstPersonMotherId; set
        {
            _firstPersonMotherId = value;
            OnPropertyChanged();
        }
    }
    public string FirstPersonName
    {
        get => _firstPersonName; set
        {
            _firstPersonName = value;
            OnPropertyChanged();
        }
    }
    public string FirstPersonFatherName
    {
        get => _firstPersonFatherName; set
        {
            _firstPersonFatherName = value;
            OnPropertyChanged();
        }
    }
    public string FirstPersonMotherName
    {
        get => _firstPersonMotherName; set
        {
            _firstPersonMotherName = value;
            OnPropertyChanged();
        }
    }
    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");
    public ICommand AddButtonCLickedCommand { get; set; }
    public ICommand ShowDataClickedCommand { get; set; }
    public ICommand ShowRelationCommand { get; set; }
    public ICommand DeleteAllCommand { get; set; }
    public ObservableCollection<FirstPerson> FirstPersonList {  get; set; }
    private readonly FirstPersonSearchAlgorithm _algorithm;
    public FirstPersonViewModel()
	{
        AddButtonCLickedCommand = new Command(OnAddButtonClicked);
        ShowDataClickedCommand = new Command(OnShowDataClicked);
        ShowRelationCommand = new Command(OnShowRelationCommandClicked);
        DeleteAllCommand = new Command(OnDeleteAllCommandClicke);
        FirstPersonList = new ObservableCollection<FirstPerson>();
        _database=new DatabaseContext(dbPath); 
        _algorithm = new FirstPersonSearchAlgorithm();
		
	}
    public void OnDeleteAllCommandClicke()
    {
        try
        {
            
           
            _database.DeleteAllFirstPerson();
            Application.Current.MainPage.DisplayAlert("ok", " deleted all  ", "yes");
            FirstPersonList.Clear();

        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("ok", "cant Delte it ", "Ok");
        }
        
    }
    public  void OnShowRelationCommandClicked()
    {
        // Fetch the person using the SearchId or FirstPersonId
        var firstPerson = _database.GetFirstPersonById(10);

        if (firstPerson == null)
        {
            Application.Current.MainPage.DisplayAlert("Not Found", "Person not found.", "OK");
            return;
        }
        int personId = firstPerson.Id ?? -1;
        var relationships = new List<RelationshipResult>();
        relationships = _algorithm.GetPersonWithRelationships(personId, "Self", relationships);

        var message = "";
        foreach (var relation in relationships)
        {
            message += $"{relation.RelationshipName}: {relation.Person.Name}\n";
        }

       
        Application.Current.MainPage.DisplayAlert("Family Relationships", message, "OK");
    }

    public void OnShowDataClicked()
    {
        var allperson=_database.GetAllFirstPerson();
        try
        {
            FirstPersonList.Clear();
            foreach (var data in allperson)
            {
                FirstPersonList.Add(data);
            }
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Sorry", "The data couldnt load", "ok");
        }
    }
	public void OnAddButtonClicked()
    {
        try
        {
            var firstPerson = new FirstPerson
            {
                Id = FirstPersonId,
                Name = FirstPersonName,
                FatherId = FirstPersonFatherId,
                FatherName = FirstPersonMotherName,
                MotherId = FirstPersonMotherId,
                MotherName = FirstPersonMotherName,
            };
            _database.SaveFirstPerson(firstPerson);
            Application.Current.MainPage.DisplayAlert("Success","Database Saved SuccessFully","ok");
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Sorry ", "We couldnt save the database ", "ok");
        }
		
	}
}