using AppListView.Controllers;
using AppListView.Models;

namespace AppListView.Views;

public partial class pgCadPessoaView : ContentPage
{
    //Importar
    //using AppListView.Controllers;
    //using AppListView.Models;

    //Criar a instancia para a classe
    //PessoaController
    private PessoaController pessoaController;

	public pgCadPessoaView()
	{
		InitializeComponent();
        //Instanciar a pessoaController
        pessoaController = 
            new PessoaController();
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        //Voltar para pagina anterior
        //de modo asincrono
        await Application.Current.
            MainPage.Navigation.PopAsync();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        //Mesmo principio da tela de
        //cadastro anterior

        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        //Validar os campos
        if(string.IsNullOrEmpty(nome) ||
           string.IsNullOrEmpty(idade))
        {
            //Se um dos dois estiver vazio
            //notificamos o usuario
            //e abortamos a execu��o
            DisplayAlert(
                "Aten��o",
                "Informe os dados corretamente.",
                "OK");
            return; //abortar a execu��o
        }

        //Criar e popular o obejto Pessoa
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = nome;
        pessoa.Idade = idade;

        //Agora iremos inserir no BD
        if (pessoaController.Insert(pessoa))
        {
            //Se chegou � pq deu certo
            DisplayAlert(
                "Informa��o",
                "Registro salvo com sucesso!",
                "OK");

            //Limpo os campos
            txtNome.Text = "";
            txtIdade.Text = "";
        }
        else
            DisplayAlert(
                "Erro",
                "Falha ao salvar o registro " +
                "no banco de dados",
                "OK");
    }
}