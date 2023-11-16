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
    public partial class loginMod : Form
    {
        public loginMod()
        {
            InitializeComponent();
            txtSenha.PasswordChar = '*';
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos para continuar!");
            }
            else if (!Program.vereficaEmail(txtEmail.Text))
            {
                MessageBox.Show("Email inválido!");
            }
            else
            {
                moderador mod = new moderador();
                mod.Email = txtEmail.Text;
                mod.Senha = txtSenha.Text;
                if (!mod.vereficaSenha())
                    MessageBox.Show("Email ou Senha incorretos!");
                else
                {
                    MessageBox.Show("Bem vindo(a)!");
                    this.Hide();
                    new FrmJogos().ShowDialog();
                    this.Close();
                }
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "SHOW")
            {
                label3.Text = "HIDE";
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                label3.Text = "SHOW";
                txtSenha.PasswordChar = '*';
            }
        }

        
    }
}
