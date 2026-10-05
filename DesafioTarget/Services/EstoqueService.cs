using DesafioTarget.Models;

namespace DesafioTarget.Services;

public class EstoqueService {
    public int Movimentar(
        ProdutoEstoque produto,
        MovimentacaoEstoque movimentacao)
    {
        if (movimentacao.Quantidade <= 0)
        {
            throw new ArgumentException(
                "A quantidade deve ser maior que zero.");
        }

        if (movimentacao.Descricao.Equals(
                "ENTRADA",
                StringComparison.OrdinalIgnoreCase))
        {
            produto.Estoque += movimentacao.Quantidade;
        }
        else if (movimentacao.Descricao.Equals(
                     "SAÍDA",
                     StringComparison.OrdinalIgnoreCase))
        {
            if (movimentacao.Quantidade > produto.Estoque)
            {
                throw new InvalidOperationException(
                    "Estoque insuficiente.");
            }

            produto.Estoque -= movimentacao.Quantidade;
        }
        else
        {
            throw new ArgumentException(
                "Tipo de movimentação inválido. Use ENTRADA ou SAÍDA.");
        }

        return produto.Estoque;
    }
}