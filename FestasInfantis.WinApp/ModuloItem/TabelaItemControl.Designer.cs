namespace FestasInfantis.WinApp.ModuloItem
{
    partial class TabelaItemControl
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
            gridItens = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridItens).BeginInit();
            SuspendLayout();
            // 
            // gridItens
            // 
            gridItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItens.Dock = DockStyle.Fill;
            gridItens.Location = new Point(0, 0);
            gridItens.Name = "gridItens";
            gridItens.RowTemplate.Height = 25;
            gridItens.Size = new Size(150, 150);
            gridItens.TabIndex = 0;
            // 
            // TabelaItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridItens);
            Name = "TabelaItemControl";
            ((System.ComponentModel.ISupportInitialize)gridItens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridItens;
    }
}
