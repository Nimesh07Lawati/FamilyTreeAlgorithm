using FamilyTree.ViewModel;

namespace FamilyTree.View;

public partial class DirectRelationView : ContentPage
{
	public DirectRelationView()
	{
		InitializeComponent();
		BindingContext = new DirectRelationViewModel();
	}
}