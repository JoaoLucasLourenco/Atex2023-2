using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEX2023_2
{
    internal class moderador
    {
        private string nome, email, senha;
        private conexãoDados objetoConexao = new conexãoDados();
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }

        public void incluirDados()
        {
            objetoConexao.Executar($"insert into moderador (Nome, Email, Senha) values ('{Nome}','{Email}',hashbytes('md5','{Senha}')) ");
        }
        public bool vereficaSenha()
        {
            return objetoConexao.returnFunc(Senha, Email)=="True"?true:false;
        }
    }
}
