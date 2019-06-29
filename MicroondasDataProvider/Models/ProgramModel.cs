using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroondasDataProvider
{
    public class ProgramModel
    {
        public string Name { get; set; }

        public int? Time { get; set; }

        public int? Potency { get; set; }

        public string HeatChar { get; set; }

        public string Instructions { get; set; }
    }
}
