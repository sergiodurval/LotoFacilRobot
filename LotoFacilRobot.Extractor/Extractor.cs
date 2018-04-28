using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Extractor.Selenium;
using LotoFacilRobot.Database;
using LotoFacilRobot.Domain.Model;
using System.Linq.Expressions;
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
