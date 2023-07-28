namespace MoviemntacaoContaApi.Repositorio
{
    public class MovimentacaoConta
    {
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public double Valor { get; set; }
        public char TipoMovimento { get; set; }
    }
}