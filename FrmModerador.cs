﻿using System;
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
    public partial class FrmModerador : MetroFramework.Forms.MetroForm
    {
        public FrmModerador()
        {
            InitializeComponent();
            txtSenha.PasswordChar = '*';
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == string.Empty || txtEmail.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos para continuar");
            }
            else if (!Program.vereficaEmail(txtEmail.Text)){
                MessageBox.Show("Email inválido!");
            }
            else
            {
                moderador mod = new moderador();
                mod.Nome = txtNome.Text;
                mod.Email = txtEmail.Text;
                mod.Senha = txtSenha.Text;
                mod.incluirDados();
                MessageBox.Show($"Moderador cadastrado com sucesso!");
                txtEmail.Text = txtSenha.Text = txtNome.Text = "";
                new loginMod().ShowDialog();
                this.Close();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new loginMod().ShowDialog();
            this.Close();
        }
    }
}
