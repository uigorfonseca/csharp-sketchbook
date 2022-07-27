namespace resolucoes.test;

public class OrdemCrescenteTest
{
    [Fact]
    public void OrdemCrescenteDeveRetornarUmInteiroNaoNegativo()
    {
        var resultado = OrdemCrescente.Ordenar(0);
        Assert.True(resultado >= 0);
    }

    [Fact]
    public void OrdenarDadoONumero451DeveRetornar541()
    {
        var esperado = 541;
        var resulto = OrdemCrescente.Ordenar(541);
        Assert.Equal(esperado, resulto);
    }
}