using ADOPuro.Infra.ADO.Util;
using System.Collections.Generic;

namespace ADOPuro.Infra.ADO.Repositorios.Base
{
    public abstract class RepositorioBase<T> where T : class
    {
        private CustomizedDataAccess objDA;
        public RepositorioBase()
        {
            if (objDA == null)
                objDA = new CustomizedDataAccess();
        }

        public List<T> Listar(string comando)
        {
            return objDA.ExibeResultadoDeConsultaAoBanco<T>(comando);
        }

    }
}
