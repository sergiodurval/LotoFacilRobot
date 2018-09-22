using LotoFacilRobot.Database;
using LotoFacilRobot.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotoFacilRobot.UI
{
    public partial class frmEstatistica : Form
    {
        #region propriedades

        public enum FiltroPesquisa
        {
            NumerosMaisSorteados = 1,
            FiltroPorPeriodo = 2,
            RankingAcertos = 3
        };

        private Dictionary<int, int> numerosSorteados;
        private List<int> listaNumerosFavoritos;

        #endregion

        #region eventos

        public frmEstatistica()
        {
            InitializeComponent();
            InitializeDictionary();
        }

        private void frmEstatistica_Load(object sender, EventArgs e)
        {
            PopulateFiltroPesquisa();
        }

        private void cboFiltroPesquisa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltroPesquisa pesquisa = (FiltroPesquisa)Convert.ToInt32(cboFiltroPesquisa.SelectedValue);

            switch (pesquisa)
            {
                case FiltroPesquisa.NumerosMaisSorteados:
                    EsconderControles();
                    PopulateByNumerosMaisSorteados();
                    break;

                case FiltroPesquisa.FiltroPorPeriodo:
                    ExibirControles();
                    PopulateFiltroPesquisa();
                    break;

                case FiltroPesquisa.RankingAcertos:
                    EsconderControles();
                    PopulateRankingAcertos();
                    break;

                default:
                    break;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(dtpInicio.Text) && !String.IsNullOrEmpty(dtpFim.Text))
            {
                PopulateFiltroPeriodo(Convert.ToDateTime(dtpInicio.Text), Convert.ToDateTime(dtpFim.Text));
            }
            else
            {
                MessageBox.Show("Informe o periodo desejado");
            }
        }

        #endregion

        #region métodos

        private void PopulateFiltroPesquisa()
        {
            cboFiltroPesquisa.DisplayMember = "Text";
            cboFiltroPesquisa.ValueMember = "Value";

            var items = new[]
            {
                new { Text = "Numeros mais sorteados" ,Value = "1"},
                new { Text = "Filtro por periodo" , Value = "2" },
                new { Text = "Ranking de acertos" , Value = "3" }
            };

            cboFiltroPesquisa.DataSource = items;
        }

        private void CalculateAmountHint()
        {
            numerosSorteados = new Dictionary<int,int>();
            InitializeDictionary();
            List<Concurso> listaConcurso = new ConcursoDAO().GetAll();

            foreach (Concurso concurso in listaConcurso)
            {
                foreach (int numero in concurso.NumerosSorteados)
                {
                    numerosSorteados[numero]++;
                }
            }
        }

        private void InitializeDictionary()
        {
            numerosSorteados = new Dictionary<int, int>();
            for (int i = 1; i <= 25; i++)
            {
                numerosSorteados.Add(i, 0);
            }
        }

        private void PopulateByNumerosMaisSorteados()
        {
            ClearGridViewColumnsAndRows();
            CalculateAmountHint();
            dgvEstatistica.ColumnCount = 2;
            dgvEstatistica.Columns[0].Name = "Número";
            dgvEstatistica.Columns[1].Name = "Quantidade de vezes em que foi sorteado";

            foreach (KeyValuePair<int, int> numero in numerosSorteados)
            {
                dgvEstatistica.Rows.Add(numero.Key, numero.Value);
            }

            this.dgvEstatistica.Sort(this.dgvEstatistica.Columns["Quantidade de vezes em que foi sorteado"], ListSortDirection.Descending);
        }

        private void ObterListaNumerosFavoritos()
        {
            listaNumerosFavoritos = new NumerosFavoritosDAO().GetAllNumerosFavoritosInList();
        }


        private void PopulateRankingAcertos(List<Concurso> listaConcurso = null , bool ordenarPorData = false)
        {
            ClearGridViewColumnsAndRows();
            CalculateAmountHint();
            List<Concurso> ListaConcurso = listaConcurso == null ? new ConcursoDAO().GetAll() : listaConcurso;
            ObterListaNumerosFavoritos();
            int quantidadeAcertos = 0;
            Dictionary<int, int> rankingAcertos = new Dictionary<int, int>();

            foreach(Concurso concurso in ListaConcurso)
            {
                rankingAcertos.Add(concurso.NumeroConcurso, 0);
                List<int> listaResultadoConcurso = new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(concurso.NumeroConcurso);
                foreach (int numero in listaResultadoConcurso)
                {
                    if (listaNumerosFavoritos.IndexOf(numero) != -1)
                    {
                        quantidadeAcertos++;
                        rankingAcertos[concurso.NumeroConcurso]++;           
                    }
                }
                quantidadeAcertos = 0;
            }

            dgvEstatistica.ColumnCount = 3;
            dgvEstatistica.Columns[0].Name = "Concurso";
            dgvEstatistica.Columns[1].Name = "Quantidade de acertos";
            dgvEstatistica.Columns[2].Name = "Data Resultado";

            foreach(KeyValuePair<int,int> numero in rankingAcertos)
            {
                dgvEstatistica.Rows.Add(numero.Key, numero.Value,new ConcursoDAO().GetDataResultadoConcurso(numero.Key).ToShortDateString());
            }

            if (ordenarPorData == true)
            {
                this.dgvEstatistica.Sort(this.dgvEstatistica.Columns["Data Resultado"], ListSortDirection.Ascending);    
            }
            else
            {
                this.dgvEstatistica.Sort(this.dgvEstatistica.Columns["Quantidade de acertos"], ListSortDirection.Descending);
            }
            
        }

        private void PopulateFiltroPeriodo(DateTime dataInicial,DateTime dataFinal)
        {
            List<Concurso> listaConcurso = new ConcursoDAO().GetConcursoPorPeriodo(dataInicial, dataFinal);
            PopulateRankingAcertos(listaConcurso,true);
        }

        private void ClearGridViewColumnsAndRows()
        {
            dgvEstatistica.Columns.Clear();
            dgvEstatistica.Rows.Clear();
        }

        private void ExibirControles()
        {
            lblDataInicio.Visible = true;
            lblDataFim.Visible = true;
            dtpInicio.Visible = true;
            dtpFim.Visible = true;
            btnPesquisar.Visible = true;
        }

        private void EsconderControles()
        {
            lblDataInicio.Visible = false;
            lblDataFim.Visible = false;
            dtpInicio.Visible = false;
            dtpFim.Visible = false;
            btnPesquisar.Visible = false;
        }

        #endregion

       

        

        
    }
}
