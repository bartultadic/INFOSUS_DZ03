using Kladionica.Data;
using Kladionica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kladionica.Controllers
{
    public class OkladaController : Controller
    {
        private readonly DataContext _dataContext;

        public OkladaController(DataContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var oklade = from o in _dataContext.Okladas.Include(o => o.Korisnik)
                         select o;

            if (!string.IsNullOrEmpty(searchString))
            {
                oklade = oklade.Where(o => o.TipOklade.Contains(searchString) || o.Korisnik.Ime.Contains(searchString));
            }

            return View(oklade.ToList());

            /*var oklade = _dataContext.Okladas
                .Include(o => o.Korisnik)
                .ToList();
            return View(oklade);*/
        }

        public IActionResult Create()
        {
            var korisnici = _dataContext.Korisniks.Select(u => new SelectListItem
            {
                Value = u.ID.ToString(),
                Text = $"{u.Ime} {u.Prezime}"
            }).ToList();

            var viewModel = new OkladaViewModel
            {
                oklada = new Oklada(),
                Utakmice = new List<Utakmica>(),
                Korisnici = korisnici,
            };
            //viewModel.Utakmice.Add(new Utakmica() { ID = 1 });
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OkladaViewModel viewModel) 
        {

            _dataContext.Okladas.Add(viewModel.oklada);
            _dataContext.SaveChanges();

            foreach(var utakmica in viewModel.Utakmice)
            {
                utakmica.ID_oklada = viewModel.oklada.ID;
                _dataContext.Utakmicas.Add(utakmica);
            }
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oklada = _dataContext.Okladas
                .Include(o => o.Korisnik)
                .Include(o => o.Utakmice)
                .FirstOrDefault(m => m.ID == id);

            if (oklada == null)
            {
                return NotFound();
            }

            var viewModel = new OkladaViewModel
            {
                oklada = oklada,
                Utakmice = oklada.Utakmice.ToList(),
                Korisnici = _dataContext.Korisniks.Select(u => new SelectListItem
                {
                    Value = u.ID.ToString(),
                    Text = $"{u.Ime} {u.Prezime}"
                }).ToList()
            };

            return View(viewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oklada = _dataContext.Okladas
                .Include(o => o.Korisnik)
                .Include(o => o.Utakmice)
                .FirstOrDefault(m => m.ID == id);

            if (oklada == null)
            {
                return NotFound();
            }

            var viewModel = new OkladaViewModel
            {
                oklada = oklada,
                Utakmice = oklada.Utakmice.ToList(),
                Korisnici = _dataContext.Korisniks.Select(u => new SelectListItem
                {
                    Value = u.ID.ToString(),
                    Text = $"{u.Ime} {u.Prezime}"
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(OkladaViewModel viewModel)
        {

            List<Utakmica> tekme = _dataContext.Utakmicas.Where(t => t.ID_oklada == viewModel.oklada.ID).ToList();
            _dataContext.Utakmicas.RemoveRange(tekme);
            _dataContext.SaveChanges();

            _dataContext.Update(viewModel.oklada);
            _dataContext.SaveChanges();

            foreach (var utakmica in viewModel.Utakmice)
            {
                utakmica.ID_oklada = viewModel.oklada.ID;
                _dataContext.Utakmicas.Add(utakmica);
            }
            _dataContext.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oklada = _dataContext.Okladas
                .Include(o => o.Korisnik)
                .Include(o => o.Utakmice)
                .FirstOrDefault(m => m.ID == id);

            if (oklada == null)
            {
                return NotFound();
            }

            var viewModel = new OkladaViewModel
            {
                oklada = oklada,
                Utakmice = oklada.Utakmice.ToList(),
                Korisnici = _dataContext.Korisniks.Select(u => new SelectListItem
                {
                    Value = u.ID.ToString(),
                    Text = $"{u.Ime} {u.Prezime}"
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(OkladaViewModel viewModel)
        {
            _dataContext.Attach(viewModel.oklada);
            _dataContext.Entry(viewModel.oklada).State = EntityState.Deleted;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
