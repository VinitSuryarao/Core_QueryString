using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QueryString.Controllers
{
    public class QueryStringDemo1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}