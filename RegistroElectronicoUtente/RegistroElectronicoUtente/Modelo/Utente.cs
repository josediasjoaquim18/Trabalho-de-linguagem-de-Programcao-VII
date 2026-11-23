using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroElectronicoUtente.Modelo
{
    public class Utente
    {
        public string NumeroRegisto { get; private set; } 
        public string Nome { get; set; }
        public string NIF { get; set; } 
        public DateTime DataNascimento { get; set; }

        
        public List<RegistoClinico> HistoricoClinico { get; private set; }

        public Utente(string nome, string nif, DateTime dataNascimento)
        {
            
            NumeroRegisto = "UT-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            Nome = nome;
            NIF = nif;
            DataNascimento = dataNascimento;
            HistoricoClinico = new List<RegistoClinico>();
        }
    }
}
