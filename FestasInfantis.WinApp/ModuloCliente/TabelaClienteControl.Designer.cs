namespace FestasInfantis.WinApp.ModuloCliente
{
    partial class TabelaClienteControl
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
            gridClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridClientes).BeginInit();
            SuspendLayout();
            // 
            // gridClientes
            // 
            gridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridClientes.Dock = DockStyle.Fill;
            gridClientes.Location = new Point(0, 0);
            gridClientes.Name = "gridClientes";
            gridClientes.RowHeadersVisible = false;
            gridClientes.RowTemplate.Height = 25;
            gridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridClientes.Size = new Size(150, 150);
            gridClientes.TabIndex = 0;
            // 
            // TabelaClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridClientes);
            Name = "TabelaClienteControl";
            ((System.ComponentModel.ISupportInitialize)gridClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridClientes;
    }
}
