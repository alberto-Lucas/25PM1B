using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppListView.Services
{
    //Importar o Sqlite e PCL
    //using SQLite;
    //using PCLExt.FileStorage.Folders;
    public class DatabaseService
    {
        //Variavel responsavel
        //pela conexão com o BD
        public SQLiteConnection conexao;

        //Função para retornar a conexão com o BD
        public SQLiteConnection GetConexao()
        {
            //Primeiro precisamos
            //manipular o arquivo do BD
            //Recuperar a pasta raiz
            //onde a aplicação esta instalada
            var folder =
                new LocalRootFolder();

            //Manipular o arquivo do BD
            //Definir o nome do banco de dados
            //Configurar a criação do arquivo
            //Se nao existir, o arquivo é criado
            //se ja existir, o arquivo é atualizado
            var file =
                folder.CreateFile("list",
                    PCLExt.FileStorage.
                    CreationCollisionOption.
                    OpenIfExists);

            //Iremos conectar no BD
            //e retornaremos a conexão
            return
                new SQLiteConnection(file.Path);
        }
    }
}
