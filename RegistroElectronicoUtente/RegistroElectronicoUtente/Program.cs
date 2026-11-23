using RegistroElectronicoUtente.Modelo;

class Program
{
    static void Main(string[] args)
    {
        SistemaRegisto sistema = new SistemaRegisto();
        bool executar = true;

        while (executar)
        {
            Console.WriteLine("=== SISTEMA DE REGISTO ELETRÓNICO DE UTENTES ===");
            Console.WriteLine("1. Registar Novo Utente");
            Console.WriteLine("2. Adicionar Consulta (Médico)");
            Console.WriteLine("3. Consultar Histórico (Médico)");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome do Utente: ");
                    string nome = Console.ReadLine();
                    Console.Write("NIF (deixe em branco se não tiver): ");
                    string nif = Console.ReadLine();
                    Console.Write("Data de Nascimento (dd/mm/aaaa): ");
                    DateTime dataNasc = DateTime.Parse(Console.ReadLine());

                    Utente novo = sistema.RegistarNovoUtente(nome, nif, dataNasc);
                    Console.WriteLine($"Utente registado com sucesso! Número de Registo: {novo.NumeroRegisto}\n");
                    break;

                case "2":
                    Console.Write("Número de Registo do Utente: ");
                    string numRegisto = Console.ReadLine();
                    Console.Write("Data da Consulta (dd/mm/aaaa): ");
                    DateTime dataCons = DateTime.Parse(Console.ReadLine());
                    Console.Write("Diagnóstico: ");
                    string diag = Console.ReadLine();
                    Console.Write("Observações: ");
                    string obs = Console.ReadLine();

                    sistema.AdicionarConsulta(numRegisto, dataCons, diag, obs);
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Write("Número de Registo do Utente: ");
                    string numRegistoCons = Console.ReadLine();
                    Console.Write("Qual é a sua função? (medico/rececionista): ");
                    string funcao = Console.ReadLine();

                    sistema.ConsultarHistorico(numRegistoCons, funcao);
                    break;

                case "0":
                    executar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }
    }
}

