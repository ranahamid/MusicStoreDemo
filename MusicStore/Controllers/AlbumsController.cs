using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AlbumsController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

     
           //not httpPost or httpGet
        public ActionResult Search(string q)
        {
            var albums = db.albums.Include(a => a.artist).Include(a => a.genre).Where(a => a.Title.Contains(q)).Take(10);
            return View(albums);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Albums
        public async Task<ActionResult> Index()
        {
            var albums = db.albums.Include(a => a.artist).Include(a => a.genre);
            ViewBag.Album = new Album { Price = 11 };

            //var a= new Album { Price = 11 };
            //return View(a);


            return View(await albums.ToListAsync());

        }

        // GET: Albums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.artists, "ID", "Name");
            ViewBag.GenreID = new SelectList(db.genres, "ID", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AlbumId,GenreID,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.albums.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.artists, "ID", "Name", album.ArtistId);
            ViewBag.GenreID = new SelectList(db.genres, "ID", "Name", album.GenreID);
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.albums.FindAsync(id);
            //var b = db.albums.Single(a => a.AlbumId == id);

            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.artists, "ID", "Name", album.ArtistId);
            ViewBag.GenreID = new SelectList(db.genres, "ID", "Name", album.GenreID);
            ViewBag.genreId = new SelectList(db.genres,"ID","Name",album.GenreID);

            ModelState.AddModelError("Title","What a terrible name!!");

            ViewBag.Album = new Album {Price = 125}; //passing value
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AlbumId,GenreID,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
              
                db.Entry(album).State = EntityState.Modified;
             
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.artists, "ID", "Name", album.ArtistId);

            ViewBag.GenreID = new SelectList(db.genres, "ID", "Name",album.GenreID);
            return View(album);
        }



        // GET: Albums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = await db.albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Album album = await db.albums.FindAsync(id);
            db.albums.Remove(album);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
