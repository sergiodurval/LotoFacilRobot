using LotoFacilRobot.Domain.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LotoFacilRobot.Database;
namespace LotoFacilRobot.Extractor.Selenium
{
    class LotoFacil
    {
        private string url = @"https://www.gigasena.com.br/loterias/lotofacil/resultados/resultado-lotofacil-{0}.htm";
        private IWebDriver driver;
        IWebElement dadosDoConcurso;
        Concurso concurso;
        QuantidadeAcertos qtdAcertos;

        public void CargaInicial()
        {
            List<int> TodosConcursos2018 = new List<int>();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            #region TODOS_CONCURSOS_2018
            TodosConcursos2018.Add(1653);
            TodosConcursos2018.Add(1654);
            TodosConcursos2018.Add(1655);
            #endregion
            foreach (int numeroConcurso in TodosConcursos2018)
            {
                driver.Navigate().GoToUrl(GetUrlFormatada(numeroConcurso));
                Thread.Sleep(1000);
                PopulateConcurso();
                PopulateQuantidadeAcertos();
            }
            Thread.Sleep(10000);
            driver.Quit();
        }

        private List<int> GetNumerosSorteados()
        {
            List<int> ListaDeNumerosSorteados = new List<int>();
            IWebElement elementoNumeroSorteado;
            for (int i = 0; i <= 14; i++)
            {
                elementoNumeroSorteado = driver.FindElement(By.Id(string.Format("lotofacil-dz{0}",i)));
                ListaDeNumerosSorteados.Add(Convert.ToInt32(elementoNumeroSorteado.Text));
            }
            return ListaDeNumerosSorteados;
        }

        private DateTime GetDataProximoConcurso()
        {
            dadosDoConcurso = driver.FindElement(By.Id("painel-info"));
            return Convert.ToDateTime(dadosDoConcurso.Text.Split(':')[1].Substring(0, 11));
            
        }

        private double GetPremioEstimado()
        {
            dadosDoConcurso = driver.FindElement(By.Id("painel-info"));
            return Convert.ToDouble(dadosDoConcurso.Text.Split(':')[2].Replace("R$", ""));
        }

        private int GetNumeroConcurso()
        {
            dadosDoConcurso = driver.FindElement(By.ClassName("game-label-b"));
            return Convert.ToInt32(dadosDoConcurso.Text);
        }

        private DateTime GetDataResultado()
        {
            dadosDoConcurso = driver.FindElement(By.Id("lotofacil-d"));
            return Convert.ToDateTime(dadosDoConcurso.Text);
        }

        private double GetQuantidadeAcertos(int quantidade)
        {
            dadosDoConcurso = driver.FindElement(By.Id(string.Format("lotofacil-w{0}",quantidade)));
            return Convert.ToInt32(dadosDoConcurso.Text.Replace("x","").Replace(".",""));
        }

        private double GetValorPremioByQuantidadeAcertos(int quantidadeAcertos)
        {
            dadosDoConcurso = driver.FindElement(By.Id(string.Format("lotofacil-v{0}", quantidadeAcertos)));
            return Convert.ToDouble(dadosDoConcurso.Text.Replace(",","."));
        }

        public void PopulateConcurso()
        {
            concurso = new Concurso();
            concurso.NumeroConcurso = GetNumeroConcurso();
            concurso.DataResultado = GetDataResultado();
            concurso.NumerosSorteados = GetNumerosSorteados();
            concurso.ProximoConcurso = GetDataProximoConcurso();
            concurso.PremioEstimado = GetPremioEstimado();
            ConcursoDAO concursoDAO = new ConcursoDAO();
            concurso.IdConcurso = concursoDAO.InsertConcurso(concurso);
        }

        public void PopulateQuantidadeAcertos()
        {
            qtdAcertos = new QuantidadeAcertos();
            qtdAcertos.IdConcurso = concurso.IdConcurso;
            qtdAcertos.QuinzeAcertos = GetQuantidadeAcertos(15);
            qtdAcertos.QuatorzeAcertos = GetQuantidadeAcertos(14);
            qtdAcertos.TrezeAcertos = GetQuantidadeAcertos(13);
            qtdAcertos.DozeAcertos = GetQuantidadeAcertos(12);
            qtdAcertos.OnzeAcertos = GetQuantidadeAcertos(11);
            qtdAcertos.ValorPremioQuinzeAcertos = GetValorPremioByQuantidadeAcertos(15);
            qtdAcertos.ValorPremioQuatorzeAcertos = GetValorPremioByQuantidadeAcertos(14);
            qtdAcertos.ValorPremioTrezeAcertos = GetValorPremioByQuantidadeAcertos(13);
            qtdAcertos.ValorPremioDozeAcertos = GetValorPremioByQuantidadeAcertos(12);
            qtdAcertos.ValorPremioOnzeAcertos = GetValorPremioByQuantidadeAcertos(11);
            QuantidadeAcertosDAO qtdAcertosDAO = new QuantidadeAcertosDAO();
            qtdAcertosDAO.InsertQuantidadeAcertos(qtdAcertos);
        }

        public string GetUrlFormatada(int numeroConcurso)
        {
            return string.Format(url, Convert.ToString(numeroConcurso));
        }

        public void ExtrairUltimoConcurso()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            int numeroConcurso = new ConcursoDAO().GetNumeroUltimoConcurso();
            driver.Navigate().GoToUrl(GetUrlFormatada(numeroConcurso));
            Thread.Sleep(1000);
            PopulateConcurso();
            PopulateQuantidadeAcertos();
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
