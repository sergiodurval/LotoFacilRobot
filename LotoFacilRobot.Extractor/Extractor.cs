using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Extractor.Model;
using LotoFacilRobot.Extractor.Selenium;
namespace LotoFacilRobot.Extractor
{
    public static class Extractor
    {
        public static void Main()
        {
            LotoFacil LotoFacil = new LotoFacil();
            LotoFacil.CargaInicial();
        }
    }
}
