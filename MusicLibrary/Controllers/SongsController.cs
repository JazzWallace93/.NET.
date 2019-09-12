using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MusicLibrary.Controllers
{
    public class SongsController : Controller
    {
        const string user = "_user";

        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sString, Login objUser)
        {
            if (objUser != null)
            {
                var songs = from m in _context.Songs
                            select m;

                if (!String.IsNullOrEmpty(sString))
                {
                    songs = songs.Where(s => s.Genre.Contains(sString));
                }
                ViewBag.Name = HttpContext.Session.GetString(user);

                return View(await songs.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .SingleOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

  
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("SongID,Title,Artist,Album,Genre")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.SingleOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SongID,Title,Artist,Album,Genre")] Song song)
        {
            if (id != song.SongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .SingleOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.SingleOrDefaultAsync(m => m.SongID == id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongID == id);
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.Login.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password) != a.Username.Equals("admin")).FirstOrDefault() ;
                var objAdmin = _context.Login.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password) && a.Username.Equals("admin")).FirstOrDefault() ;
                if (obj != null)
                {
                    HttpContext.Session.SetString(user, objUser.Username);
                    
                    return RedirectToAction("List");
                }
                else if (objAdmin != null)
                {
                    HttpContext.Session.SetString(user, objUser.Username);

                    return RedirectToAction("Index");
                }
            }
            return View(objUser);
        }

        public async Task<IActionResult> List(string sString, Login objUser)
        {
            if (objUser != null)
            {
                var songs = from m in _context.Songs
                            select m;

                if (!String.IsNullOrEmpty(sString))
                {
                    songs = songs.Where(s => s.Genre.Contains(sString));
                }
                ViewBag.Name = HttpContext.Session.GetString(user);

                return View(await songs.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([Bind("id,Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(login);
        }



        public IActionResult Logout(Login objUser)
        {
            if (ModelState.IsValid)
            {               
                    HttpContext.Session.Remove("_user");

                    return View();
            }          
            return View(objUser);
        }
    }
}
