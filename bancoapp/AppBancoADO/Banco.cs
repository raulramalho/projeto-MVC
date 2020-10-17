using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoADO
{
    public class Banco:IDisposable
    {
        private readonly MySqlConnection conexao;
            public Banco()
            {
                conexao = new MySqlConnection("server = localhost; user id = root; database = dbexemplo");
                conexao.Open();
            }

      
        public void ExecutaComando(string strQuery)
            {
                var vComando = new MySqlCommand
                {
                    CommandText = strQuery,
                    CommandType = System.Data.CommandType.Text,
                    Connection = conexao,
                    
                };
            vComando.ExecuteNonQuery();
        }



            public MySqlDataReader RetornaComando(string strQuery)
            {
                var comando = new MySqlCommand(strQuery, conexao);
                return comando.ExecuteReader();
            }
        public void Dispose()
        {
            if(conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

    }
}

