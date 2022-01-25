
using Agency.Models;
using Agency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Controllers
{
    public class HomeController : Controller
    {
        AgencyContext _context;

        public HomeController(AgencyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Services = _context.Services.Where(x=>!x.IsDeleted).ToList(),
                Portfolios=_context.Portfolios.Where(x=>!x.IsDeleted).ToList()
            };
            return View(homeVM);
        }

        public IActionResult GetPortfolio(int id)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio==null)
            {
                return NotFound();
            }

            return PartialView("_PortfolioPartialModal",portfolio);
        }

        
    }
}
