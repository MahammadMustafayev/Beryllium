using Beryllium_Back.DAL;
using Beryllium_Back.Models;
using Beryllium_Back.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Beryllium_Back.Controllers
{
    public class HomeController : Controller
    {
        private AppDbcontext _context { get;  }
        public HomeController(AppDbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                FirstSliders= _context.FirstSliders.ToList()
            };
            return View(homeVM);
        }

        
    }
}
