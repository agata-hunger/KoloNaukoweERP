namespace BLL.Models
{
    public class SprzetDTO
    {
        public int IdSprzetu { get; set; }
        public int? IdCzlonka { get; set; }
        public int? IdZespolu { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public bool CzyDostepny { get; set; }
    }
}
