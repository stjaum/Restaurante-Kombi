using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmCadastroProduto : Form
    {
        PratoDTO pratoDTO = new();
        PratoBLL pratoBLL = new();
        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Restaurante\Funcionarios";
        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }
            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = diretorioImagens;
            openFileDialog.Filter = "Arquivos de Imagens |*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Escolha a imagem e se transforme";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = openFileDialog.FileName;


                pbFoto.Image = Image.FromFile(nomeArquivoImagem);


                txtUrl.Text = nomeArquivoImagem;
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nomeImg = $"{DataBase.Pratos.Count + 1} - {txtNome.Text}.jpg";

            if (!Directory.Exists(diretorio))
            {

                Directory.CreateDirectory(diretorio);
            }

            string urlImagem = Path.Combine(diretorio, nomeImg);

            Image imagem = pbFoto.Image;
            imagem.Save(urlImagem);

            var Pratos = new PratoDTO
            {
                Cod = DataBase.Pratos.Count + 1,
                Nome = txtNome.Text,
                               
                UrlFoto = txtUrl.Text,
               
            };
            pratoBLL.CadastrarPrato(Pratos);

            MessageBox.Show($"Produto: {Pratos.Nome} cadastrado com sucesso!");

            txtNome.Text = string.Empty;
            pbFoto.Image = null;
        }
    }
}
