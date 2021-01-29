using Library.Services.Interfaces;
using Library.Web.ViewModels.BranchViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchServices _branchServices;
        public BranchController(IBranchServices branch)
        {
            _branchServices = branch;
        }
        public IActionResult Index()
        {
            var branches = _branchServices.GetAll().Select(x => new BranchDetailViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsOpen = _branchServices.IsBranchOpen(x.Id),
                NumberOfAssets = _branchServices.GetAssets(x.Id).Count,
                NumberOfPatrons = _branchServices.GetPatrons(x.Id).Count,

            });
            var model = new BranchIndexViewmodel()
            {
                Braches = branches.ToList()
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branchServices.Get(id);
            var model = new BranchDetailViewModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenDate = branch.OpenDate.ToString("yyyyy-MM-dd"),
                NumberOfAssets = _branchServices.GetAssets(branch.Id).Count(),
                NumberOfPatrons = _branchServices.GetPatrons(branch.Id).Count(),
                TotalAssetValue = _branchServices.GetAssets(id).Sum(x=>x.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branchServices.GetBranchHours(id)
            };
            return View(model);
        }
    }
}
