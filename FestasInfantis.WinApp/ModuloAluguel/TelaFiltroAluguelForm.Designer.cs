namespace FestasInfantis.WinApp.ModuloAluguel
{
    partial class TelaFiltroAluguelForm
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
            groupBox1 = new GroupBox();
            rdbAlugueisConcluidos = new RadioButton();
            rdbAlugueisPendentes = new RadioButton();
            rdbTodos = new RadioButton();
            btnCancelar = new Button();
            btnGravar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbAlugueisConcluidos);
            groupBox1.Controls.Add(rdbAlugueisPendentes);
            groupBox1.Controls.Add(rdbTodos);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 147);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Escolha o Filtro:";
            // 
            // rdbAlugueisConcluidos
            // 
            rdbAlugueisConcluidos.AutoSize = true;
            rdbAlugueisConcluidos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbAlugueisConcluidos.Location = new Point(16, 97);
            rdbAlugueisConcluidos.Name = "rdbAlugueisConcluidos";
            rdbAlugueisConcluidos.Size = new Size(134, 19);
            rdbAlugueisConcluidos.TabIndex = 2;
            rdbAlugueisConcluidos.TabStop = true;
            rdbAlugueisConcluidos.Text = "Aluguéis Concluídos";
            rdbAlugueisConcluidos.UseVisualStyleBackColor = true;
            // 
            // rdbAlugueisPendentes
            // 
            rdbAlugueisPendentes.AutoSize = true;
            rdbAlugueisPendentes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbAlugueisPendentes.Location = new Point(16, 67);
            rdbAlugueisPendentes.Name = "rdbAlugueisPendentes";
            rdbAlugueisPendentes.Size = new Size(129, 19);
            rdbAlugueisPendentes.TabIndex = 1;
            rdbAlugueisPendentes.TabStop = true;
            rdbAlugueisPendentes.Text = "Aluguéis Pendentes";
            rdbAlugueisPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            rdbTodos.AutoSize = true;
            rdbTodos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdbTodos.Location = new Point(16, 37);
            rdbTodos.Name = "rdbTodos";
            rdbTodos.Size = new Size(120, 19);
            rdbTodos.TabIndex = 0;
            rdbTodos.TabStop = true;
            rdbTodos.Text = "Todos os Aluguéis";
            rdbTodos.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(235, 186);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(154, 186);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 239);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Name = "TelaFiltroAluguelForm";
            Text = "Filtrar Listagem de Aluguéis";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rdbTodos;
        private RadioButton rdbAlugueisConcluidos;
        private RadioButton rdbAlugueisPendentes;
        private Button btnCancelar;
        private Button btnGravar;
    }
}