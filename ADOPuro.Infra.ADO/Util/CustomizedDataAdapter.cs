using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADOPuro.Infra.ADO.Util
{
    public class CustomizedDataAdapter
    {
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
    }
}
