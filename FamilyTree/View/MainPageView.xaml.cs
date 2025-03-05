using FamilyTree.ViewModel;

namespace FamilyTree.View;

public partial class MainPageView : ContentPage
{
	private readonly MainPageViewModel _viewModel;
	public MainPageView()
	{
		InitializeComponent();
		_viewModel = new MainPageViewModel();
		BindingContext=_viewModel;
		
	}
}