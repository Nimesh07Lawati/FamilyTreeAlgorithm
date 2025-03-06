using FamilyTree.ViewModel;

namespace FamilyTree.View;

public partial class DAtaPageView : ContentPage
{
	public DAtaPageView()
	{
		InitializeComponent();
		BindingContext = new DataPageViewModel();
	}
}