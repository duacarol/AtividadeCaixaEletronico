List<string> extrato = new List<string>();
int saldo = 1000;

inicio:
Console.WriteLine("CAIXA ELETRÔNICO");
Console.WriteLine("[1] Saque");
Console.WriteLine("[2] Depósito");
Console.WriteLine("[3] Transferência");
Console.WriteLine("[4] Saldo e Extrato");
Console.WriteLine("[0] Sair");
escolha:
Console.Write("Por favor, insira o número correspondente à opção desejada: ");
string escolhaUsuario = Console.ReadLine();

switch (escolhaUsuario)
{
    case "1":
        Console.WriteLine("SAQUE");
        Console.Write("Digite o valor: ");
        int valorSaque = int.Parse(Console.ReadLine());
        if (saldo < valorSaque)
        {
            Console.WriteLine("Saldo insuficiente!");
        }
        else if (valorSaque < 0)
        {
            Console.WriteLine("O valor não pode ser menor do que 0.");
        }
        else
        {
            saldo -= valorSaque;
            extrato.Add($"Saque de {valorSaque:C} — Saldo restante: {saldo:C}");
            Console.WriteLine($"Você sacou {valorSaque:C}.");
            Console.WriteLine($"Saldo atual: {saldo:C}.");
        }
        break;

    case "2":
        Console.WriteLine("DEPÓSITO");
        Console.Write("Digite o valor: ");
        int valorDeposito = int.Parse(Console.ReadLine());
        if (valorDeposito < 0)
        {
            Console.WriteLine("O valor não pode ser menor do que 0.");
        }
        else
        {
            saldo += valorDeposito;
            extrato.Add($"Depósito de {valorDeposito:C} — Saldo restante: {saldo:C}");
            Console.WriteLine($"Você depositou {valorDeposito:C}.");
            Console.WriteLine($"Saldo atual: {saldo:C}.");
        }
        break;

    case "3":
        Console.WriteLine("TRANSFERÊNCIA");
        Console.Write("Digite o número da conta do(a) favorecido(a): ");
        int contaFavorecido = int.Parse(Console.ReadLine()); // 8 dígitos

        Console.Write("Digite o nome do(a) favorecido(a): ");
        string nomeFavorecido = Console.ReadLine();

        Console.Write("Digite o valor: ");
        int valorTransferencia = int.Parse(Console.ReadLine());

        if (valorTransferencia < 0)
        {
            Console.WriteLine("O valor não pode ser menor do que 0.");
        }
        else
        {
            saldo -= valorTransferencia;
            extrato.Add($"Transferência de {valorTransferencia:C} para {nomeFavorecido} ({contaFavorecido}) — Saldo restante: {saldo:C}");
            Console.WriteLine($"Você transferiu {valorTransferencia:C} para {nomeFavorecido} ({contaFavorecido}).");
            Console.WriteLine($"Saldo atual: {saldo:C}");
        }
        break;

    case "4":
        Console.WriteLine("SALDO E EXTRATO");
        Console.WriteLine($"Saldo disponível: {saldo:C}");

        if (extrato.Count != 0)
        {
            foreach (var transacao in extrato)
            {
                Console.WriteLine(transacao);
            }
        }
        else
        {
            Console.WriteLine("Nenhuma transação realizada.");
        }
        break;

    default:
        Console.WriteLine("Opção inválida. Tente novamente.");
        goto escolha;
}

Console.Write("Deseja fazer outra operação? (S/N): ");
escolhaUsuario = Console.ReadLine().ToUpper();
if (escolhaUsuario == "S")
{
    goto inicio;
}
else if (escolhaUsuario == "N")
{
    Console.WriteLine("Obrigado por utilizar nossos serviços.");
    return;
}