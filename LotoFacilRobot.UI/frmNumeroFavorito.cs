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
       
    }
}
