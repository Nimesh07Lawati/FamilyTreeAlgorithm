using FamilyTree.View;

namespace FamilyTree
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("FirstPersonPage", typeof(FirstPersonPage));
            Routing.RegisterRoute("MainPageView",typeof(MainPageView));
            Routing.RegisterRoute("RelationPageView", typeof(RelationPage));
        }
    }
}
