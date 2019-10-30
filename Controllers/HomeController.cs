using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microgreens.Models;
using Microgreens.Services;

namespace Microgreens

{
    public class HomeController : Controller
    {
        private readonly ITextFileOperations _textFileOperations;

        public HomeController(ITextFileOperations textFileOperations)
        {
            _textFileOperations = textFileOperations;
        }



        public IActionResult Index()
        {
            ViewBag.Steve = "Welcome to Visitor Management";
            ViewData["Sam"] = "Another welcome";

            ViewBag.NewVisitor = new Visitors()
            {
                FirstName = "Howard",
                LastName = "Jones"
            };
            //   Environment myEnvironment = new Environment;
            //======= Conditions of Acceptance
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.

            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();

            return View();
        }

        public IActionResult ProductAPI()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
