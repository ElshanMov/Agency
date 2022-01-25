using Agency.Helper;
using Agency.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PortfolioController : Controller
    {
        AgencyContext _context;
        IWebHostEnvironment _env;
        public PortfolioController(AgencyContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Portfolios.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Portfolio portfolio)
        {
            if (portfolio.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Shekil bosh buraxila bilmez!");
            }
            else if (portfolio.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Daxil edilen File 2-mb dan cox ola bilmez!");
            }

            else if (portfolio.ImageFile.ContentType != "image/jpeg" && portfolio.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Daxil edilen File formati duzgun deyil");
            }

            if (!ModelState.IsValid) return View();

            portfolio.Image = FileManager.Save(_env.WebRootPath, "uploads/portfolios", portfolio.ImageFile);

            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(portfolio.Image))
            {
                FileManager.Delete(_env.WebRootPath, "uploads/portfolios", portfolio.Image);
            }

            portfolio.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Edit(int id)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Portfolio portfolio)
        {
            if (portfolio.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Shekil bosh buraxila bilmez!");
            }
            else if (portfolio.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Daxil edilen File 2-mb dan cox ola bilmez!");
            }

            else if (portfolio.ImageFile.ContentType != "image/jpeg" && portfolio.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Daxil edilen File formati duzgun deyil");
            }

            if (!ModelState.IsValid) return View();

            Portfolio existPortfolio = _context.Portfolios.FirstOrDefault(x => x.Id == portfolio.Id);
            if (existPortfolio == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(portfolio.ImageFile.FileName))
            {
                FileManager.Delete(_env.WebRootPath, "uploads/portfolios", existPortfolio.Image);
                existPortfolio.Image = FileManager.Save(_env.WebRootPath, "uploads/portfolios", portfolio.ImageFile);
            }

            existPortfolio.Title = portfolio.Title;
            existPortfolio.SubTitle = portfolio.SubTitle;
            existPortfolio.Category = portfolio.Category;
            existPortfolio.BtnText = portfolio.BtnText;
            existPortfolio.Client = portfolio.Client;
            existPortfolio.ImageDesc = portfolio.ImageDesc;
            existPortfolio.ImageTitle = portfolio.ImageTitle;
            existPortfolio.PorfolioName = portfolio.PorfolioName;
            existPortfolio.PortfolioDesc = portfolio.PortfolioDesc;
            existPortfolio.PortfolioSubTitle = portfolio.PortfolioSubTitle;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
