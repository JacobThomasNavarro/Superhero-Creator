using Superhero_Creator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero_Creator.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext context;
        public SuperheroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superhero
        public ActionResult Index()
        {
            return View(context.Superheroes.ToList());
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            var detailedSuperhero = context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(detailedSuperhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            var superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Superheroes.Add(superhero);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var updatedSuperhero = context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(updatedSuperhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                    var updatedSuperhero = context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
                    updatedSuperhero.name = superhero.name;
                    updatedSuperhero.alterEgo = superhero.alterEgo;
                    updatedSuperhero.primaryAbility = superhero.primaryAbility;
                    updatedSuperhero.secondaryAbility = superhero.secondaryAbility;
                    updatedSuperhero.catchphrase = superhero.catchphrase;
                    context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(delete);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                if(superhero == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var delete = context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
                    context.Superheroes.Remove(delete); ;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
