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
    public partial class frmNumeroFavorito : Form
    {
        public int qtdNumeros { get; set; }
        public int qtdNumerosSelecionados { get; set; }
       

        public frmNumeroFavorito()
        {
            InitializeComponent();
        }


        public void SetQtdNumeros(RadioButton radioButton)
        {
            this.qtdNumeros = Convert.ToInt32(radioButton.Text);
        }

        public void ChangeBackGroundColorLabel(Label label)
        {
            if (label.BackColor == System.Drawing.Color.White)
            {
                if (ValidateQuantityNumberIsChecked())
                {
                    label.BackColor = System.Drawing.Color.Green;
                    qtdNumerosSelecionados++;
                }
            }
            else
            {
                label.BackColor = System.Drawing.Color.White;
                qtdNumerosSelecionados--;
            }
        }

        private void rbnQuinze_Click(object sender, EventArgs e)
        {
            SetQtdNumeros((RadioButton)sender);
        }

        private void rbnDezesseis_Click(object sender, EventArgs e)
        {
            SetQtdNumeros((RadioButton)sender);
        }

        private void rbnDezessete_Click(object sender, EventArgs e)
        {
            SetQtdNumeros((RadioButton)sender);
        }

        private void rbnDezoito_CheckedChanged(object sender, EventArgs e)
        {
            SetQtdNumeros((RadioButton)sender);
        }

        private void lblUm_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDois_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblTres_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblQuatro_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblCinco_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblSeis_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblSete_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblOito_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblNove_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDez_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblOnze_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDoze_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblTreze_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblCatorze_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblQuinze_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDezesseis_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDezessete_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDezoito_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblDezenove_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinte_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinteUm_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinteDois_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinteTres_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinteQuatro_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        private void lblVinteCinco_Click(object sender, EventArgs e)
        {
            ChangeBackGroundColorLabel((Label)sender);
        }

        public bool ValidateQuantityNumberIsChecked()
        {
            if (qtdNumerosSelecionados + 1 > qtdNumeros)
            {
                MessageBox.Show(string.Format("Você só pode selecionar {0} números",qtdNumeros));
                return false;
            }
            return true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            NumerosFavoritos numerosFavoritos = new NumerosFavoritos();
            numerosFavoritos.ListaNumerosFavoritos = GetNumerosFavoritos();
            if (numerosFavoritos.ListaNumerosFavoritos.Count != qtdNumeros)
            {
                MessageBox.Show(string.Format("Você deve selecionar no minimo {0} números",qtdNumeros));
                return;
            }
            else
            {
                numerosFavoritos.Ativo = true;
                NumerosFavoritosDAO dao = new NumerosFavoritosDAO();
                dao.InsertNumerosFavoritos(numerosFavoritos);
                MessageBox.Show("Teimosinha criada com sucesso");
                GetAllNumerosFavoritos();
            }
            
        }

        public List<int> GetNumerosFavoritos()
        {
            List<int> listaNumerosFavoritos = new List<int>();
            foreach (Control ctrl in groupBox1.Controls)
            {
                if(ctrl.GetType() == typeof(System.Windows.Forms.Label))
                {
                    if (ctrl.BackColor == System.Drawing.Color.Green)
                    {
                        listaNumerosFavoritos.Add(Convert.ToInt32(ctrl.Text));
                    }
                }
            }
            return listaNumerosFavoritos;
        }

        public void GetAllNumerosFavoritos()
        {
            dgvNumerosFavoritos.DataSource = new NumerosFavoritosDAO().GetAllNumerosFavoritos();
        }

        private void frmNumeroFavorito_Load(object sender, EventArgs e)
        {
            GetAllNumerosFavoritos();
        }

        private void dgvNumerosFavoritos_MouseClick(object sender, MouseEventArgs e)
        {
            string numeros = string.Empty;
            numeros = dgvNumerosFavoritos.SelectedRows[0].Cells[1].Value.ToString();
            FillNumbersInPanel(PopulateNumerosSorteados(numeros));
        }

        public void FillNumbersInPanel(List<int> numeros)
        {
            SetAllLabelToWhite();
            foreach (int n in numeros)
            {
                foreach (Control ctrl in groupBox1.Controls)
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

        public List<int> PopulateNumerosSorteados(string numeros)
        {
            List<int> ListaNumeros = numeros.Split('-').Select(Int32.Parse).ToList();
            return ListaNumeros;
        }

        public void SetAllLabelToWhite()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.BackColor = System.Drawing.Color.White;
                }
            }
        }
        
       
    }
}
