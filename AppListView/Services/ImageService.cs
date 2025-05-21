namespace AppListView.Services
{
    //Usaremos o recurso de classe static
    //Classes Static, não precisam ser 
    //instanciadas em memoria
    //portanto podemos acessar seus
    //métodos e funções diretamente
    //Os método e função de um classe 
    //static tambem precisam ser do tipo
    //static
    public static class ImageService
    {
        //Função para selecionar a imagem e
        //retornar o diretorio atual da imagem
        //no caso é o diretorio original
        //Esta função precisa ser do tipo 
        //async Task para não travar a 
        //execução principal do APP
        public static async 
            Task<string> SelecionarImagem()
        {
            string diretorio = "";

            //Método para seleção de imagem
            var imagemSelecionada =
                await MediaPicker.PickPhotoAsync();

            //Validar se realmente teve uma
            //imagem selecioanda
            if (imagemSelecionada != null)
            {
                diretorio =
                    imagemSelecionada.FullPath;
            }

            return diretorio;
        }

        //Função que ira copiar a imagem
        //para o mesmo diretorio da instalação
        //do aplicativo e retornaremos
        //o novo diretorio da copia
        public static string 
            CopiarImagemDirApp(string sDiretorioImagem)
        {
            string diretorioDestino = "";

            //Validar se o parametro do diretorio
            //nao esta vazio
            if(!string.IsNullOrEmpty(sDiretorioImagem))
            {
                //Montar o diretorio junto do nome da pasta
                //onde iremos criar uma pasta Imagens
                //dentro da instalação do APP para melhor
                //organização
                //Para isso precisamos recuperar o local
                //de instação do app
                //ou seja se o dir for Ex: C:/APP
                //Iremos combinar com o nome d pasta
                //tendo o novo diretorio como:
                //Ex: C:/APP/Imagens/
                string novoDiretorio =
                    Path.Combine(
                        AppContext.BaseDirectory, "Imagens");

                //Validar a existencia do novo diretorio
                if(!Directory.Exists(novoDiretorio))
                {
                    //Não existe o diretorio
                    //iremos cria-lo
                    //Ou seja iremos criar a pasta Imagens
                    Directory.CreateDirectory(novoDiretorio);
                }

                //Montar o novo diretorio com o nome do arquivo
                //atualmente o novoDiretorio possui a informaçaõ
                //C:/APP/Imagens
                //Ira combinar com o nome do arquivo
                //gerando o nosso diretorio de destino
                //Ex: C:/APP/Imagens/imagem.png
                diretorioDestino =
                    Path.Combine(novoDiretorio,
                        Path.GetFileName(sDiretorioImagem));

                //Agora sim, iremos fazer a copia da imagem
                //Iremos copiar a imagem para o DiretorioDestino
                //Precisamo ativar a opção de subistituir
                //a imagem caso ja exista
                File.Copy(
                    sDiretorioImagem, diretorioDestino,
                        overwrite: true);
            }

            //essa informação que sera
            //gravada no banco de dados
            return diretorioDestino; 
        }
    }
}
