using FamilyTree.View;

namespace FamilyTree
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPageView));
        }
    }
}
