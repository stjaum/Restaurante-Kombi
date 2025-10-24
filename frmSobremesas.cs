using System.Data;
using Restaurante.BLL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmSobremesas : Form
    {
        private string? sobremesaSelecionadoCod = null;
        SobremesaBLL sobremesaBLL = new();
        public frmSobremesas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSobremesas_Load(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarSobremesa();
        }
        private void BuscarSobremesa()
        {
            string validacao = txtPesquisar.Text.Trim().ToLower();

            var filtrados = sobremesaBLL.ListarSobremesa().
                Where(sobremesa => sobremesa.Nome.ToLower().Contains(validacao)).
                Select(sobremesa => new
                {

                    sobremesa.Cod,
                    sobremesa.Nome,
                    sobremesa.Preco,
                    sobremesa.UrlFoto

                }).ToList();

            dgProdutos.DataSource = filtrados;
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma sobremesa para remover!");
                return;
            }

            string nome = dgProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show($"Tem certeza que deseja excluir a sobremesa {nome}?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                sobremesaBLL.RemoverSobremesa(nome);
                MessageBox.Show($"sobremesa {nome} removido com sucesso!");
                AtualizarGrid();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (sobremesaSelecionadoCod != null)
            {
                btnAtualizar.Enabled = true;
                try
                {
                    var sobremesaAtualizado = new SobremesaDTO
                    {
                        Nome = txtNome.Text,
                        Preco = decimal.Parse(txtPreco.Text),
                    };
                    sobremesaBLL.AtualizarSobremesa(sobremesaAtualizado);
                    MessageBox.Show("sobremesa atualizado!");
                    txtNome.Clear();
                    sobremesaSelecionadoCod = null;

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Erro: {ex.Message}");
                }
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

            var sobremesas = sobremesaBLL.ListarSobremesa();

            var dt = new DataTable();
            dt.Columns.Add("Foto", typeof(Image));
            dt.Columns.Add("Cod", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Preco", typeof(string));
            dt.Columns.Add("UrlFoto", typeof(string));

            foreach (var u in sobremesas)
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmSobremesa obj = new();
            obj.ShowDialog();
        }
    }
}
