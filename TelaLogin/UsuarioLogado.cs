using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin
{
    //Classe Singleton para armazena o usuario logado
    public sealed class UsuarioLogado
    {
        //Variavel que vai apontar a memoria
        static UsuarioLogado _instancia;

        //Metodo para retorno da instancia
        public static UsuarioLogado Instancia
        {
            get
            {
                //retorna o apontamento da
                //instancia em memoria
                //se não existir
                //cria um novo apontamento
                return _instancia ??
                    (_instancia = new UsuarioLogado());
            }
        }

        //Criar o construtor da casse
        public UsuarioLogado() { }

        //prop tab tab
        public string Login { get; set; }
        //Ira armazenar o nome do usuario logado
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Idade { get; set; }
    }
}
