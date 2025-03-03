using FamilyTree.ViewModel;
namespace FamilyTree.View;

public partial class FirstPersonPage : ContentPage
{

	private readonly FirstPersonViewModel _firstPersonPageViewModel;
	public FirstPersonPage()
	{
        InitializeComponent();
        _firstPersonPageViewModel = new FirstPersonViewModel();
		BindingContext = _firstPersonPageViewModel;
		
	}
}