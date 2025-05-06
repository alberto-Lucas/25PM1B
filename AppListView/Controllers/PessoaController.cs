using SQLite;
using AppListView.Services;
using AppListView.Models;

namespace AppListView.Controllers
{
    //Importar
    //using SQLite;
    //using AppListView.Services;
    //using AppListView.Models;

    public class PessoaController
    {
        //Criar a instancia
        //da conexão com o BD
        //e a instacia da camada Services
        private DatabaseService databaseService;
        private SQLiteConnection conexao;

        //Criar o método construtor da classe
        //Método disparado automaticamente
        //ao instanciar a classe
        public PessoaController()
        {
            //Instanciar a classe de conexão
            databaseService = 
                new DatabaseService();

            //Gerar a conexão com o DB
            conexao = 
                databaseService.GetConexao();

            //Mapear a classe para
            //criação ou atualização da tabela
            conexao.CreateTable<Pessoa>();
        }

        //Iremos criar as rotinas de CRUD
        //Insert, Update, Delete e Select

        //Função Insert
        public bool Insert(Pessoa value)
        {
            //O Insert retorna o numero
            //de linhas afetas
            //No caso iremos inserir apenas
            //um registro por vez
            //Sendo 1 inserido com sucesso
            //Sendo 0 falha ao inserir
            return
                conexao.Insert(value) > 0;
        }

        //Função Update
        public bool Update(Pessoa value)
        {
            //O retorno segue o mesmo
            //principio do Insert
            return
                conexao.Update(value) > 0;
        }

        //Função Delete
        public bool Delete(Pessoa value)
        {
            //Segue a ideia do Insert
            return
                conexao.Delete(value) > 0;
        }

        //Chegamos na parte de consultas
        //Funação para retornar todos os registros
        public List<Pessoa> GetAll()
        {
            //Retornar uma lista do Objeto Pessoa
            //Comando será semelhante ao 
            //SELECT * FROM pessoa
            return
                conexao.Table<Pessoa>().
                    ToList();
        }

        //Funação para retornar um registro 
        //com base no Id especificado
        public Pessoa GetById(int value)
        {
            //Como não temos Id duplicado
            //a consulta ira retornar
            //apenas um registro ou nenhum

            //Utilizar o recurso FIND
            //que realiza a consulta com base
            //na chave primaria da tabela
            //ou seja pelo ID
            return
                conexao.Find<Pessoa>(value);
        }

        //Função que consulta com base em um filtro
        //No caso o filtro pelo Nome
        public List<Pessoa> GetByNome(string value)
        {
            //Segue o princial do GetAll
            //porém filtrando pelo nome
            //Semelhante ao comando
            //SELECT * FROM pessoa
            //WHERE nome LIKE x

            //=> se chamada lambida
            //mesmo principio do as
            //para converter um registro
            //em um tipo de dado
            return
                conexao.Table<Pessoa>().
                    Where(x => x.Nome.Contains(value)).
                    ToList();

        }


    }
}
