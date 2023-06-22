namespace FestasInfantis.WinApp.ModuloTema
{
    partial class TabelaTemaControl
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
            gridTemas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridTemas).BeginInit();
            SuspendLayout();
            // 
            // gridTemas
            // 
            gridTemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTemas.Dock = DockStyle.Fill;
            gridTemas.Location = new Point(0, 0);
            gridTemas.Name = "gridTemas";
            gridTemas.RowTemplate.Height = 25;
            gridTemas.Size = new Size(150, 150);
            gridTemas.TabIndex = 0;
            // 
            // TabelaTemaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridTemas);
            Name = "TabelaTemaControl";
            ((System.ComponentModel.ISupportInitialize)gridTemas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridTemas;
    }
}
