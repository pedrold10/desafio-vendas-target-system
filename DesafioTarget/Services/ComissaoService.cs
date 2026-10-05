namespace DesafioTarget.Services;

public class ComissaoService {
    public decimal Calcular(decimal valorVenda)
    {
        if (valorVenda < 100)
            return 0;

        if (valorVenda < 500)
            return Math.Round(valorVenda * 0.01m, 2);

        return Math.Round(valorVenda * 0.05m, 2);
    }
}
