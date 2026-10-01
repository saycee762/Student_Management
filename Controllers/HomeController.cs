// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Controller class that handles requests for the home page, the
//                   privacy page and the error page.

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoardAppDB.Models;

namespace BoardAppDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //
            // Name             : HomeController(ILogger<HomeController> logger)
            // Purpose          : Constructor that stores the logger supplied by dependency injection
            // Re-use           : None
            // Method Parameters: ILogger<HomeController> logger
            //                    - the logger supplied by the framework
            // Output Type      : None
            //
            this.logger = logger;
        } // end method HomeController

        public IActionResult Index()
        {
            //
            // Name             : IActionResult Index()
            // Purpose          : Returns the home page view
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Index view
            //
            return View();
        } // end method Index

        public IActionResult Privacy()
        {
            //
            // Name             : IActionResult Privacy()
            // Purpose          : Returns the privacy page view
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Privacy view
            //
            return View();
        } // end method Privacy

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //
            // Name             : IActionResult Error()
            // Purpose          : Returns the error view with the identifier of the current request
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Error view with an ErrorViewModel
            //
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } // end method Error
    } // end class HomeController
} // end namespace BoardAppDB.Controllers
