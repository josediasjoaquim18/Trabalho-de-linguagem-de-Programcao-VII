using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroElectronicoUtente.Modelo
{
    public class RegistoClinico
    {
        public DateTime DataAtendimento { get; set; }
        public string Diagnostico { get; set; }
        public string Observacoes { get; set; }

        public RegistoClinico(DateTime data, string diagnostico, string observacoes)
        {
            DataAtendimento = data;
            Diagnostico = diagnostico;
            Observacoes = observacoes;
        }

    }
}
