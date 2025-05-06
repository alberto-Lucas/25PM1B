using System.Collections.ObjectModel;
using PCLExt.FileStorage.Folders;
using SQLite;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
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

        //Importar as bibliotecas

        //using PCLExt.FileStorage.Folders;
        //using SQLite;

        //Criar uma classe Pessoa
        //para ser o nosso objeto Pessoa
        //e definimos os atributos

        //Transformar o objeto Pessoa
        //na tabela do banco de dados
        public class Pessoa
        {
            //Precisamos adicionar o atributo
            //para ser o identificador do
            //registro no banco de dados
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Idade { get; set; }
        }

        //Criar uma coleção de objetos
        //Basicamente cada registro é um objeto
        //Reunimos todos o objetos em uma coleção
        //Tipo coleção utilizada para atualizar
        //automaticamente a ListView (lsvLista)

        //Desativar a coleção de objeto
        //pois iremos gravar direto no BD

        //Para isso precisamo da biblioteca:
        //using System.Collections.ObjectModel;
        /*ObservableCollection<Pessoa> pessoas =
            new ObservableCollection<Pessoa>();*/

        //Agora precisamos criar a conexao
        //com o banco de dados
        //Variavel responsavel pela conexão
        private SQLiteConnection conexao;
        
        //Função para retornar a conexão com o BD
        public SQLiteConnection GetConnection()
        {
            //Primeiro precisamo manipular o arquivo

            //Variavel responsavel pela pasta
            //onde estara o arquivo
            //A pasta raiz onde o app esta instalado
            var folder = new LocalRootFolder();

            //Definir o nome do banco de dados
            //Configurar para caso o arquivo não
            //exista, ele seja criado
            //Caso exista sera utilizado

            //variavel q ira representar o bd
            var file = folder.CreateFile(
                "list", PCLExt.FileStorage.
                    CreationCollisionOption.OpenIfExists);

            //Criar e retornar a conexão o bd
            return new SQLiteConnection(file.Path);
        }

        public MainPage()
        {
            InitializeComponent();

            //Vincular a lista de pessoas 
            //com a ListView

            //Remove o vinulo da list
            //lsvLista.ItemsSource = pessoas;

            //Adicionar um registro default
            //apenas ara teste de exibição
            /*pessoas.Add(
                new Pessoa
                {
                    Nome = "Lucas",
                    Idade = "00"
                }
            );*/

            //Abrir a conexão com o banco de dados
            conexao = GetConnection();

            //Mapear a classe Pessoa para criação da tabela
            conexao.CreateTable<Pessoa>();
            //Se a tabela não existir ele cria (create table)
            //se ja existir ele atualiza (alter table)

            //Atualizar a lista com os dados
            AtualizarListView();
        }

        //Método para atualizar a ListView
        //com os registro do BD
        private void AtualizarListView()
        {
            //Realizar um select na tabela Pessoa
            //seria referente a query:
            //select * from pessoa
            lsvLista.ItemsSource = 
                conexao.Table<Pessoa>().ToList();
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string idade = txtIdade.Text;

            //Validar os registro
            if(string.IsNullOrEmpty(nome) || 
                string.IsNullOrEmpty(idade))
            {
                //Se um dos dois estiver vazio
                //apresento mensagem para o usuario
                DisplayAlert("Atenção",
                    "Por favor, preencha o nome "+
                    "e a idade corretamente", "OK");
                return; //para PARAR a excução
            }

            //Se chegou até aqui, é pq esta tudo certo
            //Agora podemos popular a nossa coleção

            //Remove o coleção de objeto pois nao usamos mais
            /*pessoas.Add(
                new Pessoa
                {
                    Nome = nome,
                    Idade = idade
                });*/

            //Agora iremos inserir direto no banco de dados

            //Populando o obejto Pessoa
            //com os dados informados
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.Idade = idade;

            //inserindo o objeto Pessoa no BD
            conexao.Insert(pessoa);

            //Atualizar a list
            AtualizarListView();

            //por ultimo limpamos os campos
            txtNome.Text = "";
            txtIdade.Text = "";
        }

        private void lsvLista_Tapped(object sender, ItemTappedEventArgs e)
        {
            //Validar se o item da Lista é do Pessoa
            //Extrar o objeto do item selecionado
            //O item selecionado será o e do parametro
            //Extra o item do e
            //e.Item
            //comparar o item com o objeto
            //is = é
            //atribuir o obejto Pessoa a variavel pessoa
            if(e.Item is Pessoa pessoa)
            {
                //Criar uma variavel com o
                //detalhes do registro
                string itemSelecionado =
                    "Resgitro: " + pessoa.Id.ToString() +
                    Environment.NewLine +
                    "Nome: " + pessoa.Nome +
                    Environment.NewLine +
                    "Idade: " + pessoa.Idade;

                DisplayAlert("Detalhes da Pessoa",
                    itemSelecionado, "OK");
            }

            //Limpar a seleção do item
            //Preciso informar o tipo do componente
            //q sera o sender para acessar as
            //propriedade de limpeza
            //((ListView)sender) = lsvLista
            ((ListView)sender).SelectedItem = null;
        }

        private async void btnDeletar_Clicked(object sender, EventArgs e)
        {
            //Nesse ponto iremos seguir a logica
            //semelhante ao selecionar o registro
            //como o botão deletar esta dentro do item
            //e o mesmo ja possui o evento tapped
            //isso pode gerar conflito no reconhecimento
            //de toque, então precisamos identificar
            //que o toque está sentod realizado no button
            //e recuperamos o registro através do parametro
            //o tal do ponto .
            if(sender is Button button &&
                button.CommandParameter is Pessoa pessoa)
            {
                //Se chegou até aqui 
                //o item selecionado é valido

                //Precisamos da confirmação do usuario
                //antes de excluir o registro

                //Nosso displayalert, quando utilizo a opção
                //Sim ou Não
                //o retorno Defautl TRUE é do primeiro botão
                //portanto o primeiro deve ser o SIM
                bool validacao =
                    await DisplayAlert(
                        "Confirmação",
                        "Deseja realmente excluir este item?",
                        "Sim",
                        "Não");

                if(validacao)
                {
                    conexao.Delete(pessoa);
                    AtualizarListView();
                }
            }
        }
    }
}
