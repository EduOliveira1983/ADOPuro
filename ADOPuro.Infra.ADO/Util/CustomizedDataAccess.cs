using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace ADOPuro.Infra.ADO.Util
{
    public class CustomizedDataAccess
    {
        private readonly string strConexao = Properties.Settings.Default.Conexao;

        public List<T> ExibeResultadoDeConsultaAoBanco<T>(string query)
        {
            using (var conexao = new SqlConnection(strConexao))
            {
                SqlCommand command = new SqlCommand(query, conexao);

                conexao.Open();
                SqlDataReader reader = command.ExecuteReader();
                return ProcessarRespostaBanco<T>(ref reader);
            }
        }

        public List<T> ProcessarRespostaBanco<T>(ref SqlDataReader reader)
        {            
            List<T> lstRetorno = new List<T>();
            var objeto = Activator.CreateInstance<T>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var count = reader.FieldCount;
                    var index = 0;

                    while (index < count)
                    {
                        PreencherObjeto(new ConfiguracaoColuna
                        {
                            NomeClasse = objeto.GetType().Name,
                            NomeColuna = reader.GetName(index),
                            TipoDado = reader.GetFieldType(index),
                            ValorColuna = reader.GetValue(index)
                        }, objeto);

                        index++;
                    }                    
                    lstRetorno.Add((T)Activator.CreateInstance(typeof(T), new object[] { objeto }));
                }

                return lstRetorno;
            }
            else
                return null;            
        }

        private void PreencherObjeto<T>(ConfiguracaoColuna coluna, T objetoDestino)
        {
            var property = objetoDestino.GetType().GetProperty(coluna.NomeColuna);

            if (property != null)
                property.SetValue(objetoDestino, coluna.ValorColuna);
        }

       

        public void ExecutaEscritaNoBanco<T>(string comando, List<T> parametros, string strConexao)
        {            
            using (var conexao = new SqlConnection(strConexao))
            {
                var parameters = new SqlParameter[5] {
                    new SqlParameter("@Nome","Serie B"),
                    new SqlParameter("@DataInicio",DateTime.Now),
                    new SqlParameter("@DataTermino",DateTime.Now),
                    new SqlParameter("@DataAtualizacao",DateTime.Now),
                    new SqlParameter("@Peso", 90.3)
                };

                conexao.Open();

                SqlCommand command = new SqlCommand(comando, conexao);
                command.Parameters.AddRange(parameters);

                command.ExecuteNonQuery();

                Console.WriteLine("Linha adiconada");
            }
        }
    }
}
