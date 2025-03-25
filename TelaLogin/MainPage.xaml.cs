namespace TelaLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (ValidarUsuario(txtUsuario.Text, txtSenha.Text))
            {
                //Recuperar a instancia da classe singleton
                var usuarioLogado = UsuarioLogado.Instancia;
                //atribuir valores aos atributos da
                //classe singleton
                usuarioLogado.Login = txtUsuario.Text;

                Application.Current.
                    MainPage.Navigation.
                    PushAsync(new pgPrincipal());
            }
            else
                DisplayAlert("Atenção!",
                            "Usuário ou Senha inválido.",
                            "OK");          
        }

        private bool ValidarUsuario(
            string usuario, string senha)
        {
            var user = UsuarioLogado.Instancia;
            return (usuario == user.Login && senha == user.Senha);
        }

        private void cbxMostrarSenha_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MostrarSenha();
        }

        private void tapMostrarSenha_Tapped(object sender, TappedEventArgs e)
        {
            cbxMostrarSenha.IsChecked =
                !cbxMostrarSenha.IsChecked;
            MostrarSenha();
        }

        private void MostrarSenha()
        {
            txtSenha.IsPassword = !cbxMostrarSenha.IsChecked;
        }

        private void tapCadastrar_Tapped(object sender, TappedEventArgs e)
        {
            Application.Current.MainPage.
                Navigation.PushAsync(new pgRegistro());
        }
    }
}
