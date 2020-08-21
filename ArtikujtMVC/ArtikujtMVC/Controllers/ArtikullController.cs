using ArtikujtMVC.Database;
using ArtikujtMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArtikujtMVC.Controllers
{
    public class ArtikullController : Controller
    {

        public async Task<ActionResult> Index(int? id)
        {
            Artikull artikull = new Artikull { IsNew = true };
            if (id.HasValue)
            {
                using(var context = new ApplicationDBContext())
                {
                    artikull = await context.Artikujt.FindAsync(id.Value);
                    if(artikull == null)
                        return View("ArtikullNotFound");
                }
            }

            TempData["newArtikullButton"] = "New Artikull";


            return View(artikull);
        }

        [HttpPost]
        public ActionResult Index(Artikull artikull)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", artikull);
            }

            using (var context = new ApplicationDBContext())
            {

                context.Artikujt.AddOrUpdate(artikull);
                var rowsNr = context.SaveChanges();
                if(rowsNr > 0)
                {
                    TempData["success"] = "Artikulli u ruajt me sukses";
                }
                
            }


            return RedirectToAction(nameof(Index), new { Id = artikull.Id });
        }


        public async Task< ActionResult> Kerko(int index = 1)
        {
            index = Math.Max(index, 1);
            int pageSize = 10;

            Artikull[] artikujt = null;

            int numberOfPages = 0;

            using (var context = new ApplicationDBContext())
            {
                artikujt =  await context.Artikujt
                                .OrderByDescending(a => a.Id)
                               .Skip((index - 1) * pageSize).
                               Take(pageSize).ToArrayAsync();

                int totalCount = context.Artikujt.Count();
                numberOfPages = (int)Math.Ceiling(totalCount*1.0 / pageSize);

            }

            return View(new PaginatedList<Artikull>(artikujt, numberOfPages, index));
        }
        [HttpPost]
        public async Task<ActionResult> Fshi(int id)
        {
            using (var context = new ApplicationDBContext())
            {
                var artikull = await context.Artikujt.FindAsync(id);
                if (artikull == null)
                    return View("ArtikullNotFound");
                context.Artikujt.Remove(artikull);
                var rowsNr = await context.SaveChangesAsync();
                if (rowsNr > 0)
                {
                    TempData["success"] = $"Artikulli {artikull.Emri} u fshi me sukses";
                }

            }
            return RedirectToAction(nameof(Kerko));
        }

        public ActionResult ArtikullNotFound()
        {
            return View();
        }

       
    }
}