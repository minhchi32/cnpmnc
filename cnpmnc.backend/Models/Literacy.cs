namespace cnpmnc.backend.Models
{
    public class Literacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Account Teacher { get; set; }
    }
}