namespace DesafioTarget.Services;

public class JurosService
{
    private const decimal TaxaDiaria = 0.025m;

    public decimal Calcular(decimal valor, DateTime vencimento)
    {
        var hoje = DateTime.Today;

        if (vencimento >= hoje)
        {
            return 0;
        }

        var diasAtraso = (hoje - vencimento).Days;

        return Math.Round(
            valor * TaxaDiaria * diasAtraso,
            2);
    }
}