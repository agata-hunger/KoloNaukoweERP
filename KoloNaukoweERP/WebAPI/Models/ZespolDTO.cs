namespace WebAPI.Models
{
    public class ZespolDTO
    {
        public int IdZespolu { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<CzlonekDTO> CzlonkowieDTOs { get; set; }
        public virtual ICollection<SprzetDTO>? SprzetDTOs { get; set; }
        public virtual ICollection<ProjektDTO> ProjektyDTOs { get; set; }
        public virtual ICollection<WydarzenieDTO> WydarzeniaDTOs { get; set; }

    }
}
