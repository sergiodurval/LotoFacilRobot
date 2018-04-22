using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Extractor.Model
{
    class Concurso
    {
        public string NumeroConcurso { get; set; }
        public DateTime DataResultado { get; set; }
        public double PremioEstimado { get; set; }
        public DateTime ProximoConcurso { get; set; }
        public List<Concurso> ListaDeConcursos { get; set; }
        public List<int> NumerosSorteados { get; set; }
    }
}
