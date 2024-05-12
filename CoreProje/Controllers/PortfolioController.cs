using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PortfolioController : Controller
    {
        private PortfolioManager manager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            var values = manager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validator = new PortfolioValidator();
            ValidationResult results = validator.Validate(portfolio);
            if (results.IsValid)
            {
                manager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = manager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator portfolioValidator = new PortfolioValidator();
            ValidationResult results = portfolioValidator.Validate(portfolio);
            if (results.IsValid)
            {
                manager.TUpdate(portfolio);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = manager.TGetById(id);
            manager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
