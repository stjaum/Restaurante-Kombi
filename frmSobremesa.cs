using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmSobremesa : Form
    {
        SobremesaDTO sobremesaDTO = new();
        SobremesaBLL sobremesaBLL = new();

        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Restaurante\Funcionarios";
        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmSobremesa()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click_1(object sender, EventArgs e)
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

        private void frmSobremesa_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nomeImg = $"{DataBase.Sobremesas.Count + 1} - {txtNome.Text}.jpg";

            if (!Directory.Exists(diretorio))
            {

                Directory.CreateDirectory(diretorio);
            }

            string urlImagem = Path.Combine(diretorio, nomeImg);

            Image imagem = pbFoto.Image;
            imagem.Save(urlImagem);

            var Sobremesas = new SobremesaDTO
            {
                Cod = DataBase.Sobremesas.Count + 1,
                Nome = txtNome.Text,
                UrlFoto = txtUrl.Text,

            };
            sobremesaBLL.CadastrarSobremesa(Sobremesas);

            MessageBox.Show($"Produto: {Sobremesas.Nome} cadastrado com sucesso!");

            txtNome.Text = string.Empty;
            pbFoto.Image = null;
        }
    }
}
