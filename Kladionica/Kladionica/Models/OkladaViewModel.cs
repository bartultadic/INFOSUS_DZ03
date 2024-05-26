using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kladionica.Models
{
    public class OkladaViewModel
    {
        public Oklada oklada {  get; set; }
        public IEnumerable<SelectListItem> Korisnici { get; set; }
        public virtual List<Utakmica> Utakmice { get; set; }
    }
}
