using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Czlonek
    {
        [Key]
        public int IdCzlonka { get; set; }

        public int IdPelnionejFunkcji { get; set; }
        [ForeignKey(nameof(IdPelnionejFunkcji))]
        public PelnionaFunkcja PelnionaFunkcja { get; set; }

        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Numer telefonu musi składać się z 9 cyfr")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        public string NrTelefonu { get; set; }

        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string Mail { get; set; }

        [MinLength(1, ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Naziwsko jest za długie")]
        [RegularExpression("[A-Z][a-z]+$", ErrorMessage = "Nieprawidłowe nazwisko")]
        public string Nazwisko { get; set; }

        [MinLength(1, ErrorMessage = "Imie jest wymagane")]
        [MaxLength(50, ErrorMessage = "Imie jest za długie")]
        [RegularExpression("[A-Z][a-z]+$", ErrorMessage = "Nieprawidłowe imię")]
        public string Imie { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa kierunku studiów jest wymagany")]
        [MaxLength(50, ErrorMessage = "Nazwa kierunku studiów jest za długi")]
        public string KierunekStudiow { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa wydziału jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa wydziału jest za długa")]
        public string Wydzial { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa uczelni jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa uczelni jest za długa")]
        public string Uczelnia { get; set; }

        public ICollection<Zespol> Zespoly { get; set; }
        public ICollection<Sprzet> Sprzety { get; set; }
    }
}