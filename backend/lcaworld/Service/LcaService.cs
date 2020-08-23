using LcaWorld.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcaworld.Service
{
    public class LcaService: ILcaService

    {
        private readonly ILogger<LcaService> _logger;
        public LcaService(ILogger<LcaService> logger)
        {
            _logger = logger;
        }

        //public List<SubCompartment> SubCompartments()
        //{
        //    return compartmentRepo.getAll();
        //}
        //public List<Compartment> Compartments()
        //{
        //    return ((Compartment[])Enum.GetValues(typeof(Compartment))).ToList();
        //}

        //public void SayHello()
        //{
        //    _logger.LogInformation("hello LCA Service");
        //    ElementaryFlow f = new ElementaryFlow();
        //    f.Id = 32;
        //    f.Name = "2-Nitrobenzoic acid";
        //    f.CompartmentId = compartmentRepo.GetByCompartmentName(Compartment.Air, "urban air close to ground").SubCompartmentId;
        //    f.UnitId = 0;
        //    elementaryRepo.add(f);
        //    _logger.LogInformation($"About page visited at {DateTime.UtcNow.ToLongTimeString()}");
        //    _logger.LogInformation($"Total flows: { elementaryRepo.getAll().Count()}");
        //    _logger.LogInformation($"Compartments: { compartmentRepo.getAll()}");
        //}

        //public List<ElementaryFlow> Flows()
        //{
        //    return elementaryRepo.getAll();
        //}
    }
}
