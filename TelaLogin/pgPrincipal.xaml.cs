namespace TelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();
		//Recuperar a classe singleton
		var usuarioLogado = UsuarioLogado.Instancia;

		txtUsuarioLogado.Text =
			"Olá " + usuarioLogado.Login +
			". Seja bem-vindo!";

		lblLogin.Text = "Login: " + usuarioLogado.Login;
        lblSenha.Text = "Senha: " + usuarioLogado.Senha;
        lblNome.Text = "Nome: " + usuarioLogado.Nome;
        lblEmail.Text = "Email: " + usuarioLogado.Email;
        lblIdade.Text = "Idade: " + usuarioLogado.Idade;

    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		//Comando para voltar pagina
		Application.Current.MainPage.
			Navigation.PopAsync();
    }

    private void btnCadCarro_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.
			Navigation.PushAsync(new pgCadCarro());
    }

    private void btnVisCarro_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.
            Navigation.PushAsync(new pgVisCarro());
    }
}