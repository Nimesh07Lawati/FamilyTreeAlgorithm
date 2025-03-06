using System.Windows.Input;

namespace FamilyTree.ViewModel;

public partial class DirectRelationViewModel : BindableObject
{
	public ICommand SubmitDirectRelationCommand { get;}
	public ICommand GoBackCommand { get;}

	public DirectRelationViewModel()
	{
		SubmitDirectRelationCommand = new Command(OnsubmitRelationClicked);
		GoBackCommand = new Command(OnGoBackButtonClicked);
	}
	public void OnsubmitRelationClicked()
	{
		Application.Current.MainPage.DisplayAlert("OK", "this is on submit Relation clicked", "ok");
	}
    public void OnGoBackButtonClicked()
	{
		Shell.Current.GoToAsync("///MainPage");
	}

  }
