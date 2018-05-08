﻿using System;
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
            if (ValidaDiaSemana())
            {
                try
                {
                    LotoFacil LotoFacil = new LotoFacil();
                    Console.WriteLine("Inicio extracao: " + DateTime.Now);
                    LotoFacil.ExtrairUltimoConcurso();
                    Console.WriteLine("Fim extracao: " + DateTime.Now);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Método que valida qual o dia da semana(os jogos são realizados somente seg,quar,sex
        /// </summary>
        /// <returns>Retorna true caso seja segunda,quarta ou sexta</returns>
        public static bool ValidaDiaSemana()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday || DateTime.Now.DayOfWeek == DayOfWeek.Wednesday || DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
