namespace WorkshopApi.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> WorkshopsParticipados { get; set; } = new List<string>();
    }
}
