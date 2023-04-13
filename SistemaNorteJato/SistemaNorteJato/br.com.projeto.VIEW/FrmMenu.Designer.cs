namespace SistemaNorteJato.br.com.projeto.VIEW
{
    partial class FrmMenu
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
            this.cADASTROCONSULTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADASTROCONSCLIENTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADASTROCONSFUNCIONÁRIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADASTROCONSFORNECEDORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cADASTROCONSULTAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cADASTROCONSULTAToolStripMenuItem
            // 
            this.cADASTROCONSULTAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cADASTROCONSCLIENTEToolStripMenuItem,
            this.cADASTROCONSFUNCIONÁRIOToolStripMenuItem,
            this.cADASTROCONSFORNECEDORToolStripMenuItem});
            this.cADASTROCONSULTAToolStripMenuItem.Name = "cADASTROCONSULTAToolStripMenuItem";
            this.cADASTROCONSULTAToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.cADASTROCONSULTAToolStripMenuItem.Text = "CADASTRO/CONSULTA";
            // 
            // cADASTROCONSCLIENTEToolStripMenuItem
            // 
            this.cADASTROCONSCLIENTEToolStripMenuItem.Name = "cADASTROCONSCLIENTEToolStripMenuItem";
            this.cADASTROCONSCLIENTEToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.cADASTROCONSCLIENTEToolStripMenuItem.Text = "CADASTRO/CONS. CLIENTE";
            // 
            // cADASTROCONSFUNCIONÁRIOToolStripMenuItem
            // 
            this.cADASTROCONSFUNCIONÁRIOToolStripMenuItem.Name = "cADASTROCONSFUNCIONÁRIOToolStripMenuItem";
            this.cADASTROCONSFUNCIONÁRIOToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.cADASTROCONSFUNCIONÁRIOToolStripMenuItem.Text = "CADASTRO/CONS. FUNCIONÁRIO";
            // 
            // cADASTROCONSFORNECEDORToolStripMenuItem
            // 
            this.cADASTROCONSFORNECEDORToolStripMenuItem.Name = "cADASTROCONSFORNECEDORToolStripMenuItem";
            this.cADASTROCONSFORNECEDORToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.cADASTROCONSFORNECEDORToolStripMenuItem.Text = "CADASTRO/CONS. FORNECEDOR";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Norte Jato";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cADASTROCONSULTAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADASTROCONSCLIENTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADASTROCONSFUNCIONÁRIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADASTROCONSFORNECEDORToolStripMenuItem;
    }
}