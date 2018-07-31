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
        private int numeroConcurso { get; set; }
        

        public frmConferenciaJogos()
        {
            InitializeComponent();
        }

        private void PopulateConcurso()
        {
            cboConcursos.DataSource = new ConcursoDAO().GetConcursos();
            cboConcursos.DisplayMember = "NumeroConcurso";
            cboConcursos.ValueMember = "IdConcurso";
        }

        private List<int> GetResultadoConcursoByNumeroConcurso(int numeroConcurso)
        {
            List<int> listaNumerosSorteados = new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso);
            return listaNumerosSorteados;
        }

        private void FillNumerosSorteados(List<int> listaNumerosSorteados)
        {
            FillNumbersInPanel(listaNumerosSorteados);
        }

        private void GetUltimoConcursoSorteado()
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

        private void FillNumbersInPanel(List<int> numeros)
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

        private void SetAllLabelToWhite()
        {
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void CalculaQuantidadeAcertos(List<int> numerosFavoritos,int numeroConcurso)
        {
            List<int> listaResultadoConcurso = new ConcursoDAO().GetResultadoConcursoByNumeroConcurso(numeroConcurso);
            int quantidadeAcertos = 0;
            StringBuilder strNumerosAcertos = new StringBuilder();
            
            foreach(int num in listaResultadoConcurso)
            {
                if (numerosFavoritos.IndexOf(num) != -1)
                {
                    quantidadeAcertos++;
                    strNumerosAcertos.Append(num + "-");
                }
            }
            lblQuantidadeAcertos.Text = string.Empty;
            lblQuantidadeAcertos.Text = String.Format("Você acertou: {0}", quantidadeAcertos.ToString());
            strNumerosAcertos.Remove(strNumerosAcertos.Length - 1, 1);
            lblNumerosSorteados.Text = String.Format("Números acertados: {0}", strNumerosAcertos.ToString());
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
