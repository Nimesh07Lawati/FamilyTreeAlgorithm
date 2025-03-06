using FamilyTree.View;

namespace FamilyTree
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPageView));
            Routing.RegisterRoute("DirectRelationPage", typeof(DirectRelationView));
            Routing.RegisterRoute("IndirectRelationPage", typeof(IndirectRelationView));
            Routing.RegisterRoute("DataPageView", typeof(DAtaPageView));

        }
    }
}
