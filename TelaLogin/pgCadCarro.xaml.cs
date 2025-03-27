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

		carro.DiretorioImagem = DirImagem;
    }

	//Variavel Global para armazenar
	//o diretorio da imagem
	string DirImagem;
    private async void btnAddImagem_Clicked(object sender, EventArgs e)
    {
		//Variavel para armazenar
		//a imagem selecionada;

		//Utilizar o componente padrao
		//de seleção de imagem
		var imagemSelecionada =
			await MediaPicker.PickPhotoAsync();

		//validar se uma imagem foi selecionada
		if(imagemSelecionada != null)
		{
			//Recupero o diretorio da
			//imagem selecioanda
			DirImagem = imagemSelecionada.FullPath;
			imgCarro.Source = DirImagem;
        }

    }
}