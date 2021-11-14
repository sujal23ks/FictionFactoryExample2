using FictionFactoryExample2.Interface;
using FictionFactoryExample2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictionFactoryExample2.Controllers
{
    public class DrawingsController : Controller
    {
        private readonly IDrawingstore _context;

        public DrawingsController(IDrawingstore context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAllDrawings());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(DrawingsEntity drawingsdata)
        {
            _context.Create(drawingsdata);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _context.GetDrawingDevDetails(Name);
            return View(md);
        }
        [HttpPost]
        public IActionResult EditPost(string _id,DrawingsEntity drawingsdata)
        {
            _context.Update(_id,drawingsdata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string Name)
        {
            var md = _context.GetDrawingDevDetails(Name);
            return View(md);
        }
        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _context.GetDrawingDevDetails(Name);
            return View(md);
        }
        [HttpPost]
        public IActionResult DeletePost(string Name)
        {
            _context.Delete(Name);
            return RedirectToAction("Index");
        }
    }
}
