namespace FestasInfantis.WinApp.ModuloCliente
{
    partial class TabelaAlugueisClienteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridAlugueis = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridAlugueis).BeginInit();
            SuspendLayout();
            // 
            // gridAlugueis
            // 
            gridAlugueis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAlugueis.Dock = DockStyle.Fill;
            gridAlugueis.Location = new Point(0, 0);
            gridAlugueis.Name = "gridAlugueis";
            gridAlugueis.RowHeadersVisible = false;
            gridAlugueis.RowTemplate.Height = 25;
            gridAlugueis.Size = new Size(150, 150);
            gridAlugueis.TabIndex = 0;
            // 
            // TabelaAlugueisClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridAlugueis);
            Name = "TabelaAlugueisClienteControl";
            ((System.ComponentModel.ISupportInitialize)gridAlugueis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridAlugueis;
    }
}
