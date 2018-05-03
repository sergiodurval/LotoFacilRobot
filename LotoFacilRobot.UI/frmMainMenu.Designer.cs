namespace LotoFacilRobot.UI
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarTeimosinhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.concursoPassadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conferênciaDoJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarTeimosinhaToolStripMenuItem,
            this.concursoPassadosToolStripMenuItem,
            this.conferênciaDoJogoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem1.Text = "Jogos";
            // 
            // cadastrarTeimosinhaToolStripMenuItem
            // 
            this.cadastrarTeimosinhaToolStripMenuItem.Name = "cadastrarTeimosinhaToolStripMenuItem";
            this.cadastrarTeimosinhaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cadastrarTeimosinhaToolStripMenuItem.Text = "Cadastrar teimosinha";
            this.cadastrarTeimosinhaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarTeimosinhaToolStripMenuItem_Click);
            // 
            // concursoPassadosToolStripMenuItem
            // 
            this.concursoPassadosToolStripMenuItem.Name = "concursoPassadosToolStripMenuItem";
            this.concursoPassadosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.concursoPassadosToolStripMenuItem.Text = "Concursos passados";
            // 
            // conferênciaDoJogoToolStripMenuItem
            // 
            this.conferênciaDoJogoToolStripMenuItem.Name = "conferênciaDoJogoToolStripMenuItem";
            this.conferênciaDoJogoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.conferênciaDoJogoToolStripMenuItem.Text = "Conferências do jogos";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LotoFacilRobot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarTeimosinhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem concursoPassadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conferênciaDoJogoToolStripMenuItem;
    }
}

