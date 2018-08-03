namespace LotoFacilRobot.UI
{
    partial class frmEstatistica
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
            this.cboFiltroPesquisa = new System.Windows.Forms.ComboBox();
            this.dgvEstatistica = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstatistica)).BeginInit();
            this.SuspendLayout();
            // 
            // cboFiltroPesquisa
            // 
            this.cboFiltroPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroPesquisa.FormattingEnabled = true;
            this.cboFiltroPesquisa.Location = new System.Drawing.Point(79, 12);
            this.cboFiltroPesquisa.Name = "cboFiltroPesquisa";
            this.cboFiltroPesquisa.Size = new System.Drawing.Size(182, 21);
            this.cboFiltroPesquisa.TabIndex = 0;
            this.cboFiltroPesquisa.SelectionChangeCommitted += new System.EventHandler(this.cboFiltroPesquisa_SelectionChangeCommitted);
            // 
            // dgvEstatistica
            // 
            this.dgvEstatistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstatistica.Location = new System.Drawing.Point(12, 124);
            this.dgvEstatistica.Name = "dgvEstatistica";
            this.dgvEstatistica.Size = new System.Drawing.Size(519, 236);
            this.dgvEstatistica.TabIndex = 1;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(9, 15);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(66, 13);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Filtrar Por:";
            // 
            // frmEstatistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 389);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.dgvEstatistica);
            this.Controls.Add(this.cboFiltroPesquisa);
            this.Name = "frmEstatistica";
            this.Text = "Estatística";
            this.Load += new System.EventHandler(this.frmEstatistica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstatistica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFiltroPesquisa;
        private System.Windows.Forms.DataGridView dgvEstatistica;
        private System.Windows.Forms.Label lblFiltro;
    }
}