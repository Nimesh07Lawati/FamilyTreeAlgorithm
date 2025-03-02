
using FamilyTree.ViewModel;
namespace FamilyTree.View;
public partial class RelationPage : ContentPage
{
    private readonly RelationPageViewModel _viewModel;
	public RelationPage()
	{
		InitializeComponent();
        _viewModel = new RelationPageViewModel();
        BindingContext = _viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnShowDataClicked(); }
}