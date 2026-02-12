namespace Restaurante.UI
{
    partial class frmCadastroProduto
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnCadastrar = new Guna.UI2.WinForms.Guna2Button();
            btnFechar = new Guna.UI2.WinForms.Guna2CircleButton();
            txtPreco = new Guna.UI2.WinForms.Guna2TextBox();
            txtCod = new Guna.UI2.WinForms.Guna2TextBox();
            txtNome = new Guna.UI2.WinForms.Guna2TextBox();
            pbFoto = new PictureBox();
            txtUrl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 20;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BorderRadius = 20;
            btnCadastrar.CustomizableEdges = customizableEdges1;
            btnCadastrar.DisabledState.BorderColor = Color.DarkGray;
            btnCadastrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCadastrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCadastrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCadastrar.FillColor = Color.DarkGreen;
            btnCadastrar.Font = new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.Location = new Point(185, 309);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCadastrar.Size = new Size(200, 41);
            btnCadastrar.TabIndex = 24;
            btnCadastrar.Text = "CADASTRAR";
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnFechar
            // 
            btnFechar.BorderColor = Color.Brown;
            btnFechar.DisabledState.BorderColor = Color.DarkGray;
            btnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFechar.FillColor = SystemColors.Control;
            btnFechar.Font = new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFechar.ForeColor = Color.Red;
            btnFechar.Location = new Point(337, -7);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnFechar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnFechar.Size = new Size(61, 54);
            btnFechar.TabIndex = 23;
            btnFechar.Text = "X";
            btnFechar.Click += btnFechar_Click;
            // 
            // txtPreco
            // 
            txtPreco.BorderRadius = 5;
            txtPreco.CustomizableEdges = customizableEdges4;
            txtPreco.DefaultText = "";
            txtPreco.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPreco.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPreco.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPreco.Font = new Font("Segoe UI", 9F);
            txtPreco.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPreco.Location = new Point(185, 227);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "Preço";
            txtPreco.SelectedText = "";
            txtPreco.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtPreco.Size = new Size(200, 36);
            txtPreco.TabIndex = 20;
            // 
            // txtCod
            // 
            txtCod.BorderRadius = 5;
            txtCod.CustomizableEdges = customizableEdges6;
            txtCod.DefaultText = "";
            txtCod.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCod.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCod.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCod.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCod.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCod.Font = new Font("Segoe UI", 9F);
            txtCod.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCod.Location = new Point(185, 143);
            txtCod.Name = "txtCod";
            txtCod.PlaceholderText = "Código";
            txtCod.SelectedText = "";
            txtCod.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtCod.Size = new Size(200, 36);
            txtCod.TabIndex = 21;
            txtCod.TextChanged += txtCod_TextChanged;
            // 
            // txtNome
            // 
            txtNome.BorderRadius = 5;
            txtNome.CustomizableEdges = customizableEdges8;
            txtNome.DefaultText = "";
            txtNome.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNome.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNome.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNome.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNome.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Location = new Point(185, 185);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.SelectedText = "";
            txtNome.ShadowDecoration.CustomizableEdges = customizableEdges9;
            txtNome.Size = new Size(200, 36);
            txtNome.TabIndex = 22;
            // 
            // pbFoto
            // 
            pbFoto.BorderStyle = BorderStyle.Fixed3D;
            pbFoto.Location = new Point(12, 101);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(168, 185);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 19;
            pbFoto.TabStop = false;
            pbFoto.Click += pbFoto_Click;
            // 
            // txtUrl
            // 
            txtUrl.BackColor = Color.Transparent;
            txtUrl.Font = new Font("Ravie", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUrl.Location = new Point(11, 322);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(98, 21);
            txtUrl.TabIndex = 16;
            txtUrl.Text = "Url da Foto";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(11, 71);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(181, 24);
            guna2HtmlLabel2.TabIndex = 17;
            guna2HtmlLabel2.Text = "Selecione a foto.";
            guna2HtmlLabel2.Click += guna2HtmlLabel2_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Ravie", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(11, 33);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(281, 32);
            guna2HtmlLabel1.TabIndex = 18;
            guna2HtmlLabel1.Text = "Cadastro de Pratos";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // frmCadastroProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 360);
            Controls.Add(btnCadastrar);
            Controls.Add(btnFechar);
            Controls.Add(txtPreco);
            Controls.Add(txtCod);
            Controls.Add(txtNome);
            Controls.Add(pbFoto);
            Controls.Add(txtUrl);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCadastroProduto";
            Text = "frmCadastroProduto";
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnCadastrar;
        private Guna.UI2.WinForms.Guna2CircleButton btnFechar;
        private Guna.UI2.WinForms.Guna2TextBox txtPreco;
        private Guna.UI2.WinForms.Guna2TextBox txtCod;
        private Guna.UI2.WinForms.Guna2TextBox txtNome;
        private PictureBox pbFoto;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtUrl;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}