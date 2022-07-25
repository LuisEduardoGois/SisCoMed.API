using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCoMed.API.Persistence
{
    public class SisCoMedContext
    {
        public SisCoMedContext()
        {
            ControleMedicamentos = new List<ControleMedicamento>();

            ControlePacientes = new List<ControlePaciente>();
        }

        public List<ControleMedicamento> ControleMedicamentos { get; set; }
        public List<ControlePaciente> ControlePacientes { get; set; }

    }
}