using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kladionica.Models
{
    public class Oklada
    {
        public int ID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Ulog must be greater than 0.")]
        public int Ulog { get; set; }
        public string TipOklade { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public ICollection<Utakmica> Utakmice { get; set; }

        //Korisnik relationship
        public int ID_korisnik { get; set; }
        [ForeignKey("ID_korisnik")]
        public Korisnik Korisnik { get; set; }
    }
}
