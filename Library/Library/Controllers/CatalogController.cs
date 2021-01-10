using Library.Services.Interfaces;
using Library.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class CatalogController : Controller
    {
        private  readonly ILibraryServices _assets;
        public CatalogController(ILibraryServices assets)
        {
            _assets = assets;
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
    }
}
