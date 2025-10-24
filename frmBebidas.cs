using System.Data;
using Restaurante.BLL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmBebidas : Form
    {
        private string? bebidaSelecionadoCod = null;
        BebidaBLL bebidaBLL = new();
        public frmBebidas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarBebidas();
        }
        private void BuscarBebidas()
        {
            string validacao = txtPesquisar.Text.Trim().ToLower();

            var filtrados = bebidaBLL.ListarBebidas().
                Where(bebida => bebida.Nome.ToLower().Contains(validacao)).
                Select(bebida => new
                {

                    bebida.Cod,
                    bebida.Nome,
                    bebida.Preco,
                    bebida.UrlFoto

                }).ToList();

            dgProdutos.DataSource = filtrados;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma bebida para remover!");
                return;
            }

            string nome = dgProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir a bebida {nome}?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                bebidaBLL.RemoverBebida(nome);
                MessageBox.Show($"bebida {nome} removido com sucesso!");
                AtualizarGrid();
            }

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

            var bebidas = bebidaBLL.ListarBebidas();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Cod", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Preco", typeof(string));
            dt.Columns.Add("UrlFoto", typeof(string));

            foreach (var u in bebidas)
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (bebidaSelecionadoCod != null)
            {
                btnAtualizar.Enabled = true;
                try
                {
                    var bebidaAtualizado = new BebidaDTO
                    {
                        Nome = txtNome.Text,
                        Preco = decimal.Parse(txtPreco.Text),
                    };
                    bebidaBLL.AtualizarBebida(bebidaAtualizado);
                    MessageBox.Show("bebida atualizado!");
                    txtNome.Clear();
                    bebidaSelecionadoCod = null;

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Erro: {ex.Message}");
                }
                AtualizarGrid();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroBebidas obj = new();
            obj.ShowDialog();
        }
    }
}
