namespace WebAPI.Models
{
    public class PelnionaFunkcjaDTO
    {
        public int IdPelnionejFunkcji { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<CzlonekDTO> CzlonkowieDTOs { get; set; }
    }
}
