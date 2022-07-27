namespace resolucoes;

public class OrdemCrescente
{
    public static int Ordenar(int numero)
    {
        var listaDeDigitosOrdenada  = numero.ToString().Select(digito => digito.ToString()).OrderByDescending(digito => digito);
        var resultado = String.Join("", listaDeDigitosOrdenada);
        return int.Parse(resultado);
    }
}