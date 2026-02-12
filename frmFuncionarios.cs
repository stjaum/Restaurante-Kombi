using System.Data;
using Restaurante.BLL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmFuncionarios : Form
    {
        private string? usuarioSelecionadoId = null;
        UsuarioBLL usuarioBLL = new();
        public frmFuncionarios()
        {
            InitializeComponent();
        }



        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuario();
        }
        private void BuscarUsuario()
        {
            string validacao = txtPesquisar.Text.Trim().ToLower();

            var filtrados = usuarioBLL.ListarUsuarios().
                Where(usuario => usuario.Nome.ToLower().Contains(validacao)).
                Select(usuario => new
                {

                    usuario.Nome,
                    usuario.Email,
                    usuario.Senha,
                    usuario.UrlFoto

                }).ToList();

            dgFuncionarios.DataSource = filtrados;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionadoId != null)
            {
                btnAtualizar.Enabled = true;
                try
                {
                    var usuarioAtualizado = new UsuarioDTO
                    {
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        Senha = txtSenha.Text,
                    };
                    usuarioBLL.AtualizarUsuario(usuarioAtualizado);
                    MessageBox.Show("Usuário atualizado!");
                    txtNome.Clear();
                    usuarioSelecionadoId = null;

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Erro: {ex.Message}");
                }
                AtualizarGrid();

            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um funcionário para remover!");
                return;
            }

            string nome = dgFuncionarios.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o usuário {nome}?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                usuarioBLL.RemoverUsuario(nome);
                MessageBox.Show($"Funcionário {nome} removido com sucesso!");
                AtualizarGrid();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionario obj = new();
            obj.ShowDialog();
        }
        private void AtualizarGrid()
        {
            dgFuncionarios.Columns.Clear();
            dgFuncionarios.AutoGenerateColumns = false;
            dgFuncionarios.RowTemplate.Height = 60;
            dgFuncionarios.AllowUserToAddRows = false;

            var colFoto = new DataGridViewImageColumn
            {
                HeaderText = "Foto",
                Name = "Foto",
                DataPropertyName = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,

            };

            dgFuncionarios.Columns.Add(colFoto);

            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha", Name = "Senha" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UrlFoto", HeaderText = "UrlFoto", Name = "UrlFoto" });

            var usuarios = usuarioBLL.ListarUsuarios();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Senha", typeof(string));
            dt.Columns.Add("UrlFoto", typeof(string));

            foreach (var u in usuarios)
            {
                Image? img = null;

                if (!string.IsNullOrEmpty(u.UrlFoto) && File.Exists(u.UrlFoto))
                {
                    try
                    {
                        using (var fs = new FileStream(u.UrlFoto, FileMode.Open, FileAccess.Read))
                        {
                            img = Image.FromStream(fs);
                        }
                    }
                    catch (Exception)
                    {
                        img = null;

                    }
                }
                dt.Rows.Add(img, u.Id, u.Nome, u.Email, u.Senha, u.UrlFoto);
            }
            dgFuncionarios.DataSource = dt;
        }

        private void dgFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarGrid();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

