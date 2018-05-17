using ADOPuro.Dominio.Entidades;
using ADOPuro.Infra.ADO.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPuro.Infra.ADO.Repositorios
{
    public  class PaisRepositorio : RepositorioBase<pais>
    {
        public List<pais> Listar()
        {
            return Listar("select * from pais");
        }

    }
}
