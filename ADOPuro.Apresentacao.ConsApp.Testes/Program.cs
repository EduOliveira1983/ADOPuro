using ADOPuro.Dominio.Entidades;
using ADOPuro.Infra.ADO.Repositorios;
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
            var lstPais = new PaisRepositorio().Listar();
            var lstPais2 = new PaisRepositorio().Listar();
        }
    }
}
