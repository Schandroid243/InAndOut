using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ExpensesController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Expenses> objList = _context.Expenses;

            foreach (var obj in objList.ToList())
            {
                if(obj != null)
                {
                    obj.ExpenseType = _context.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
                }
            }
            return View(objList);

        }

        //GET Create
        public IActionResult Create()
        {

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expenses(),
                TypeDropDown = _context.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(obj.Expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET Update
        public IActionResult Update(int? id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expenses(),
                TypeDropDown = _context.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            expenseVM.Expense = _context.Expenses.Find(id);
            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            
            return View(expenseVM);
        }
        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(obj.Expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Expenses.Find(id);
            if(obj == null || id == 0)
            {
                return NotFound();
            }
             _context.Expenses.Remove(obj);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
    }
}
