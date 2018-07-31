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
        public enum FiltroPesquisa
        {
            NumerosMaisSorteados = 1,
            FiltroPorPeriodo = 2,
            RankingAcertos = 3
        };

        private Dictionary<int, int> numerosSorteados;

        public frmEstatistica()
        {
            InitializeComponent();
            InitializeDictionary();
        }

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
            for (int i = 1; i <= 25; i++ )
            {
                numerosSorteados.Add(i, 0);
            }
        }
        

        private void frmEstatistica_Load(object sender, EventArgs e)
        {
            PopulateFiltroPesquisa();
        }
    }
}
