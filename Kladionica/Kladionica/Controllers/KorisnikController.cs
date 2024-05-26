using Kladionica.Data;
using Kladionica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kladionica.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly DataContext _dataContext;
        public KorisnikController(DataContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var korisnici = from k in _dataContext.Korisniks
                            select k;

            if (!string.IsNullOrEmpty(searchString))
            {
                korisnici = korisnici.Where(k => k.Ime.Contains(searchString) || k.Prezime.Contains(searchString));
            }

            return View(korisnici.ToList());
        }
        /*{
            List<Korisnik> korinsici = _dataContext.Korisniks.ToList();
            return View(korinsici);
        }*/

        public IActionResult Create()
        {
            Korisnik korisnik = new Korisnik();
            return View(korisnik);
        }

        [HttpPost]
        public IActionResult Create(Korisnik korisnik)
        {
            _dataContext.Korisniks.Add(korisnik);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = _dataContext.Korisniks
                .FirstOrDefault(m => m.ID == id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = _dataContext.Korisniks
                .FirstOrDefault(m => m.ID == id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        [HttpPost]
        public IActionResult Edit(Korisnik korisnik)
        {

            _dataContext.Update(korisnik);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = _dataContext.Korisniks
                .FirstOrDefault(m => m.ID == id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        [HttpPost]
        public IActionResult Delete(Korisnik korisnik)
        {
            _dataContext.Attach(korisnik);
            _dataContext.Entry(korisnik).State = EntityState.Deleted;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
