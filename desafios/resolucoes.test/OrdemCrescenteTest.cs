namespace resolucoes.test;

public class OrdemCrescenteTest
{
    [Fact]
    public void OrdemCrescenteDeveRetornarUmInteiroNaoNegativo()
    {
        var resultado = OrdemCrescente.Ordenar(0);
        Assert.True(resultado >= 0);
    }
}