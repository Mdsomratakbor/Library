using Library.Data.Models;
using Library.Services.Interfaces;
using Library.Web.ViewModels.PatronViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Web.Controllers
{
    public class PatronController :Controller
    {
        private readonly IPatronServices _patron = null;
        public PatronController(IPatronServices patron)
        {
            _patron = patron;
        }
        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();
            var patronModels = allPatrons.Select(x => new PatronDetailViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LibraryCardId = x.LibraryCard.Id,
                OverdueFees = x.LibraryCard.Fees,
                HomeLibraryBranch = x.HomeLibraryBranch.Name

            }).ToList();

            var model = new PatronIndexViewModel()
            {
                patronDetails = patronModels
        };
            return View(model);
        }
    }
}
