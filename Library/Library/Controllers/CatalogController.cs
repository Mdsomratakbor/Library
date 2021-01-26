using Library.Services.Interfaces;
using Library.Web.ViewModels.Catalog;
using Library.Web.ViewModels.CheckoutViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryServices _assets;
        private readonly ICheckout _checkouts;
        public CatalogController(ILibraryServices assets, ICheckout checkouts)
        {
            _assets = assets;
            _checkouts = checkouts;
        }
        public IActionResult Index()
        {
            var assetsViewModels = _assets.GetAll();
            var listingResult = assetsViewModels.Select(result => new AssetIndexListingViewModel
            {
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirectory(result.Id),
                DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                Title = result.Title,
                Type = _assets.GetType(result.Id)
            }).ToList();
            var model = new AssetIndexViewModels
            {
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);
            var currentHolds = _checkouts.GetCurrentHolds(id)
                .Select(x => new AssetHoldModel
                {
                    HoldPlaced = _checkouts.GetCurrentHoldPlaced(x.Id),
                    PatronName = _checkouts.GetCurrentHoldPatronName(x.Id)
                }).ToList();
            AssetDetailModel model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirectory(id),
                CurrentLocation = _assets.GetCurrentLocation(id).Name,
                Dewey = _assets.GetDeweyIndex(id),
                ISBN = _assets.GetIsbn(id),
                CheckoutHistories = _checkouts.GetCheckoutHistory(id),
                LatestCheckout = _checkouts.GetLatestCheckout(id),
                PatronName = _checkouts.GetCurrentCheckoutPatron(id),
                CurrentHolds = currentHolds

            };
            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var asset = _assets.GetById(id);
            var model = new CheckoutViewModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkouts.IsCheckedOut(id)
            };
            return View(model);
        }
        public IActionResult CheckIn(int id)
        {
            _checkouts.CheckInItem(id);
            return RedirectToAction("Detail", new { id = id });
        }
        public IActionResult Hold(int id)
        {
            var asset = _assets.GetById(id);
            var model = new CheckoutViewModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkouts.IsCheckedOut(id),
                HoldCount = _checkouts.GetCurrentHolds(id).Count()
            };
            return View(model);
        }
        public IActionResult MarkLost(int assetId)
        {
            _checkouts.MarkLost(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }
        public IActionResult MarkFound(int assetId)
        {
            _checkouts.MarkFound(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }
        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            _checkouts.CheckOutItem(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });
        }
 
        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            _checkouts.PlaceHold(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });
        }
    }
}

