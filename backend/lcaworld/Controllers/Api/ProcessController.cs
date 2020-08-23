using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using lcaworld.Db;
using LcaWorld.Models;
using LcaWorld.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace lcaworld.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly LcaContext _context;

        public ProcessController(LcaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Process>>> Process()
        {
            return await _context.Processes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessDTO>> GetProcess(int id)
        {
            var process = await _context.Processes.FindAsync(id);

            if (process == null)
            {
                return NotFound();
            }
            var processExchanges = _context.ProcessExchanges
                .Where(p => p.ProcessId == id)
                .Join(
                _context.ElementaryFlows,
                exc => exc.ElementaryFlowId,
                flow => flow.Id,
                (exc, flow) => new ExchangeDTO
                {
                    Value = exc.Value,
                    FlowName = flow.Name,
                    UnitName = flow.Unit.Name
                }).ToList();

            var p = new ProcessDTO();
            p.ElementaryExchanges = processExchanges;
            p.ProcessInformation = process;
            return p;
        }
        private T DownloadAndDeserializeJsonData<T>(string url) where T : new()
        {
            using (var webClient = new WebClient())
            {
                var jsonData = string.Empty;
                try
                {
                    jsonData = webClient.DownloadString(url);
                }
                catch (Exception) { }
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
        }

        [HttpGet("{id}/solve")]
        public IEnumerable<ImpactDTO> SolveProcess(int id) => DownloadAndDeserializeJsonData<List<ImpactDTO>>("http://analytics-api:5000/solve/" + id);
    }
}
