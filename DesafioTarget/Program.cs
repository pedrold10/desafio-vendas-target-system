using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

while (true) {
    Console.Clear();

    Console.WriteLine("================================");
    Console.WriteLine("         DESAFIO TARGET");
    Console.WriteLine("================================");
    Console.WriteLine();
    Console.WriteLine("1 - Calcular comissões");
    Console.WriteLine("2 - Movimentar estoque");
    Console.WriteLine("3 - Calcular juros");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    Console.Clear();

    switch (opcao)
    {
        case "1":
            CalcularComissoes();
            break;

        case "2":
            MovimentarEstoque();
            break;

        case "3":
            CalcularJuros();
            break;

        case "0":
            Console.WriteLine("Programa encerrado.");
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

void CalcularComissoes() {
    var json = File.ReadAllText("Data/vendas.json");

    var dados = JsonSerializer.Deserialize<VendasData>(
        json,
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

    if (dados is null)
    {
        Console.WriteLine("Não foi possível ler o arquivo de vendas.");
        return;
    }

    var comissaoService = new ComissaoService();

    Console.WriteLine("=== COMISSÕES ===");
    Console.WriteLine();

    foreach (var venda in dados.Vendas)
    {
        var comissao = comissaoService.Calcular(venda.Valor);

        Console.WriteLine(
            $"Vendedor: {venda.Vendedor} | " +
            $"Venda: R$ {venda.Valor:F2} | " +
            $"Comissão: R$ {comissao:F2}");
    }
}

void MovimentarEstoque()
{
    var json = File.ReadAllText("Data/estoque.json");

    var dados = JsonSerializer.Deserialize<EstoqueData>(
        json,
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

    if (dados is null || dados.Estoque.Count == 0)
    {
        Console.WriteLine("Não foi possível ler o arquivo de estoque.");
        return;
    }

    while (true)
    {
        Console.Clear();

        Console.WriteLine("=== MOVIMENTAÇÃO DE ESTOQUE ===");
        Console.WriteLine();

        Console.Write("Código do produto: ");

        if (!int.TryParse(Console.ReadLine(), out var codigoProduto))
        {
            Console.WriteLine("Código do produto inválido.");
            continue;
        }

        var produto = dados.Estoque.FirstOrDefault(
            produto => produto.CodigoProduto == codigoProduto);

        if (produto is null)
        {
            Console.WriteLine("Produto não encontrado.");
            continue;
        }

        Console.Write("Tipo de movimentação (ENTRADA/SAÍDA): ");
        var tipoMovimentacao = Console.ReadLine() ?? string.Empty;

        if (!tipoMovimentacao.Equals("ENTRADA", StringComparison.OrdinalIgnoreCase) &&
            !tipoMovimentacao.Equals("SAÍDA", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Tipo de movimentação inválido. Use ENTRADA ou SAÍDA.");
            continue;
        }

        Console.Write("Quantidade: ");

        if (!int.TryParse(Console.ReadLine(), out var quantidade))
        {
            Console.WriteLine("Quantidade inválida.");
            continue;
        }

        var movimentacao = new MovimentacaoEstoque
        {
            Id = Guid.NewGuid(),
            Descricao = tipoMovimentacao,
            CodigoProduto = produto.CodigoProduto,
            Quantidade = quantidade
        };

        var estoqueAnterior = produto.Estoque;

        try
        {
            var estoqueFinal = new EstoqueService().Movimentar(
                produto,
                movimentacao);

            Console.WriteLine();
            Console.WriteLine("Movimentação registrada com sucesso!");
            Console.WriteLine($"Produto: {produto.DescricaoProduto}");
            Console.WriteLine($"Estoque anterior: {estoqueAnterior}");
            Console.WriteLine($"Quantidade movimentada: {quantidade}");
            Console.WriteLine($"Estoque atual: {estoqueFinal}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine();
        Console.Write("Deseja realizar outra movimentação? (S/N): ");

        var continuar = Console.ReadLine();

        if (!continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }
    }
}


void CalcularJuros() {
    // Vamos implementar essa parte depois.
}