using System.Text.Json.Nodes;
using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class frmCadastroFuncionario : Form
    {
        UsuarioDTO usuarioDTO = new();
        UsuarioBLL usuarioBLL = new();
        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\Restaurante\Funcionarios";
        string diretorioImagens = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}";
        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCadastroFuncionario_Load(object sender, EventArgs e)
        {
            if (!DataBase.Cargos.Any())
            {
                DataBase.Cargos.Add(new CargoDTO { Id = 1, Nome = "Gerente" });
                DataBase.Cargos.Add(new CargoDTO { Id = 2, Nome = "Cozinheiro" });
                DataBase.Cargos.Add(new CargoDTO { Id = 3, Nome = "Garçom" });
                DataBase.Cargos.Add(new CargoDTO { Id = 4, Nome = "Atendente" });
            }
            cboCargo.DataSource = DataBase.Cargos;  
            cboCargo.DisplayMember = "Nome"; 
            cboCargo.ValueMember = "Id"; 

            

            cboCargo.DropDownStyle = ComboBoxStyle.DropDownList;
           
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           
            string nomeImg = $"{DataBase.Usuarios.Count + 1} - {txtEmail.Text}.jpg";
            
            if (!Directory.Exists(diretorio))
            {
                
                Directory.CreateDirectory(diretorio);
            }
            
            string urlImagem = Path.Combine(diretorio, nomeImg);

            Image imagem = pbFoto.Image;
            imagem.Save(urlImagem);

            var usuario = new UsuarioDTO
            {
                Id = DataBase.Usuarios.Count + 1,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                UrlFoto = txtUrl.Text,
                Cargo = cboCargo.Text,
            };
            usuarioBLL.CadastrarUsuario(usuario);

            MessageBox.Show($"Usuário: {usuario.Nome} cadastrado com sucesso!");

            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
            pbFoto.Image = null;

        }

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
    }
}
