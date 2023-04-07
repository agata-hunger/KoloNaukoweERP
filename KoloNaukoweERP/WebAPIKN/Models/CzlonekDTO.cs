namespace WebAPIKN.Models
{
    public class CzlonekDTO
    {
        public int IdCzlonka { get; set; }
        public int IdPelnionejFunkcji { get; set; }
        public string NrTelefonu { get; set; }
        public string Mail { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string KierunekStudiow { get; set; }
        public string Wydzial { get; set; }
        public string Uczelnia { get; set; }
        public virtual ICollection<ZespolDTO> ZespolyDTOs { get; set; }
        public virtual ICollection<SprzetDTO>? SprzetyDTOs { get; set; }
    }
}
