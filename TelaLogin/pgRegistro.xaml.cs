namespace TelaLogin;

public partial class pgRegistro : ContentPage
{
	public pgRegistro()
	{
		InitializeComponent();
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		//Chamar a instancia da
		//classe singleton
		//e popular os atributos

		var usuarioLogado = UsuarioLogado.Instancia;
		usuarioLogado.Login = txtLogin.Text;
		usuarioLogado.Senha = txtSenha.Text;
		usuarioLogado.Nome = txtNome.Text;
		usuarioLogado.Email = txtEmail.Text;
		usuarioLogado.Idade = txtIdade.Text;

		//Voltar automatico para tela de login
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}