namespace DesafioTarget.Models;

public class MovimentacaoEstoque {
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
}