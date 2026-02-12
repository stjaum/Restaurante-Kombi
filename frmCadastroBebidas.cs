using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmCadastroBebidas : Form
    {
        BebidaDTO bebidaDTO = new();
        BebidaBLL bebidaBLL = new();
        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Restaurante\Funcionarios";
        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmCadastroBebidas()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

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

        private void frmCadastroBebidas_Load(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Nome da imagem a ser salva
            string nomeImg = $"{DataBase.Bebidas.Count + 1} - {txtNome.Text}.jpg";

            //verifica se o diretório para salvar as imagens existe.
            if (!Directory.Exists(diretorio))
            {
                //caso não exista, cria o diretório.
                Directory.CreateDirectory(diretorio);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
