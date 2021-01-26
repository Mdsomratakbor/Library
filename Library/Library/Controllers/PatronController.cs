using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class PatronController :Controller
    {
        public PatronController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
