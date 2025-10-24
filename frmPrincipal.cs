using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            frmFuncionarios obj = new();
            obj.ShowDialog();
        }

        private void btnPratos_Click(object sender, EventArgs e)
        {
            frmPratos obj = new();
            obj.ShowDialog();
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            frmBebidas obj = new();
            obj.ShowDialog();
        }

        private void btnSobremesas_Click(object sender, EventArgs e)
        {
            frmSobremesas obj = new();
            obj.ShowDialog();
        }
    }
}
