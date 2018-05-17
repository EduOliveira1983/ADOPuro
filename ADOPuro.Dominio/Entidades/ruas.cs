using System;

namespace ADOPuro.Dominio.Entidades
{
    public class ruas
    {
        public int id_rua { get; set; } // int, not null
        public string nome { get; set; } // varchar(100), not null
        public string cep { get; set; } // varchar(10), not null
        public string referencia { get; set; } // varchar(100), null
        public DateTime data_cadastro { get; set; } // datetime, not null

        public ruas(ruas objruas)
        {
            id_rua = objruas.id_rua;
            nome = objruas.nome;
            cep = objruas.cep;
            referencia = objruas.referencia;
            data_cadastro = objruas.data_cadastro;
        }

        public ruas()
        {
        }


    }
}
