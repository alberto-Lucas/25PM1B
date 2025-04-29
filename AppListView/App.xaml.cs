namespace AppListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {   
            var window = new Window(new AppShell());

            window.Height = 800; //Altura
            window.Width = 400;  //Largura

            return window;
        }
    }
}