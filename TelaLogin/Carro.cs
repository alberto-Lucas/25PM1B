using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin
{
    public sealed class Carro
    {
        public static Carro _instancia;

        public static Carro Instancia
        {
            get
            {
                return _instancia ?? 
                    (_instancia = new Carro());
            }
        }

        public Carro() { }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricao { get; set; }
        public string AnoModelo { get; set; }
        public string Cor { get; set; }
        public string Login { get; set; }
        public string DtCadastro { get; set; }
    }
}
