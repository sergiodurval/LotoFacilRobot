using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Domain.Model
{
    public class QuantidadeAcertos
    {
        public int IdResultado { get; set; }
        public int IdConcurso { get; set; }
        public double QuinzeAcertos { get; set; }
        public double QuatorzeAcertos { get; set; }
        public double TrezeAcertos { get; set; }
        public double DozeAcertos { get; set; }
        public double OnzeAcertos { get; set; }
        public double ValorPremioQuinzeAcertos { get; set; }
        public double ValorPremioQuatorzeAcertos { get; set; }
        public double ValorPremioTrezeAcertos { get; set; }
        public double ValorPremioDozeAcertos { get; set; }
        public double ValorPremioOnzeAcertos { get; set; }
    }
}
