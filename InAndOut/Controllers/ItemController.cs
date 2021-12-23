using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ItemController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _context.Items;
            return View(objList);
        }

        //GET- Create
        public IActionResult Create()
        {
            return View();
        }

        //Post- Create
        public IActionResult Create(Item obj)
        {
            return View();
        }
    }
}
