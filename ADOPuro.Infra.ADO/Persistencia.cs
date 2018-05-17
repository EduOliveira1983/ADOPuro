using ADOPuro.Infra.ADO.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPuro.Infra.ADO
{
    public class Persistencia
    {
        private string strConexao = string.Empty;
        private CustomizedDataAdapter adapter;

        public Persistencia(string conexao)
        {
            strConexao = conexao;
            adapter = new CustomizedDataAdapter();
        }

        public List<T> ExibeResultadoDeConsultaAoBanco<T>(string query)
        {
            using (var conexao = new SqlConnection(strConexao))
            {
                SqlCommand command = new SqlCommand(query, conexao);
                
                conexao.Open();
                SqlDataReader reader = command.ExecuteReader();
                return  adapter.ProcessarRespostaBanco<T>(ref reader);
            }               
        }
    }
}
