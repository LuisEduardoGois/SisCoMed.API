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
    [Route("api/controle-medicamentos")]
    [ApiController]
    public class ControleMedicamentosController : ControllerBase
    {
        private readonly SisCoMedContext _context;
        public ControleMedicamentosController(SisCoMedContext context)
        {
            _context = context;
        }
        // Get api/contole-medicamentos
        [HttpGet]
        public IActionResult GetAll()
        {
            var controleMedicamentos = _context.ControleMedicamentos;
            return Ok(controleMedicamentos);
        }

        // Get api/controle-medicamentos/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var controleMedicamento = _context.ControleMedicamentos
                .SingleOrDefault(cm => cm.MedicamentoId == id);

            if (controleMedicamento == null)
                return NotFound();

            return Ok(controleMedicamento);
        }

        // Post api/controle-medicamentos
        [HttpPost]
        public IActionResult Post(AddControleMedicamentoInputModel model)
        {
            var controleMedicamento = new ControleMedicamento(
                model.Nome,
                model.Lote,
                model.Fabricacao,
                model.Validade
            );

            _context.ControleMedicamentos.Add(controleMedicamento);

            return CreatedAtAction(
                "GetById",
                new { id = controleMedicamento.MedicamentoId },
                controleMedicamento);

        }

        // Put api/controle-medicamento/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateControleMedicamentoInputModel model)
        {
            var controleMedicamento = _context.ControleMedicamentos
                .SingleOrDefault(cm => cm.MedicamentoId == id);

            if (controleMedicamento == null)
                return NotFound();

            controleMedicamento.Update(model.Nome);
            return NoContent();
        }

    }
}