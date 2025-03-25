namespace TelaLogin;

public partial class pgVisCarro : ContentPage
{
	public pgVisCarro()
	{
		InitializeComponent();

		var carro = Carro.Instancia;

		lblMarca.Text = carro.Marca;
		lblModelo.Text = carro.Modelo;
		lblAnoFabricacao.Text = carro.AnoFabricao;
		lblAnoModelo.Text = carro.AnoModelo;
		lblCor.Text = carro.Cor;
		lblLogin.Text = carro.Login;
		lblDtCadastro.Text = carro.DtCadastro;
	}
}