using MAUIProject1.Views;

namespace MAUIProject1

{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentOptionsView), typeof(StudentOptionsView));
        }
    }
}
