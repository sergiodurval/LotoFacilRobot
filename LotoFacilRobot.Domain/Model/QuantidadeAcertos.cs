using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Domain.Model
{
    class QuantidadeAcertos
    {
        public int IdResultado { get; set; }
        public int IdConcurso { get; set; }
        public int QuinzeAcertos { get; set; }
        public int QuatorzeAcertos { get; set; }
        public int TrezeAcertos { get; set; }
        public int DozeAcertos { get; set; }
        public int OnzeAcertos { get; set; }
    }
}
