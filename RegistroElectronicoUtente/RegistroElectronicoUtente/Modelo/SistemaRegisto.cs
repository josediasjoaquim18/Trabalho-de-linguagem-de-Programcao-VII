using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroElectronicoUtente.Modelo
{
   public  class SistemaRegisto
    {

        private Dictionary<string, Utente> _utentes;

        public SistemaRegisto()
        {
            _utentes = new Dictionary<string, Utente>();
        }

        public Utente RegistarNovoUtente(string nome, string nif, DateTime dataNascimento)
        {
            Utente novoUtente = new Utente(nome, nif, dataNascimento);
            _utentes.Add(novoUtente.NumeroRegisto, novoUtente);
            return novoUtente;
        }

        public Utente ProcurarUtente(string numeroRegisto)
        {
            if (_utentes.ContainsKey(numeroRegisto))
            {
                return _utentes[numeroRegisto];
            }
            return null; 
        }

       
        public void AdicionarConsulta(string numeroRegisto, DateTime data, string diagnostico, string observacoes)
        {
            Utente utente = ProcurarUtente(numeroRegisto);
            if (utente != null)
            {
                RegistoClinico novoRegisto = new RegistoClinico(data, diagnostico, observacoes);
                utente.HistoricoClinico.Add(novoRegisto);
                Console.WriteLine("Consulta adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: Utente não encontrado.");
            }
        }

        public void ConsultarHistorico(string numeroRegisto, string funcaoProfissional)
        {
            Utente utente = ProcurarUtente(numeroRegisto);

            if (utente == null)
            {
                Console.WriteLine("Utente não encontrado.");
                return;
            }

            
            if (funcaoProfissional.ToLower() != "medico")
            {
                Console.WriteLine($"Acesso Negado. Apenas médicos podem consultar o histórico clínico do utente {utente.Nome}.");
                return;
            }

            Console.WriteLine($"\n--- HISTÓRICO CLÍNICO DE {utente.Nome} ({utente.NumeroRegisto}) ---");
            if (utente.HistoricoClinico.Count == 0)
            {
                Console.WriteLine("Nenhum registo clínico encontrado.");
            }
            else
            {
                foreach (var registo in utente.HistoricoClinico)
                {
                    Console.WriteLine($"Data: {registo.DataAtendimento.ToShortDateString()} | Diagnóstico: {registo.Diagnostico} | Obs: {registo.Observacoes}");
                }
            }
            Console.WriteLine("--------------------------------------------------\n");
        }

    }
}
