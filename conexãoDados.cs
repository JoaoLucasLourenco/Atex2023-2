using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEX2023_2
{
    internal class conexãoDados
    {
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private string campos;
        private byte[] foto;

        public string Campos { get => campos; set => campos = value; }
        public byte[] Foto { get => foto; set => foto = value; }

        public void Conectar()
        {
            string aux = "Server = .\\; Database = ATEX PII; UID = sa; PWD = 123";
            conn.ConnectionString = aux;
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }

        public void Executar(string sql)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (Foto != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@BINARIO", SqlDbType.Image);
                cmd.Parameters["@BINARIO"].Value = Foto;
            }
            cmd.ExecuteNonQuery();
            Desconectar();
        }


        public string returnFunc(string senha, string email)
        {
            Conectar();
            string resultado="";
            using (SqlCommand cmd = new SqlCommand("SELECT [dbo].[ModPwdVerification](@senha, @email)", conn))
            {
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.Parameters.AddWithValue("@email", email);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultado = reader[0].ToString();
                    }
                }
            }
            Desconectar();
            return resultado;
        }

        public DataSet ListarDados(string sql)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Desconectar();
            return ds;
        }
    }
}
