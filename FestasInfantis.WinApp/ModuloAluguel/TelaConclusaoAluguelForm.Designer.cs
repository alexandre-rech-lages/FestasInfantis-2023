namespace FestasInfantis.WinApp.ModuloAluguel
{
    partial class TelaConclusaoAluguelForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pnlEndereco = new GroupBox();
            txtNumero = new TextBox();
            lblNumero = new Label();
            txtEstado = new TextBox();
            lblEstado = new Label();
            txtRua = new TextBox();
            lblRua = new Label();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            lblBairro = new Label();
            lblCidade = new Label();
            groupBox1 = new GroupBox();
            txtHorarioInicio = new MaskedTextBox();
            txtHorarioTermino = new MaskedTextBox();
            lblHorarioTermino = new Label();
            txtDataFesta = new DateTimePicker();
            lblData = new Label();
            lblHorarioInicio = new Label();
            tabPage2 = new TabPage();
            pnlCliente = new GroupBox();
            cmbClientes = new ComboBox();
            txtPorcentagemDesconto = new TextBox();
            label5 = new Label();
            lblNomeCliente = new Label();
            pnlTema = new GroupBox();
            cmbTemas = new ComboBox();
            txtValorTema = new TextBox();
            label3 = new Label();
            lblNomeTema = new Label();
            pnlDadosAluguel = new GroupBox();
            cmbEntrada = new ComboBox();
            label1 = new Label();
            txtValorSinal = new TextBox();
            label2 = new Label();
            txtValorDesconto = new TextBox();
            txtValorPendente = new TextBox();
            lblValorPendente = new Label();
            label4 = new Label();
            btnCancelar = new Button();
            btnConcluir = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            pnlEndereco.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlCliente.SuspendLayout();
            pnlTema.SuspendLayout();
            pnlDadosAluguel.SuspendLayout();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(31, 44);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(57, 41);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(77, 23);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(31, 96);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(521, 375);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnlEndereco);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(513, 347);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados da Festa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlEndereco
            // 
            pnlEndereco.Controls.Add(txtNumero);
            pnlEndereco.Controls.Add(lblNumero);
            pnlEndereco.Controls.Add(txtEstado);
            pnlEndereco.Controls.Add(lblEstado);
            pnlEndereco.Controls.Add(txtRua);
            pnlEndereco.Controls.Add(lblRua);
            pnlEndereco.Controls.Add(txtCidade);
            pnlEndereco.Controls.Add(txtBairro);
            pnlEndereco.Controls.Add(lblBairro);
            pnlEndereco.Controls.Add(lblCidade);
            pnlEndereco.Enabled = false;
            pnlEndereco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pnlEndereco.Location = new Point(22, 157);
            pnlEndereco.Name = "pnlEndereco";
            pnlEndereco.Size = new Size(468, 145);
            pnlEndereco.TabIndex = 5;
            pnlEndereco.TabStop = false;
            pnlEndereco.Text = "Dados do Endereço:";
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumero.Location = new Point(351, 97);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 7;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumero.Location = new Point(291, 100);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(54, 15);
            lblNumero.TabIndex = 18;
            lblNumero.Text = "Número:";
            // 
            // txtEstado
            // 
            txtEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtEstado.Location = new Point(351, 39);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(100, 23);
            txtEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstado.Location = new Point(298, 42);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 16;
            lblEstado.Text = "Estado:";
            // 
            // txtRua
            // 
            txtRua.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtRua.Location = new Point(83, 68);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(368, 23);
            txtRua.TabIndex = 5;
            // 
            // lblRua
            // 
            lblRua.AutoSize = true;
            lblRua.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRua.Location = new Point(47, 71);
            lblRua.Name = "lblRua";
            lblRua.Size = new Size(30, 15);
            lblRua.TabIndex = 14;
            lblRua.Text = "Rua:";
            // 
            // txtCidade
            // 
            txtCidade.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCidade.Location = new Point(83, 39);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(154, 23);
            txtCidade.TabIndex = 3;
            // 
            // txtBairro
            // 
            txtBairro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBairro.Location = new Point(83, 97);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(184, 23);
            txtBairro.TabIndex = 6;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBairro.Location = new Point(36, 100);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(41, 15);
            lblBairro.TabIndex = 11;
            lblBairro.Text = "Bairro:";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCidade.Location = new Point(30, 42);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(47, 15);
            lblCidade.TabIndex = 10;
            lblCidade.Text = "Cidade:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHorarioInicio);
            groupBox1.Controls.Add(txtHorarioTermino);
            groupBox1.Controls.Add(lblHorarioTermino);
            groupBox1.Controls.Add(txtDataFesta);
            groupBox1.Controls.Add(lblData);
            groupBox1.Controls.Add(lblHorarioInicio);
            groupBox1.Enabled = false;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(25, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(465, 135);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data e Hora:";
            // 
            // txtHorarioInicio
            // 
            txtHorarioInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtHorarioInicio.Location = new Point(117, 74);
            txtHorarioInicio.Mask = "00:00";
            txtHorarioInicio.Name = "txtHorarioInicio";
            txtHorarioInicio.Size = new Size(56, 23);
            txtHorarioInicio.TabIndex = 10;
            txtHorarioInicio.Text = "1300";
            txtHorarioInicio.ValidatingType = typeof(DateTime);
            // 
            // txtHorarioTermino
            // 
            txtHorarioTermino.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtHorarioTermino.Location = new Point(377, 74);
            txtHorarioTermino.Mask = "00:00";
            txtHorarioTermino.Name = "txtHorarioTermino";
            txtHorarioTermino.Size = new Size(56, 23);
            txtHorarioTermino.TabIndex = 9;
            txtHorarioTermino.Text = "1900";
            txtHorarioTermino.ValidatingType = typeof(DateTime);
            // 
            // lblHorarioTermino
            // 
            lblHorarioTermino.AutoSize = true;
            lblHorarioTermino.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblHorarioTermino.Location = new Point(259, 79);
            lblHorarioTermino.Name = "lblHorarioTermino";
            lblHorarioTermino.Size = new Size(112, 15);
            lblHorarioTermino.TabIndex = 8;
            lblHorarioTermino.Text = "Horário de Termino:";
            // 
            // txtDataFesta
            // 
            txtDataFesta.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtDataFesta.Format = DateTimePickerFormat.Short;
            txtDataFesta.Location = new Point(117, 34);
            txtDataFesta.Name = "txtDataFesta";
            txtDataFesta.Size = new Size(85, 23);
            txtDataFesta.TabIndex = 0;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblData.Location = new Point(31, 40);
            lblData.Name = "lblData";
            lblData.Size = new Size(80, 15);
            lblData.TabIndex = 3;
            lblData.Text = "Data da Festa:";
            // 
            // lblHorarioInicio
            // 
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblHorarioInicio.Location = new Point(13, 80);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(98, 15);
            lblHorarioInicio.TabIndex = 6;
            lblHorarioInicio.Text = "Horário de Início:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnlCliente);
            tabPage2.Controls.Add(pnlTema);
            tabPage2.Controls.Add(pnlDadosAluguel);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(513, 347);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Dados do Aluguel";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlCliente
            // 
            pnlCliente.Controls.Add(cmbClientes);
            pnlCliente.Controls.Add(txtPorcentagemDesconto);
            pnlCliente.Controls.Add(label5);
            pnlCliente.Controls.Add(lblNomeCliente);
            pnlCliente.Enabled = false;
            pnlCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pnlCliente.Location = new Point(22, 25);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Size = new Size(468, 74);
            pnlCliente.TabIndex = 19;
            pnlCliente.TabStop = false;
            pnlCliente.Text = "Dados do Cliente:";
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(66, 37);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(218, 23);
            cmbClientes.TabIndex = 9;
            cmbClientes.SelectedIndexChanged += AtualizarPorcentagemDesconto;
            // 
            // txtPorcentagemDesconto
            // 
            txtPorcentagemDesconto.Enabled = false;
            txtPorcentagemDesconto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPorcentagemDesconto.Location = new Point(395, 37);
            txtPorcentagemDesconto.Name = "txtPorcentagemDesconto";
            txtPorcentagemDesconto.ReadOnly = true;
            txtPorcentagemDesconto.Size = new Size(56, 23);
            txtPorcentagemDesconto.TabIndex = 17;
            txtPorcentagemDesconto.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(300, 40);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 16;
            label5.Text = "% de Desconto:";
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomeCliente.Location = new Point(17, 40);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(43, 15);
            lblNomeCliente.TabIndex = 10;
            lblNomeCliente.Text = "Nome:";
            // 
            // pnlTema
            // 
            pnlTema.Controls.Add(cmbTemas);
            pnlTema.Controls.Add(txtValorTema);
            pnlTema.Controls.Add(label3);
            pnlTema.Controls.Add(lblNomeTema);
            pnlTema.Enabled = false;
            pnlTema.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pnlTema.Location = new Point(22, 115);
            pnlTema.Name = "pnlTema";
            pnlTema.Size = new Size(468, 75);
            pnlTema.TabIndex = 18;
            pnlTema.TabStop = false;
            pnlTema.Text = "Dados do Tema:";
            // 
            // cmbTemas
            // 
            cmbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTemas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTemas.FormattingEnabled = true;
            cmbTemas.Location = new Point(66, 37);
            cmbTemas.Name = "cmbTemas";
            cmbTemas.Size = new Size(218, 23);
            cmbTemas.TabIndex = 10;
            cmbTemas.SelectedIndexChanged += AtualizarValorTotal;
            // 
            // txtValorTema
            // 
            txtValorTema.Enabled = false;
            txtValorTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorTema.Location = new Point(395, 37);
            txtValorTema.Name = "txtValorTema";
            txtValorTema.ReadOnly = true;
            txtValorTema.Size = new Size(56, 23);
            txtValorTema.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(353, 40);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 16;
            label3.Text = "Valor:";
            // 
            // lblNomeTema
            // 
            lblNomeTema.AutoSize = true;
            lblNomeTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNomeTema.Location = new Point(17, 40);
            lblNomeTema.Name = "lblNomeTema";
            lblNomeTema.Size = new Size(43, 15);
            lblNomeTema.TabIndex = 10;
            lblNomeTema.Text = "Nome:";
            // 
            // pnlDadosAluguel
            // 
            pnlDadosAluguel.Controls.Add(cmbEntrada);
            pnlDadosAluguel.Controls.Add(label1);
            pnlDadosAluguel.Controls.Add(txtValorSinal);
            pnlDadosAluguel.Controls.Add(label2);
            pnlDadosAluguel.Controls.Add(txtValorDesconto);
            pnlDadosAluguel.Controls.Add(txtValorPendente);
            pnlDadosAluguel.Controls.Add(lblValorPendente);
            pnlDadosAluguel.Controls.Add(label4);
            pnlDadosAluguel.Enabled = false;
            pnlDadosAluguel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pnlDadosAluguel.Location = new Point(22, 205);
            pnlDadosAluguel.Name = "pnlDadosAluguel";
            pnlDadosAluguel.Size = new Size(468, 124);
            pnlDadosAluguel.TabIndex = 6;
            pnlDadosAluguel.TabStop = false;
            pnlDadosAluguel.Text = "Dados do Aluguel:";
            // 
            // cmbEntrada
            // 
            cmbEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrada.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmbEntrada.FormattingEnabled = true;
            cmbEntrada.Location = new Point(351, 51);
            cmbEntrada.Name = "cmbEntrada";
            cmbEntrada.Size = new Size(58, 23);
            cmbEntrada.TabIndex = 11;
            cmbEntrada.SelectedIndexChanged += AtualizarPorcentagemEntrada;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(266, 54);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 16;
            label1.Text = "% de Entrada:";
            // 
            // txtValorSinal
            // 
            txtValorSinal.Enabled = false;
            txtValorSinal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorSinal.Location = new Point(138, 80);
            txtValorSinal.Name = "txtValorSinal";
            txtValorSinal.ReadOnly = true;
            txtValorSinal.Size = new Size(100, 23);
            txtValorSinal.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 83);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 14;
            label2.Text = "Valor do Sinal:";
            // 
            // txtValorDesconto
            // 
            txtValorDesconto.Enabled = false;
            txtValorDesconto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorDesconto.Location = new Point(138, 51);
            txtValorDesconto.Name = "txtValorDesconto";
            txtValorDesconto.ReadOnly = true;
            txtValorDesconto.Size = new Size(100, 23);
            txtValorDesconto.TabIndex = 13;
            // 
            // txtValorPendente
            // 
            txtValorPendente.Enabled = false;
            txtValorPendente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorPendente.Location = new Point(351, 80);
            txtValorPendente.Name = "txtValorPendente";
            txtValorPendente.ReadOnly = true;
            txtValorPendente.Size = new Size(100, 23);
            txtValorPendente.TabIndex = 12;
            // 
            // lblValorPendente
            // 
            lblValorPendente.AutoSize = true;
            lblValorPendente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblValorPendente.Location = new Point(256, 83);
            lblValorPendente.Name = "lblValorPendente";
            lblValorPendente.Size = new Size(89, 15);
            lblValorPendente.TabIndex = 11;
            lblValorPendente.Text = "Valor Pendente:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 54);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 10;
            label4.Text = "Valor com Desconto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(473, 479);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConcluir
            // 
            btnConcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConcluir.DialogResult = DialogResult.OK;
            btnConcluir.Location = new Point(392, 479);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(75, 41);
            btnConcluir.TabIndex = 12;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = true;
            // 
            // TelaConclusaoAluguel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 528);
            Controls.Add(btnCancelar);
            Controls.Add(btnConcluir);
            Controls.Add(tabControl1);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Name = "TelaConclusaoAluguel";
            Text = "Conclusão de Aluguéis";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            pnlEndereco.ResumeLayout(false);
            pnlEndereco.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlTema.ResumeLayout(false);
            pnlTema.PerformLayout();
            pnlDadosAluguel.ResumeLayout(false);
            pnlDadosAluguel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DateTimePicker txtDataFesta;
        private Label lblData;
        private GroupBox pnlEndereco;
        private Label lblHorarioInicio;
        private Label lblHorarioTermino;
        private Button btnCancelar;
        private Button btnConcluir;
        private TextBox txtCidade;
        private TextBox txtBairro;
        private Label lblBairro;
        private Label lblCidade;
        private TextBox txtRua;
        private Label lblRua;
        private TextBox txtEstado;
        private Label lblEstado;
        private GroupBox pnlDadosAluguel;
        private Label label1;
        private TextBox txtValorSinal;
        private Label label2;
        private TextBox txtValorDesconto;
        private TextBox txtValorPendente;
        private Label lblValorPendente;
        private Label label4;
        private GroupBox pnlTema;
        private TextBox txtValorTema;
        private Label label3;
        private Label lblNomeTema;
        private ComboBox cmbTemas;
        private GroupBox pnlCliente;
        private ComboBox cmbClientes;
        private TextBox txtPorcentagemDesconto;
        private Label label5;
        private Label lblNomeCliente;
        private TextBox txtNumero;
        private Label lblNumero;
        private ComboBox cmbEntrada;
        private GroupBox groupBox1;
        private MaskedTextBox txtHorarioTermino;
        private MaskedTextBox txtHorarioInicio;
    }
}