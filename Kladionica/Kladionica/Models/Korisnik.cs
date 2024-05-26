using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Korisnik
    {
        public int ID { get; set; }
        [StringLength(15, ErrorMessage = "Ime cannot be longer than 15 characters.")]
        public string Ime { get; set; }
        [StringLength(15, ErrorMessage = "Prezime cannot be longer than 15 characters.")]
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum_rođenja { get; set; }
        //public virtual List<Oklada> Oklade { get; set; } = new List<Oklada>();
        public ICollection<Oklada> Oklade { get; set; }
    }
}
