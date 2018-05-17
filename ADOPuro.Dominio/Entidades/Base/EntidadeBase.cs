using System;

namespace ADOPuro.Dominio.Entidades.Base
{
    public abstract class EntidadeBase : Attribute
    {
        
        public string NomeTabela { get; private set; }

        
        public EntidadeBase()
        {

        }
    }
}
