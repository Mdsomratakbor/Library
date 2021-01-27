using Library.Data.Models;
using Library.Services.Interfaces;
using Library.Web.ViewModels.PatronViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Web.Controllers
{
    public class PatronController : Controller
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

        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);
            var model = new PatronDetailViewModel
            {
                LastName = patron.LastName,
                FirstName = patron.FirstName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                MemberSince = patron.LibraryCard.Created,
                OverdueFees = patron.LibraryCard.Fees,
                LibraryCardId = patron.LibraryCard.Id,
                Telephone = patron.Telephone,
                AssetsCheckOut = _patron.GetCheckouts(id).ToList() ?? new List<Checkout>(),
                CheckoutHistories = _patron.GetCheckoutHistories(id),
                Holds = _patron.GetHolds(id)
            };
            return View(model);
        }
    }
}
