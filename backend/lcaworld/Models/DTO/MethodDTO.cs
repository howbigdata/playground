using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models.ViewModels
{
    public class MethodDTO
    {
        public Method MethodInformation { get; set; }
        public List<FactorDTO> CharacterisationFactors { get; set; }
    }
}
