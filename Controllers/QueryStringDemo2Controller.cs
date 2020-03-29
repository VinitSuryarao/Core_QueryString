using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QueryString.Controllers
{
    public class QueryStringDemo2Controller : Controller
    {
        #region Public Property
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        #endregion 

        public IActionResult Index()
        {
            return View();
        }

        // BindPropertyAction For Get data from Using BindProperty
        // http://localhost:61413/BindPropertyAction/45
        [HttpGet("BindPropertyAction/{Id:int}", Name = "BindPropertyAction")]
        public IActionResult BindPropertyAction()
        {
            ViewBag.ID = Id;
            return View("Index");
        }

        // FromQueryAction Get Data from using FromQuery attribute Service
        [HttpGet("FromQueryAction", Name = "FromQueryAction")]
        //http://localhost:61413/FromQueryAction?FirstName=Vinit&LastName=Suryarao
        public IActionResult FromQueryAction(
            [FromQuery(Name = "FirstName")] string FirstName,
            [FromQuery(Name = "LastName")] string LastName)
        {
            ViewBag.FirstName = FirstName; // firstName
            ViewBag.LastName = LastName; // lastName

            return View("Index");
        }


        // FromRouteAction Get data from using FromRoute attribute Service
        [HttpGet("FromRouteAction/FirstName/{FirstName}/LastName/{LastName}", Name = "FromRouteAction")]
        // http://localhost:61413/FromRouteAction/FirstName/Vinit/LastName/Suryarao
        public IActionResult FromRouteAction(
            [FromRoute(Name = "FirstName")] string FirstName,
            [FromRoute(Name = "LastName")] string LastName
            )
        {
            ViewBag.FirstName = FirstName; // firstName
            ViewBag.LastName = LastName; // lastName

            return View("Index");
        }


        // HttpContextAction Get data from using HttpContextAction
        [HttpGet("HttpContextAction", Name = "HttpContextAction")]
        //http://localhost:61413/HttpContextAction?FirstName=Vinit&LastName=Suryarao%20
        public IActionResult HttpContextAction()
        {
            ViewBag.FirstName = HttpContext.Request.Query["FirstName"].ToString();
            ViewBag.LastName = HttpContext.Request.Query["LastName"].ToString();


            return View("Index");

        }


    }
}