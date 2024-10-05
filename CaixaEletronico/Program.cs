
class CaixaEletronico
{
    private static decimal saldo = 1000;
    private static List<string> extrato = new List<string>();
    static void Main()
    {
        while (true)
        {
            EscreverNomeBanco();
            Console.WriteLine("[1] Saque");
            Console.WriteLine("[2] Depósito");
            Console.WriteLine("[3] Transferência");
            Console.WriteLine("[4] Saldo e Extrato");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("\nBem-vindo(a) ao terminal de autoatendimento Carolbank.");
            string escolhaUsuario;
            while (true)
            {
                Console.Write("Insira o número correspondente à opção desejada: ");
                escolhaUsuario = Console.ReadLine();

                if (escolhaUsuario == "1" || escolhaUsuario == "2" || escolhaUsuario == "3" || escolhaUsuario == "4" || escolhaUsuario == "0")
                    break;
                else
                    ColorirLinha("Opção inválida. Tente novamente.", ConsoleColor.Red);
            }

            switch (escolhaUsuario)
            {
                case "1":
                    FazerSaque();
                    break;
                case "2":
                    FazerDeposito();
                    break;
                case "3":
                    FazerTransferencia();
                    break;
                case "4":
                    GerarExtrato();
                    break;
                case "0":
                    Sair();
                    return;
            }

            while (true)
            {
                Console.Write("\nDeseja fazer outra operação? ([1] Sim / [0] Não): ");
                escolhaUsuario = Console.ReadLine();
                if (escolhaUsuario == "1")
                {
                    break;
                }
                else if (escolhaUsuario == "0")
                {
                    Sair();
                    return;
                }
                else
                {
                    ColorirLinha("Opção inválida. Tente novamente.", ConsoleColor.Red);
                }
            }
        }
    }

    static void FazerSaque()
    {
        EscreverTitulo("Saque");

        Console.Write("Digite o valor: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valorSaque) || valorSaque <= 0)
        {
            ColorirLinha("Valor inválido. Operação cancelada.", ConsoleColor.Red);
            return;
        }
        else if (saldo < valorSaque)
        {
            ColorirLinha("Saldo insuficiente. Operação cancelada.", ConsoleColor.Red);
            return;
        }
        else
        {
            saldo -= valorSaque;
            extrato.Add($"{DateTime.Now}: Saque de {valorSaque:C} — Saldo restante: {saldo:C}");
            Console.WriteLine($"\nVocê sacou {valorSaque:C}.");
            Console.WriteLine($"Saldo atual: {saldo:C}.");
        }
    }
    static void FazerDeposito()
    {
        EscreverTitulo("Depósito");

        Console.Write("Digite o valor: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valorDeposito) || valorDeposito <= 0)
        {
            ColorirLinha("Valor inválido. Operação cancelada.", ConsoleColor.Red);
            return;
        }
        else
        {
            saldo += valorDeposito;
            extrato.Add($"{DateTime.Now}: Depósito de {valorDeposito:C} — Saldo restante: {saldo:C}");
            Console.WriteLine($"\nVocê depositou {valorDeposito:C}.");
            Console.WriteLine($"Saldo atual: {saldo:C}.");
        }
    }
    static void FazerTransferencia()
    {
        EscreverTitulo("Transferência");

        Console.Write("Digite os 8 números da conta do(a) favorecido(a): ");
        if (!int.TryParse(Console.ReadLine(), out int contaFavorecido) || contaFavorecido.ToString().Length != 8)
        {
            ColorirLinha("Número inválido. Operação cancelada.", ConsoleColor.Red);
            return;
        }

        Console.Write("Digite o nome do(a) favorecido(a): ");
        string nomeFavorecido = Console.ReadLine();

        Console.Write("Digite o valor: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valorTransferencia) || valorTransferencia <= 0)
        {
            ColorirLinha("Valor inválido. Operação cancelada.", ConsoleColor.Red);
            return;
        }
        else if (saldo < valorTransferencia)
        {
            ColorirLinha("Saldo insuficiente. Operação cancelada.", ConsoleColor.Red);
            return;
        }
        else
        {
            saldo -= valorTransferencia;
            extrato.Add($"{DateTime.Now}: Transferência de {valorTransferencia:C} para {nomeFavorecido} ({contaFavorecido}) — Saldo restante: {saldo:C}");
            Console.WriteLine($"\nVocê transferiu {valorTransferencia:C} para {nomeFavorecido} ({contaFavorecido}).");
            Console.WriteLine($"Saldo atual: {saldo:C}");
        }
    }
    static void GerarExtrato()
    {
        EscreverTitulo("Saldo e Extrato");

        Console.WriteLine($"Saldo disponível: {saldo:C}\n");

        if (extrato.Count != 0)
        {
            foreach (var transacao in extrato)
                Console.WriteLine(transacao);
        }
        else
        {
            Console.WriteLine("Nenhuma transação realizada.");
        }
    }
    static void Sair()
    {
        EscreverNomeBanco();
        Console.WriteLine("Obrigado por utilizar os serviços Carolbank.");
    }

    static void EscreverNomeBanco()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"  ___              _ _               _   ");
        Console.WriteLine(@" / __|__ _ _ _ ___| | |__  __ _ _ _ | |__");
        Console.WriteLine(@"| (__/ _` | '_/ _ \ | '_ \/ _` | ' \| / /");
        Console.WriteLine(@" \___\__,_|_| \___/_|_.__/\__,_|_||_|_\_\");
        Console.WriteLine();
        Console.ResetColor();
    }

    static void EscreverTitulo(string texto)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('-', texto.Length));
        Console.WriteLine(texto);
        Console.WriteLine(new string('-', texto.Length));
        Console.ResetColor();
    }

    static void ColorirLinha(string texto, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(texto);
        Console.ResetColor();
    }
}