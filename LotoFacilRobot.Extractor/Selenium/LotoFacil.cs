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
using System.Net;
namespace LotoFacilRobot.Extractor.Selenium
{
    class LotoFacil
    {
        private string url = @"https://www.gigasena.com.br/loterias/lotofacil/resultados/resultado-lotofacil-{0}.htm";
        private IWebDriver driver;
        IWebElement dadosDoConcurso;
        Concurso concurso;
        QuantidadeAcertos qtdAcertos;

        /// <summary>
        /// Realiza a carga inicial dos concurso
        /// </summary>
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

        /// <summary>
        /// Extrai os números sorteados
        /// </summary>
        /// <returns>Retorna lista de inteiros contendo o números sorteados</returns>
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

        /// <summary>
        /// Extrai a data do próximo concurso
        /// </summary>
        /// <returns>Retorna a data do próximo concurso</returns>
        private DateTime GetDataProximoConcurso()
        {
            dadosDoConcurso = driver.FindElement(By.Id("painel-info"));
            return Convert.ToDateTime(dadosDoConcurso.Text.Split(':')[1].Substring(0, 11));
            
        }

        /// <summary>
        /// Extrai o prêmio estimado
        /// </summary>
        /// <returns>Retorna  o prêmio estimado</returns>
        private double GetPremioEstimado()
        {
            dadosDoConcurso = driver.FindElement(By.Id("painel-info"));
            return Convert.ToDouble(dadosDoConcurso.Text.Split(':')[2].Replace("R$", ""));
        }

        /// <summary>
        /// Extrai o número do concurso
        /// </summary>
        /// <returns>Retorna o número do concurso</returns>
        private int GetNumeroConcurso()
        {
            dadosDoConcurso = driver.FindElement(By.ClassName("game-label-b"));
            return Convert.ToInt32(dadosDoConcurso.Text);
        }

        /// <summary>
        /// Extrai a data em que foi disponibilizado o resultado
        /// </summary>
        /// <returns>Retorna a data em que foi disponibilizado o resultado</returns>
        private DateTime GetDataResultado()
        {
            dadosDoConcurso = driver.FindElement(By.Id("lotofacil-d"));
            return Convert.ToDateTime(dadosDoConcurso.Text);
        }

        /// <summary>
        /// Retorna a quantidade de acertos
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>Retorna a quantidade de acertos com base no parâmetro passado ex:quantos acertaram 11</returns>
        private double GetQuantidadeAcertos(int quantidade)
        {
            dadosDoConcurso = driver.FindElement(By.Id(string.Format("lotofacil-w{0}",quantidade)));
            return Convert.ToInt32(dadosDoConcurso.Text.Replace("x","").Replace(".",""));
        }

        /// <summary>
        /// Extrai o valor do prêmio por acerto
        /// </summary>
        /// <param name="quantidadeAcertos"></param>
        /// <returns>Retorna o valor do prêmio pelo parâmetro passado ex:retorna o valor do prêmio pra quem acertou 11</returns>
        private double GetValorPremioByQuantidadeAcertos(int quantidadeAcertos)
        {
            dadosDoConcurso = driver.FindElement(By.Id(string.Format("lotofacil-v{0}", quantidadeAcertos)));
            return Convert.ToDouble(dadosDoConcurso.Text.Replace(",","."));
        }

        /// <summary>
        /// Preenche as informações do concurso
        /// </summary>
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

        /// <summary>
        /// Preenche as informações dos resultados do concurso
        /// </summary>
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

        /// <summary>
        /// Monta a url que deve ser extraido os dados
        /// </summary>
        /// <param name="numeroConcurso"></param>
        /// <returns>Retorna a url montada com o numero do concurso a ser extraido</returns>
        public string GetUrlFormatada(int numeroConcurso)
        {
            return string.Format(url, Convert.ToString(numeroConcurso));
        }

        /// <summary>
        /// Realiza a extração do último concurso
        /// </summary>
        public void ExtrairUltimoConcurso()
        {
            if (ValidaHorarioExecucao())
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                int numeroConcurso = new ConcursoDAO().GetNumeroUltimoConcursoExtracao();
                driver.Navigate().GoToUrl(GetUrlFormatada(numeroConcurso));
                Thread.Sleep(1000);
                PopulateConcurso();
                PopulateQuantidadeAcertos();
                Thread.Sleep(1000);
                driver.Close();
            }
            else
            {
                throw new Exception("O sorteio é realizado das 20h em diante");
            }
        }

        /// <summary>
        /// Valida o horário da execução o sorteio é feito as 20h
        /// </summary>
        /// <returns>Retorna verdadeiro caso seja 20h ou mais e falso caso seja menos</returns>
        public bool ValidaHorarioExecucao()
        {
            if (DateTime.Now.Hour < 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
