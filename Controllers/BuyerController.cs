using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvcproject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mvcproject.Controllers
{
    public class BuyerController : Controller
    {
        public readonly BuyerContext _context;
        public readonly CategoryContext _context1;
        public BuyerController(BuyerContext context,CategoryContext context1)
        {
            this._context = context;
            this._context1 = context1;
        }
        
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(Buyer b)
        {
            try
            {
                _context.Add(b);
                _context.SaveChanges();
                ViewBag.message = b.Name + "Successfully registerd";

            }
            catch(Exception e)
            {
                ViewBag.message = b.Name + "Faied to register";
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Buyer b)
        {

            var loguser = _context.Buyers.Where(e => e.b_id == b.b_id && e.Password == b.Password).ToList();
            if (loguser.Count == 0)
            {
                ViewBag.message = "Not a Valid User";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("b_id", b.b_id);
                HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());
                
            }
            return RedirectToAction("DashBoardBuyer");
        }
        
        public IActionResult DashBoardBuyer()
        {
            if (HttpContext.Session.GetString("b_id") != null)
            {
                ViewBag.uname = HttpContext.Session.GetString("b_id").ToString();
                if (Request.Cookies["lastLogin"] != null)
                    ViewBag.lltd = Request.Cookies["lastLogin"].ToString();


            }
            return RedirectToAction("Details");
        }
                     
                public ActionResult Logout()
        {
            Response.Cookies.Append("lastLogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return View();
        }

        //public IActionResult DashBoard()
        //{

        //    return View();
        //}
        //public IActionResult 
        //// GET: Buyer
        public IActionResult Index()
        {
            return View();
        }

        // GET: Buyer/Details/5
        public  IActionResult Details(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var customers =  _context.Buyers.FirstOrDefault(m =>m.b_id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(_context.Buyers.ToListAsync());
            
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buyer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buyer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buyer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}