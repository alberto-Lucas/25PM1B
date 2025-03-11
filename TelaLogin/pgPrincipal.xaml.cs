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

    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		//Comando para voltar pagina
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}