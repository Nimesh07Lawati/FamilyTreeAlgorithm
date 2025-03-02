using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using FamilyTree.Algorithm.SearchAlgorithm;
using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
namespace FamilyTree.ViewModel;

public partial class RelationPageViewModel : BindableObject
{
    private readonly PersonWithRelationShip _personSearch;
    private int FatherId;
    private int _searchEntity {  get; set; }
    public int SearchEntity
    {
        get => _searchEntity;
        set
        {
            _searchEntity = value; OnPropertyChanged();
        }
    }
    public ICommand RelationCommand { get; set; }
    public ICommand ShowAssociatedRelationCommand { get; set; }
    public ICommand DeleteButtonCLickedCommand { get; set; }
    public ICommand FindRelationshipCommand { get; set; }
    public ICommand BackButtonCLickedCommand { get; set; }
    public ObservableCollection<Person> People { get; set; }
    public ObservableCollection<Person> People1{ get; set; }
    private readonly DatabaseContext _database;
    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "familytree.db");
    public RelationPageViewModel()
    {
        _database = new DatabaseContext(dbPath);
        People = new ObservableCollection<Person>();
        People1 = new ObservableCollection<Person>();
        _personSearch = new PersonWithRelationShip();
        DeleteButtonCLickedCommand = new Command(OnDeleteClicked);
        BackButtonCLickedCommand = new Command(OnBackButtonClicked);
        FindRelationshipCommand = new Command(OnFindRelationshipButtonClicked);
        ShowAssociatedRelationCommand = new Command(OnShowAssociatedRelationButtonClicked);

    }
    private void OnFindRelationshipButtonClicked()
    {
        try
        {

            var grandfather = _database.GetPersonById(10);
            if (grandfather != null)
            {
                Application.Current.MainPage.DisplayAlert("ok", "Found", "ok");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("No No", "Not Found", "ok");
            }
        }
        catch (Exception ex)
        {
            // Log or display the actual error message for debugging
            Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
    public void OnShowAssociatedRelationButtonClicked()
    {
        try
        {
            if (SearchEntity <= 0)
                Application.Current.MainPage.DisplayAlert("No Man", "Please Enter Valid Entry", "ok");
          
            var person = _personSearch.GetPersonWithRelationships(SearchEntity, null);

            if (person != null)
            {
                // Person exists
                Application.Current.MainPage.DisplayAlert("Success", "Person exists in the database.", "OK");

                // Display the person's relationships
                DisplayPersonRelationships(person);
            }
            else
            {
                // Person doesn't exist
                Application.Current.MainPage.DisplayAlert("Not Found", "Person does not exist in the database.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Log the full exception for debugging
            Console.WriteLine($"Error: {ex.ToString()}");

            // Show a user-friendly error message
            Application.Current.MainPage.DisplayAlert("Error", "An error occurred while retrieving person details. Please try again.", "OK");
        }
    }

    private void DisplayPersonRelationships(Person person)
    {
        if (person == null) return;

        // Initialize the string builder to hold all relationships information
        var relationships = new StringBuilder();

        // Add the main person's details
        relationships.AppendLine($"Name: {person.Name} (ID: {person.Id})");

        // Add the Father's details (If available)
        if (person.Father != null)
        {
            relationships.AppendLine($"Father: {person.Father.Name} (ID: {person.Father.Id})");
            // Recursively add Father's relationships if needed
            if (person.Father.Father != null)
                relationships.AppendLine($"  Grandfather (Father's side): {person.Father.Father.Name}");
            if (person.Father.Mother != null)
                relationships.AppendLine($"  Grandmother (Father's side): {person.Father.Mother.Name}");
        }
        else
            relationships.AppendLine("Father: Not available");

        // Add the Mother's details (If available)
        if (person.Mother != null)
        {
            relationships.AppendLine($"Mother: {person.Mother.Name} (ID: {person.Mother.Id})");
            // Recursively add Mother's relationships if needed
            if (person.Mother.Father != null)
                relationships.AppendLine($"  Grandfather (Mother's side): {person.Mother.Father.Name}");
            if (person.Mother.Mother != null)
                relationships.AppendLine($"  Grandmother (Mother's side): {person.Mother.Mother.Name}");
        }
        else
            relationships.AppendLine("Mother: Not available");

        // Add the Wife's details (If available)
        if (person.Wife != null)
            relationships.AppendLine($"Wife: {person.Wife.Name} (ID: {person.Wife.Id})");
        else
            relationships.AppendLine("Wife: Not available");

        // Show the relationships in an alert
        Application.Current.MainPage.DisplayAlert("Person Details", relationships.ToString(), "OK");
    }



    public void OnBackButtonClicked()
    {
        Shell.Current.GoToAsync("///MainPage");
    }
    public void OnDeleteClicked()
    {
        try
        {
            if (_database != null)
            {
                var people = _database.GetAllPeople();

                if (people.Count > 0)
                {
                    _database.DeleteAllPeople();
                    People.Clear();  // Clear the ObservableCollection after deletion
                    Application.Current.MainPage.DisplayAlert("Yes", "Deleted All !!", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("No", "Database is already empty, man!", "OK");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Database connection is null!", "OK");
            }
        }
        catch (Exception ex)
        {
            Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
    public void OnShowDataClicked()
    {
        try
        {
            People.Clear();
            var data = _database.GetAllPeople();
            foreach (var human in data)
            {
                People.Add(human);
            }
        }
        catch
        {
            Application.Current.MainPage.DisplayAlert("Sorry", "Something Wrong", "ok");
        }
    }

  


}