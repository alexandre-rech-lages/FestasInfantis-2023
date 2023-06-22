namespace FestasInfantis.WinApp.ModuloCliente
{
    partial class TelaAlugueisClienteForm
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
            lblId = new Label();
            txtId = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            btnOk = new Button();
            panel1 = new Panel();
            tabelaAlugueisClienteControl1 = new TabelaAlugueisClienteControl();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(44, 46);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(70, 43);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(21, 77);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(70, 74);
            txtNome.Name = "txtNome";
            txtNome.ReadOnly = true;
            txtNome.Size = new Size(399, 23);
            txtNome.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(394, 306);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 41);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(tabelaAlugueisClienteControl1);
            panel1.Location = new Point(21, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 163);
            panel1.TabIndex = 6;
            // 
            // tabelaAlugueisClienteControl1
            // 
            tabelaAlugueisClienteControl1.Dock = DockStyle.Fill;
            tabelaAlugueisClienteControl1.Location = new Point(0, 0);
            tabelaAlugueisClienteControl1.Name = "tabelaAlugueisClienteControl1";
            tabelaAlugueisClienteControl1.Size = new Size(448, 163);
            tabelaAlugueisClienteControl1.TabIndex = 0;
            // 
            // TelaAlugueisClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 359);
            Controls.Add(panel1);
            Controls.Add(btnOk);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaAlugueisClienteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Aluguéis do Cliente";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblNome;
        private TextBox txtNome;
        private Button btnOk;
        private Panel panel1;
        private TabelaAlugueisClienteControl tabelaAlugueisClienteControl1;
    }
}