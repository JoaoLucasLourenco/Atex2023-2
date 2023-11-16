using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEX2023_2
{
    public partial class FrmCadastro : MetroFramework.Forms.MetroForm
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmModerador frmModerador = new FrmModerador();
            this.Hide();
            frmModerador.ShowDialog();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            User usuario = new User();
            FrmInicio frmInicio = new FrmInicio();
            this.Hide();
            frmInicio.ShowDialog();
            this.Close();
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }
    }
}
