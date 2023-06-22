namespace FestasInfantis.WinApp.ModuloTema
{
    partial class TelaTemaForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            lblId = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtNome = new TextBox();
            lblValor = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtValor = new TextBox();
            tabPage2 = new TabPage();
            btnSelecionarItens = new Button();
            gridItens = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridItens).BeginInit();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(329, 366);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 0;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(410, 366);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(63, 35);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 2;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(89, 32);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 3;
            txtId.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 65);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(89, 62);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(290, 23);
            txtNome.TabIndex = 5;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(47, 95);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(36, 15);
            lblValor.TabIndex = 10;
            lblValor.Text = "Valor:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(30, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(426, 317);
            tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtValor);
            tabPage1.Controls.Add(lblId);
            tabPage1.Controls.Add(txtId);
            tabPage1.Controls.Add(lblValor);
            tabPage1.Controls.Add(txtNome);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(418, 289);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados Básicos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            txtValor.Enabled = false;
            txtValor.Location = new Point(89, 91);
            txtValor.Name = "txtValor";
            txtValor.ReadOnly = true;
            txtValor.Size = new Size(67, 23);
            txtValor.TabIndex = 11;
            txtValor.Text = "0";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSelecionarItens);
            tabPage2.Controls.Add(gridItens);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(418, 289);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Seleção de Itens";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelecionarItens
            // 
            btnSelecionarItens.Location = new Point(6, 6);
            btnSelecionarItens.Name = "btnSelecionarItens";
            btnSelecionarItens.Size = new Size(168, 37);
            btnSelecionarItens.TabIndex = 1;
            btnSelecionarItens.Text = "Adicionar e Remover Itens";
            btnSelecionarItens.UseVisualStyleBackColor = true;
            btnSelecionarItens.Click += btnSelecionarItens_Click;
            // 
            // gridItens
            // 
            gridItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItens.Location = new Point(0, 49);
            gridItens.Name = "gridItens";
            gridItens.RowTemplate.Height = 25;
            gridItens.Size = new Size(418, 240);
            gridItens.TabIndex = 0;
            // 
            // TelaTemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 419);
            Controls.Add(tabControl1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaTemaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Temas";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridItens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private Label lblId;
        private TextBox txtId;
        private Label label2;
        private TextBox txtNome;
        private Label lblValor;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnSelecionarItens;
        private DataGridView gridItens;
        private TextBox txtValor;
    }
}