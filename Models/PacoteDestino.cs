namespace GerenciamentoTurismo.Models
{
    public class PacoteDestino
    {
        // Chaves primárias compostas e chaves estrangeiras.
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; }
        public int CidadeDestinoId { get; set; }
        public CidadeDestino CidadeDestino { get; set; }
    }
}
