using System;

namespace ADOPuro.Dominio.Entidades
{
    public class pais
    {        
        public int id_pais { get; set; } // int, not null
        public string sigla { get; set; } // varchar(2), not null
        public string nome { get; set; } // varchar(80), not null
        public DateTime data_cadastro { get; set; } // datetime, not null

        public pais(pais objpais)
        {
            id_pais = objpais.id_pais;
            sigla = objpais.sigla;
            nome = objpais.nome;
            data_cadastro = objpais.data_cadastro;
        }

        public pais()
        {
        }
    }

}
