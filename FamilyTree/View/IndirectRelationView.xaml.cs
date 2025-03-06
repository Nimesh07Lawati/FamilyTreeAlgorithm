using FamilyTree.ViewModel;

namespace FamilyTree.View;

public partial class IndirectRelationView : ContentPage
{
	public IndirectRelationView()
	{
		InitializeComponent();
		BindingContext = new IndirectRelationViewModel();
	}
}