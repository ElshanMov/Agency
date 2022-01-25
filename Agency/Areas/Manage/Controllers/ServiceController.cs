using Agency.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        AgencyContext _context;

        public ServiceController(AgencyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Service existService = _context.Services.FirstOrDefault(x => x.Id == service.Id);
            if (existService==null)
            {
                return NotFound();
            }

            existService.Icon = service.Icon;
            existService.ServiceDesc = service.ServiceDesc;
            existService.ServiceName = service.ServiceName;
            existService.Title = service.Title;
            existService.SubTitle = service.SubTitle;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service==null)
            {
                return NotFound();
            }

            service.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
