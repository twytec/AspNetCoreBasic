using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreBasic.Models;

namespace AspNetCoreBasic.Controllers
{
    public class HomeController : Controller
    {
        static List<Person> _personList;

        public HomeController()
        {
            if (_personList == null)
            {
                _personList = new List<Person>() {
                    new Person(){ Id = 0, Name = "Person 0", Adress = "Adress 0", Birthday = new DateTime(2000, 03, 21)}
                };
            }
        }

        public IActionResult Index()
        {
            return View(_personList);
        }

        #region Create

        public IActionResult Create()
        {
            Person model = new Person()
            {
                Birthday = DateTime.Now,
                Name = "Default from Controller"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Person model)
        {
            var last = _personList.LastOrDefault();
            model.Id = last.Id + 1;
            _personList.Add(model);
            return RedirectToAction("Index");
        }

        #endregion

        #region Details

        public IActionResult Details(int id)
        {
            var model = _personList.FirstOrDefault(i => i.Id == id);
            return View(model);
        }

        #endregion

        #region Edit
        
        public IActionResult Edit(int id)
        {
            var model = _personList.FirstOrDefault(i => i.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Person model)
        {
            var edit = _personList.FirstOrDefault(i => i.Id == model.Id);
            edit.Adress = model.Adress;
            edit.Birthday = model.Birthday;
            edit.Name = model.Name;

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            var model = _personList.FirstOrDefault(i => i.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Person model)
        {
            var del = _personList.FirstOrDefault(i => i.Id == model.Id);
            _personList.Remove(del);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
