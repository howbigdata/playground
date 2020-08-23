using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lcaworld.Db;
using LcaWorld.Models;
using LcaWorld.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lcaworld.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        private readonly LcaContext _context;

        public MethodController(LcaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Method>>> Method()
        {
            return await _context.Methods.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodDTO>> GetMethod(int id)
        {
            var method = await _context.Methods.FindAsync(id);

            if (method == null)
            {
                return NotFound();
            }
            var factors = _context.CharacterisationFactors
               .Where(p => p.MethodId == id)
               .Join(
               _context.ElementaryFlows,
               exc => exc.ElementaryFlowId,
               flow => flow.Id,
               (exc, flow) => new FactorDTO
               {
                   Value = exc.Factor,
                   FlowName = flow.Name,
                   UnitName = flow.Unit.Name
               }).ToList();

            var p = new MethodDTO();
            p.CharacterisationFactors = factors;
            p.MethodInformation = method;
            return p;
        }
    }
}
