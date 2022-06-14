using Beryllium_Back.DAL;
using Beryllium_Back.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Beryllium_Back.Areas.Object.Controllers
{
    [Area("Object")]
    public class FirstSliderController : Controller
    {
        private AppDbcontext _context { get;  }
        private IWebHostEnvironment _env { get;  }
        public FirstSliderController(AppDbcontext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.FirstSliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FirstSlider firstSlider,IFormFile file,string savepath)
        {
            if (firstSlider == null) return BadRequest();
            string filename = Guid.NewGuid().ToString() + firstSlider.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath,"img","firstslider", filename);
            using(FileStream stream = new FileStream(path,FileMode.Create))
            {
                firstSlider.Photo.CopyTo(stream);
            }
            firstSlider.Image = filename;
            _context.FirstSliders.Add(firstSlider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            FirstSlider firstSlider = _context.FirstSliders.FirstOrDefault(x => x.Id == id);
            if (firstSlider == null) return NotFound();
            return View(firstSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FirstSlider firstSlider)
        {
            FirstSlider exstfs = _context.FirstSliders.FirstOrDefault(x => x.Id == firstSlider.Id);
            if (exstfs == null) return BadRequest();
            exstfs.Image = firstSlider.Image;
            exstfs.Title = firstSlider.Title;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            FirstSlider firstSlider = _context.FirstSliders.Find(id);
            if (firstSlider == null) return NotFound();
            _context.FirstSliders.Remove(firstSlider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
