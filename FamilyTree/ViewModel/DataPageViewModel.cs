using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FamilyTree.ViewModel;

public partial class DataPageViewModel : BindableObject
{
	private readonly DataBaseHelper _dataBaseHelper;
	public ICommand GoBackCommand { get; }
	public ObservableCollection<PersonEntity> PersonEntities { get; set; }
    public ObservableCollection<DirectRelation> DirectRelations { get; set; }
    public ObservableCollection<IndirectRelation> IndirectRelations { get; set; }
    public DataPageViewModel()
	{
		GoBackCommand = new Command(OnGoBackClicked);
		PersonEntities= new ObservableCollection<PersonEntity>();
		_dataBaseHelper = new DataBaseHelper();
		DirectRelations= new ObservableCollection<DirectRelation>();
		IndirectRelations= new ObservableCollection<IndirectRelation>();
	}
	private void OnGoBackClicked()
	{
		Shell.Current.GoToAsync("///MainPage");
	}
	private void OnShowEntitesClicked()

	{
		PersonEntities.Clear();
		var entities=_dataBaseHelper.GetAllPersons();
		foreach (var entity in entities)
		{
			PersonEntities.Add(entity);
		}
	}
    private void OnShowDirectRelationClicked()

    {
       DirectRelations.Clear();
        var entities = _dataBaseHelper.GetAllDirectRelations();
        foreach (var entity in entities)
        {
            DirectRelations.Add(entity);
        }
    }
    private void OnShowInDirectRelationClicked()

    {
        IndirectRelations.Clear();
        var entities = _dataBaseHelper.GetAllIndirectRelations();
        foreach (var entity in entities)
        {
            IndirectRelations.Add(entity);
        }
    }
}