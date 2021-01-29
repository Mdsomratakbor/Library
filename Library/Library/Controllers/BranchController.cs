using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class BranchController : Controller
    {
        private IBranchServices _branchServices;
        public BranchController(IBranchServices branch)
        {
            _branchServices = branch;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
