using FamilyTree.ViewModel;

namespace FamilyTree.View;

public partial class MainPageView : ContentPage
{

	public MainPageView()
	{
		InitializeComponent();
	BindingContext=new MainPageViewModel();
	}
}