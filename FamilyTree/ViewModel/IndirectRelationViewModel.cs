using FamilyTree.SqlLiteHelper;
using FamilyTree.SqlliteModel;
using System.Windows.Input;

namespace FamilyTree.ViewModel;

public partial class IndirectRelationViewModel : BindableObject
{
	private readonly DataBaseHelper _dataBaseHelper;
	private string _indirectRelationType;
	private int _firstPersonId;
	private int _secondPersonId;
	public string IndirectRelationType
	{
		get=>_indirectRelationType;
		set
		{
			_indirectRelationType = value;
			OnPropertyChanged();
		}
	}

	public int FirstPersonId
	{
		get => _firstPersonId; set {
			_firstPersonId = value;
			OnPropertyChanged();
		}
	}
    public int SecondPersonId
    {
        get => _secondPersonId; set
        {
            _secondPersonId = value;
            OnPropertyChanged();
        }
    }
    public ICommand SubmitRelationCommand { get; }
    public ICommand GoBackCommand { get; }
    public IndirectRelationViewModel()
	{
		_dataBaseHelper = new DataBaseHelper();
		SubmitRelationCommand = new Command(OnSubmitCommandClicked);
		GoBackCommand = new Command(OnGoBackCommandClicked);
	}
	public void OnSubmitCommandClicked()
	{
		if (IndirectRelationType == null || FirstPersonId == 0 || SecondPersonId == 0)
		{
			Application.Current.MainPage.DisplayAlert("Sorry", "Fill All The Fields Before continue", "Ok");
			return;
		}
		try
		{
			var relation = new IndirectRelation
			{
				RelationType = IndirectRelationType,
				FirstPersonID = FirstPersonId,
				SecondPersonID = SecondPersonId,
			};
		  _dataBaseHelper.InsertIndirectRelation(relation);
		}
		catch (Exception ex)
		{
			Application.Current.MainPage.DisplayAlert("ok", "Error here man", "ok");
		}
		
	}
	public void OnGoBackCommandClicked()
	{
		Shell.Current.GoToAsync("///MainPage");
	}
	
}