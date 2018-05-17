using ADOPuro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPuro.Apresentacao.ConsApp.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConexao = "Data Source=BEASE;Initial Catalog=estudos;Integrated Security=True;";

            var lstPais = new Infra.ADO.Persistencia(strConexao).ExibeResultadoDeConsultaAoBanco<pais>("SELECT * FROM pais where id_pais = 1");
            var lstRuas = new Infra.ADO.Persistencia(strConexao).ExibeResultadoDeConsultaAoBanco<ruas>("SELECT * FROM ruas");
        }
    }
}
