using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppBanco
{
    public class Banco
    {
        private readonly MySqlConnection conexao;

        public Banco()
        {
            conexao = new MySqlConnection("server=localhost; User ID=teste1_db_turismo; database=teste1_db_turismo; password=turismosa");
            conexao.Open();
        }
        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
        public void ExecutaComando(string strComando)
        {
            var vComando = new MySqlCommand
            {
                CommandText = strComando,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }
        public MySqlDataReader RetornaComando(string strComando)
        {
            var vComando = new MySqlCommand(strComando, conexao);

            return vComando.ExecuteReader();
        }
    }
}
