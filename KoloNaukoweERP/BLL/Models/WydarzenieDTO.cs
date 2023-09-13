namespace BLL.Models
{
    public class WydarzenieDTO
    {
        public int IdWydarzenia { get; set; }
        public int IdZespolu { get; set; }
        public string Nazwa { get; set; }
        public DateTime Data { get; set; }
        public string Miejsce { get; set; }
    }
}
