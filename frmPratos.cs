using System.Data;
using Restaurante.BLL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmPratos : Form
    {
        private string? pratoSelecionadoCod = null;
        PratoBLL pratoBLL = new();
        public frmPratos()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPratos_Load(object sender, EventArgs e)
        {

        }
        private void BuscarPrato()
        {
            string validacao = txtPesquisar.Text.Trim().ToLower();

            var filtrados = pratoBLL.ListarPratos().
                Where(prato => prato.Nome.ToLower().Contains(validacao)).
                Select(prato => new
                {

                    prato.Cod,
                    prato.Nome,
                    prato.Preco,
                    prato.UrlFoto

                }).ToList();

            dgProdutos.DataSource = filtrados;
        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarPrato();
        }
        private void AtualizarGrid()
        {
            dgProdutos.Columns.Clear();
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.RowTemplate.Height = 60;
            dgProdutos.AllowUserToAddRows = false;

            var colFoto = new DataGridViewImageColumn
            {
                HeaderText = "Foto",
                Name = "Foto",
                DataPropertyName = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,

            };

            dgProdutos.Columns.Add(colFoto);

            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cod", HeaderText = "COD", Name = "Cod" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preco", Name = "Preco" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UrlFoto", HeaderText = "UrlFoto", Name = "UrlFoto" });

            var pratos = pratoBLL.ListarPratos();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Cod", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Preco", typeof(string));
            dt.Columns.Add("UrlFoto", typeof(string));

            foreach (var u in pratos)
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
                dt.Rows.Add(img, u.Cod, u.Nome, u.Preco, u.UrlFoto);
            }
            dgProdutos.DataSource = dt;
        }
        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (pratoSelecionadoCod != null)
            {
                btnAtualizar.Enabled = true;
                try
                {
                    var pratoAtualizado = new PratoDTO
                    {
                        Nome = txtNome.Text,

                        Preco = decimal.Parse(txtPreco.Text),
                        
                    };
                    pratoBLL.AtualizarPrato(pratoAtualizado);
                    MessageBox.Show("Prato atualizado!");
                    txtNome.Clear();
                    pratoSelecionadoCod = null;

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
            if (dgProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um prato para remover!");
                return;
            }

            string nome = dgProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o prato {nome}?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                pratoBLL.RemoverPrato(nome);
                MessageBox.Show($"Prato {nome} removido com sucesso!");
                AtualizarGrid();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroProduto obj = new();
            obj.ShowDialog();
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
