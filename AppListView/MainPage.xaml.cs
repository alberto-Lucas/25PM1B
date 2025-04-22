using System.Collections.ObjectModel;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        //Criar uma classe Pessoa
        //para ser o nosso objeto Pessoa
        //e definimos os atributos
        public class Pessoa
        {
            public string Nome { get; set; }
            public string Idade { get; set; }
        }

        //Criar uma coleção de objetos
        //Basicamente cada registro é um objeto
        //Reunimos todos o objetos em uma coleção
        //Tipo coleção utilizada para atualizar
        //automaticamente a ListView (lsvLista)

        //Para isso precisamo da biblioteca:
        //using System.Collections.ObjectModel;
        ObservableCollection<Pessoa> pessoas =
            new ObservableCollection<Pessoa>();

        public MainPage()
        {
            InitializeComponent();

            //Vincular a lista de pessoas 
            //com a ListView
            lsvLista.ItemsSource = pessoas;

            //Adicionar um registro default
            //apenas ara teste de exibição
            pessoas.Add(
                new Pessoa
                {
                    Nome = "Lucas",
                    Idade = "00"
                }
            );
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
