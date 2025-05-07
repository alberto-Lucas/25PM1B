using AppListView.Models;

namespace AppListView.Views;

public partial class pgVisPessoaView : ContentPage
{
	//Importar
	//using AppListView.Models;

	//Variavel do obejto Pessoa
	Pessoa pessoaVisualizar;

	//Adicionar o parametro
	//pessoa no constrtutor
	public pgVisPessoaView(Pessoa pessoa)
	{
		InitializeComponent();
		pessoaVisualizar = pessoa;
		ExibirDados();
	}

	//Método para exibir os dados na tela
	private void ExibirDados()
	{
		//Vamos popular as labels 
		lblId.Text = pessoaVisualizar.Id.ToString();
		lblNome.Text = pessoaVisualizar.Nome;
		lblIdade.Text = pessoaVisualizar.Idade;
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
		await Application.Current.MainPage.
			Navigation.PopAsync();
    }
}