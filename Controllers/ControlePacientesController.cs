using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SisCoMed.API.Models;
using SisCoMed.API.Persistence;

namespace SisCoMed.API.Controllers
{
    [Route("api/controle-pacientes")]
    [ApiController]
    public class ControlePacientesController : ControllerBase
    {
        private readonly SisCoMedContext _context;
        public ControlePacientesController(SisCoMedContext context)
        {
            _context = context;
        }

        // Get api/controle-pacientes
        [HttpGet]
        public IActionResult GetAll()
        {
            var controlePacientes = _context.ControlePacientes;
            return Ok(controlePacientes);

        }

        // Get api/controle-pacientes/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var controlePaciente = _context.ControlePacientes
                .SingleOrDefault(cp => cp.Id == id);

            if (controlePaciente == null)
                return NotFound();

            return Ok(controlePaciente);
        }

        // Post api/controle-pacientes
        [HttpPost]
        public IActionResult Post(AddControlePacienteInputModel model)
        {
            var controlePaciente = new ControlePaciente(
                model.Nome,
                model.Leito
            );

            _context.ControlePacientes.Add(controlePaciente);

            return CreatedAtAction(
                "GetById",
                new { id = controlePaciente.Id },
                controlePaciente);
        }

        // Put api/medicamento/3
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateControlePacienteInputModel model)
        {
            var controlePaciente = _context.ControlePacientes
                .SingleOrDefault(cm => cm.Id == id);

            if (controlePaciente == null)
                return NotFound();

            controlePaciente.Update(model.Leito);
            return NoContent();

        }
    }
}