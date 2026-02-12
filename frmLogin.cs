using Restaurante.BLL;

namespace Restaurante.UI
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioBLL usuarioBLL = new();
        public frmLogin()
        {
            InitializeComponent();
        }





        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = usuarioBLL.Email(txtLogin.Text, txtSenha.Text);
                Session.UsuarioLogado = usuario;
                MessageBox.Show($"Bem vindo (a) {Session.UsuarioLogado.Nome}");

                frmPrincipal principal = new();
                principal.Show();
                Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionario obj = new();
            obj.ShowDialog();
        }
    }
}
