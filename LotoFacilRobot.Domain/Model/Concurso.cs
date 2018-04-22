using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Domain.Model
{
    public class Concurso
    {
        public int IdConcurso { get; set; }
        public int NumeroConcurso { get; set; }
        public DateTime DataResultado { get; set; }
        public double PremioEstimado { get; set; }
        public DateTime ProximoConcurso { get; set; }
        public List<int> NumerosSorteados { get; set; }
    }
}
