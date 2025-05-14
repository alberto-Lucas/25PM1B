using AppListView.Controllers;
using AppListView.Models;
using AppListView.Views;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        #region Passo a Passo
        //Passo para tranformar em mvc
        //----------------------------------
        //Primeiro Passo
        //Criar a pasta Models
        //Mover o nosso objeto Pessoa para models
        //Criar uma classe chamada Pessoa
        //E mover o objeto com os seus atributos
        //Iremos chamar de Pessoa.cs o arquivo
        //----------------------------------
        //Segundo Passo
        //Criar a pasta Services
        //Iremos armazenar a conexão com o BD
        //Criar a classe DatabaseService
        //Mover a conexão para a classe
        //DatabaseService.cs o arquivo
        //----------------------------------
        //Terceiro Passo
        //Criar a pasta Controllers
        //Iremos armazenar a class de 
        //manipulação de dados
        //No caso do objeto Pessoa teremos
        //a classe PessoaController
        //para manipular o
        //insert, update, delet e select no BD
        //Mover e criar os métodos de manipulação
        //na classe PessoaController
        //PessoaController.cs o arquivo
        //----------------------------------
        //Quarto Passo
        //Criar a pasta Views
        //Iremos colocar todas as pagina
        //ou seja ContentPage
        //Iremos criar uma tela de cadastro nova
        //Deixar apenas a ListView na MainPage
        //pgCadastroView.xaml
        //----------------------------------
        //Quinto Passo
        //Importar as camadas para a MainPage
        //using AppListView.Controllers;
        //using AppListView.Models;
        //using AppListView.Views;
        //----------------------------------
        //Finalizado aqui

        //Para uso de banco de dados
        //precisamos importar as bibliotecas
        //do sqlite e de um gerenciado de arquivos

        //Instalar Nuget sqlite-net-pcl (icone pena)
        //Instalar Nuget pclext.filestorage (icone sushi)
        #endregion

        //Criar a istancia da classe
        //PessoaController
        PessoaController pessoaController;

        public MainPage()
        {
            InitializeComponent();
            pessoaController = 
                new PessoaController();
            AtualizarListView();
        }

        //Método para atualizar a ListView
        private void AtualizarListView()
        {
            lsvLista.ItemsSource =
                pessoaController.GetAll();
        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation
                .PushAsync(new pgCadPessoaView());
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
        {
            //Precisamos recupear o evento tap
            //precionado
            //a varivael tapped, ira receber
            //o conteudo de e q é o evento em si
            TappedEventArgs tapped = 
                (TappedEventArgs)e;
            //Atraves do conteudo do e
            //acesso o registro selecionado
            //q foi passado via parametro
            //Valido se o registro do parametro
            //é do tipo Pessoa, se for atribuo
            //a variavel registro
            if(tapped.Parameter is Pessoa registro)
            {
                //Podemos chamar a tela de visualização
                //passando o registro via parametro
                Application.Current.MainPage.
                    Navigation.PushAsync(
                        new pgVisPessoaView(registro));
            }
        }

        private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
        {
            //Iremos seguir a ideia da
            //rotina de visualizar
            //Recuperar o evento tapped
            //e validar o parametro
            TappedEventArgs tapped = 
                (TappedEventArgs)e;

            if(tapped.Parameter is Pessoa registro)
            {
                //Precisa da confirmação do usuario
                //para exclusão do registro
                bool validacao =
                    await DisplayAlert(
                        "Confirmação",
                        "Deseja realmente excluir o registro?",
                        "Sim", "Não");

                if(validacao)
                {
                    //Iremos chamar a rotina de exclusão
                    //da camada controller
                    //e após excluir o registro iremos
                    //atualizar a lista
                    pessoaController.Delete(registro);
                    AtualizarListView();
                }
            }
        }
    }
}
