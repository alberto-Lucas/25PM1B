using SQLite;

namespace AppListView.Models
{
    //Importar o SqLite
    //using SQLite;

    //Deixar a classe publica
    public class Pessoa
    {
        //Adicionar os atributos
        //Pela classe ser usada
        //para gerar a tabela do BD
        //precisamos de um atributo ID
        //para ser o identificador do
        //registro, e configurar o ID
        //como chave primeiro e auto incremento
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        //Adicionar o atributos que ira
        //salvar o diretorio da imagem
        public string DirImagem { get; set; }
    }
}
