using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ATEX2023_2
{
    internal class User
    {
        private string nome, escola;
        private int idade, anoEscolar;
        private conexãoDados objetoConexao = new conexãoDados();
        public string Nome { get => nome; set => nome = value; }
        public string Escola { get => escola; set => escola = value; }
        public int Idade { get => idade; set => idade = value; }
        public int AnoEscolar { get => anoEscolar; set => anoEscolar = value; }

        public void incluirDados()
        {
            objetoConexao.Executar($"insert into usuario (Nome, Escola, Idade, Ano_Escolar) values ('{Nome}','{Escola}','{Idade}','{AnoEscolar}') ");
        }
    }
}
