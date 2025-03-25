namespace TelaLogin;

public partial class pgCadCarro : ContentPage
{
	public pgCadCarro()
	{
		InitializeComponent();
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		var carro = Carro.Instancia;
		carro.Marca = txtMarca.Text;
		carro.Modelo = txtModelo.Text;
		carro.AnoFabricao = txtAnoFabricacao.Text;
		carro.AnoModelo = txtAnoModelo.Text;
		carro.Cor = txtCor.Text;

		var user = UsuarioLogado.Instancia;
		carro.Login = user.Login;
		//Preenche com a data e hora atual
		//do dispositivo
		carro.DtCadastro = 
			DateTime.Now.ToShortDateString();
    }
}