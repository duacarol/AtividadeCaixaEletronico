decimal saldo = 1000;

inicio:
Console.WriteLine("- Caixa Eletrônico -");
Console.WriteLine("[1] Saque");
Console.WriteLine("[2] Depósito");
Console.WriteLine("[3] Transferência");
Console.WriteLine("[4] Saldo e Extrato");
Console.WriteLine("[0] Sair");
Console.Write("Por favor, insira o número correspondente à opção desejada: ");
string escolhaUsuario = Console.ReadLine();

switch (escolhaUsuario)
{
    case "1":
        Console.WriteLine("- Saque -");
        Console.Write("Digite o valor: ");
        decimal valorSaque = decimal.Parse(Console.ReadLine());
        if (saldo >= valorSaque)
        {
            saldo -= valorSaque;
            Console.WriteLine($"Você sacou {valorSaque:C}.");
            Console.WriteLine($"Saldo atual: {saldo:C}.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");            
        }
        break;
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