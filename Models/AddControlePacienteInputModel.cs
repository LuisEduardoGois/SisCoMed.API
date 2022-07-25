using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCoMed.API.Models
{
    public record AddControlePacienteInputModel(
        string Nome,
        int Leito)
    {

    }
}