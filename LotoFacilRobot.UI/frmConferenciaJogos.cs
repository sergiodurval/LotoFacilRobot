using LotoFacilRobot.Database;
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
    public partial class frmConferenciaJogos : Form
    {
        public int numeroConcurso { get; set; }
        

        public frmConferenciaJogos()
        {
            InitializeComponent();
        }

        public void PopulateConcurso()
        {
            cboConcursos.DataSource = new ConcursoDAO().GetConcursos();
            cboConcursos.DisplayMember = "NumeroConcurso";
            cboConcursos.ValueMember = "IdConcurso";
        }

        public List<int> GetResultadoConcursoByNumeroConcurso(int numeroConcurso)
        {
            List<int> listaNumerosSorteados = new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso);
            return listaNumerosSorteados;
        }

        public void FillNumerosSorteados(List<int> listaNumerosSorteados)
        {
            FillNumbersInPanel(listaNumerosSorteados);
        }

        public void GetUltimoConcursoSorteado()
        {
            int numeroConcurso = new ConcursoDAO().GetNumeroUltimoConcurso();
            FillNumerosSorteados(new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso));
        }

        private void frmConferenciaJogos_Load(object sender, EventArgs e)
        {
            PopulateConcurso();
            GetUltimoConcursoSorteado();
            numeroConcurso = new ConcursoDAO().GetNumeroUltimoConcurso();
            CalculaQuantidadeAcertos(new NumerosFavoritosDAO().GetAllNumerosFavoritosInList(), numeroConcurso);
            cboConcursos.SelectedIndex = cboConcursos.Items.Count - 1;
        }

        public void FillNumbersInPanel(List<int> numeros)
        {
            SetAllLabelToWhite();
            foreach (int n in numeros)
            {
                foreach (Control ctrl in groupBox2.Controls)
                {
                    if (ctrl.GetType() == typeof(Label))
                    {
                        if (Convert.ToInt32(ctrl.Text) == n)
                        {
                            ctrl.BackColor = System.Drawing.Color.Green;
                            break;
                        }
                    }
                }
            }

        }

        public void SetAllLabelToWhite()
        {
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.BackColor = System.Drawing.Color.White;
                }
            }
        }

        public void CalculaQuantidadeAcertos(List<int> numerosFavoritos,int numeroConcurso)
        {
            List<int> listaResultadoConcurso = new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso);
            int quantidadeAcertos = 0;
           
            
            foreach(int num in listaResultadoConcurso)
            {
                if (numerosFavoritos.IndexOf(num) != -1)
                {
                    quantidadeAcertos++;
                }
            }
            lblQuantidadeAcertos.Text = string.Empty;
            lblQuantidadeAcertos.Text = "Você acertou: " + quantidadeAcertos.ToString();
        }

        private void cboConcursos_SelectedValueChanged(object sender, EventArgs e)
        {
            int num;
            bool result = Int32.TryParse(cboConcursos.Text, out num);
            if (result)
            {
                numeroConcurso = Convert.ToInt32(cboConcursos.Text);
                FillNumbersInPanel(new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso));
                CalculaQuantidadeAcertos(new NumerosFavoritosDAO().GetAllNumerosFavoritosInList(), numeroConcurso);
            }
        }

        
    }
}
