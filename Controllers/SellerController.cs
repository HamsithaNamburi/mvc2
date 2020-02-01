using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvcproject.Models;


namespace Mvcproject.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public readonly SellerContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        public SellerController(SellerContext context, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterSeller(SellercreatePath s)
        {
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {


                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (s.Photopath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + s.Photopath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    s.Photopath.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                Seller newseller = new Seller
                {
                    Uname = s.Uname,
                    Email = s.Email,
                    Pwd = s.Pwd,
                    C_name = s.C_name,
                    s_id = s.s_id,
                    C_No = s.C_No,
                    GSTIN = s.GSTIN,
                    Photopath = uniqueFileName
                   
                };
                try
                {
                    _context.Add(newseller);
                    _context.SaveChanges();

                    ViewBag.message = newseller.Uname + "Successfully registerd";

                }
                catch (Exception e)
                {
                    ViewBag.message = newseller.Uname + "Failed to register";
                }
                return RedirectToAction("SellerLogin", new { id = newseller.s_id });
            }
            else
                return View();
       
        
         
        }
        public ActionResult SellerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellerLogin(Seller s)
        {
            var loguser = _context.Sellers.Where(e => e.s_id == s.s_id && e.Pwd == s.Pwd).ToList();
            if (loguser.Count == 0)
            {
                ViewBag.message = "Not a Valid User";
                return View();
            }
            else
            {//to store session values

                HttpContext.Session.SetString("b_id", s.s_id);
                HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());


                return View("DashBoard");
            }

            }
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("Uname") != null)
            {
                ViewBag.uname = HttpContext.Session.GetString("Uname").ToString();
                if (Request.Cookies["lastLogin"] != null)
                    ViewBag.lltd = Request.Cookies["lastLogin"].ToString();
            }
            return View();
        }
        public ActionResult Logout()
        {
            Response.Cookies.Append("lastLogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
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

        // GET: Seller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seller/Edit/5
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

        // GET: Seller/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = _context.Sellers.FirstOrDefault(m => m.s_id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(_context.Sellers.ToListAsync());
            
        }

        // POST: Seller/Delete/5
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