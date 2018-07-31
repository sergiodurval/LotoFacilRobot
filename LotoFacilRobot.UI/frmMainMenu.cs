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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void cadastrarTeimosinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNumeroFavorito frmNumeroFavorito = new frmNumeroFavorito();
            frmNumeroFavorito.MdiParent = this;
            frmNumeroFavorito.Show();
        }

        private void conferênciaDoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConferenciaJogos frmConferenciaJogos = new frmConferenciaJogos();
            frmConferenciaJogos.MdiParent = this;
            frmConferenciaJogos.Show();
        }

        private void concursoPassadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstatistica frmEstatistica = new frmEstatistica();
            frmEstatistica.MdiParent = this;
            frmEstatistica.Show();
        }
    }
}
