using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kladionica.Models
{
    public class Utakmica
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public string Tim1 { get; set; }
        public string Tim2 { get; set; }

        //Sport relationship
        public int ID_oklada { get; set; }
        [ForeignKey("ID_oklada")]
        public Oklada Oklada { get; set; }
    }
}
