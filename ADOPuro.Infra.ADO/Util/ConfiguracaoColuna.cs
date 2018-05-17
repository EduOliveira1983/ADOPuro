using System;

namespace ADOPuro.Infra.ADO.Util
{
    internal class ConfiguracaoColuna
    {
        public Type TipoDado { get; set; }
        public string NomeClasse { get; set; }
        public string NomeColuna { get; set; }
        public object ValorColuna { get; set; }
    }
}
