using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCoMed.API
{
    public class ControleMedicamento
    {
        public ControleMedicamento(string nome, int lote, DateTime fabricacao, DateTime validade)
        {
            Nome = nome;
            Lote = lote;
            Fabricacao = fabricacao;
            Validade = validade;
        }

        public int MedicamentoId { get; private set; }
        public string Nome { get; private set; }
        public int Lote { get; private set; }
        public DateTime Fabricacao { get; private set; }
        public DateTime Validade { get; private set; }
        public void Update(string nome)
        {
            Nome = nome;
        }

    }
}