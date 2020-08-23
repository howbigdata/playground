using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LcaWorld.Models.ViewModels
{
    public class ProcessDTO
    {
        public Process ProcessInformation { get; set; }
        public List<ExchangeDTO> ElementaryExchanges { get; set; }
    }
}
