using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCoMed.API
{
    public class ControlePaciente
    {
        public ControlePaciente(string nome, int leito)
        {
            Nome = nome;
            Leito = leito;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Leito { get; private set; }
        public void Update(int leito)
        {
            Leito = leito;
        }
    }
}