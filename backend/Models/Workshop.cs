namespace WorkshopApi.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataRealizacao { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<string> Participantes { get; set; } = new List<string>();
    }
}
