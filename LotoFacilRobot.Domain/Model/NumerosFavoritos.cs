using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Domain.Model
{
    public class NumerosFavoritos
    {
        public int Id { get; set; }
        public List<int> NumerosFavoritos { get; set; }
        public bool Ativo { get; set; }
    }
}
