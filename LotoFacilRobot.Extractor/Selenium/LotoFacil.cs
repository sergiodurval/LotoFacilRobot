using LotoFacilRobot.Extractor.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LotoFacilRobot.Extractor.Selenium
{
    class LotoFacil
    {
        public string url = @"https://www.gigasena.com.br/loterias/lotofacil/resultados/resultado-lotofacil";
        public IWebDriver driver;

        public void CargaInicial()
        {
            Concurso concurso = new Concurso();
            List<int> TodosConcursos2018 = new List<int>();
            TodosConcursos2018.Add(1633);
            TodosConcursos2018.Add(1634);
            TodosConcursos2018.Add(1635);
            TodosConcursos2018.Add(1636);
            TodosConcursos2018.Add(1637);
            TodosConcursos2018.Add(1638);
            TodosConcursos2018.Add(1639);
            TodosConcursos2018.Add(1640);
            TodosConcursos2018.Add(1641);
            TodosConcursos2018.Add(1642);
            TodosConcursos2018.Add(1643);
            TodosConcursos2018.Add(1644);
            TodosConcursos2018.Add(1645);
            TodosConcursos2018.Add(1646);
            TodosConcursos2018.Add(1647);
            TodosConcursos2018.Add(1648);
            TodosConcursos2018.Add(1649);
            TodosConcursos2018.Add(1650);
            TodosConcursos2018.Add(1651);
            TodosConcursos2018.Add(1652);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            url = url + "-1633.htm";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            IWebElement dadosDoConcurso = driver.FindElement(By.ClassName("game-label-b"));
            concurso.NumeroConcurso = dadosDoConcurso.Text;
            dadosDoConcurso = driver.FindElement(By.Id("lotofacil-d"));
            concurso.DataResultado = Convert.ToDateTime(dadosDoConcurso.Text);
            Thread.Sleep(10000);
            driver.Quit();

        }
    }
}
