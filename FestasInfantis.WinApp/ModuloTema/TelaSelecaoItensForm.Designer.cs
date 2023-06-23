namespace FestasInfantis.WinApp.ModuloTema
{
    partial class TelaSelecaoItensForm
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
            listItensTema = new CheckedListBox();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // listItensTema
            // 
            listItensTema.CheckOnClick = true;
            listItensTema.FormattingEnabled = true;
            listItensTema.Location = new Point(0, 0);
            listItensTema.Name = "listItensTema";
            listItensTema.Size = new Size(425, 346);
            listItensTema.TabIndex = 0;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(338, 357);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 1;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaSelecaoItensForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 410);
            Controls.Add(btnGravar);
            Controls.Add(listItensTema);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaSelecaoItensForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Selecionar Itens do Tema";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox listItensTema;
        private Button btnGravar;
    }
}