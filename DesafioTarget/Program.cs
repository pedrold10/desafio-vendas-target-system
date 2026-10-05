using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

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

foreach (var venda in dados.Vendas)
{
    var comissao = comissaoService.Calcular(venda.Valor);

    Console.WriteLine(
        $"Vendedor: {venda.Vendedor} | " +
        $"Venda: R$ {venda.Valor:F2} | " +
        $"Comissão: R$ {comissao:F2}");
}
