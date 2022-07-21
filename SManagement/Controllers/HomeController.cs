using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SManagement.Models;
using SManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SManagement.Controllers
{  
    //[Route("[controller]")]
    public class HomeController : Controller
    { 
     
        private readonly ISRepository _iSRRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(ISRepository iSRepository, IWebHostEnvironment webHost)
        {
            _iSRRepository = iSRepository;
            this.webHost = webHost;
        }
        //[Route("")]
        //[Route("/")]
        //[Route("[action]")]
        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Stafs =  _iSRRepository.GetAll()
            };
            return View(viewModel);
        }  
        //[Route("[action]/{Id?}")]
        public ViewResult Details(int? id)
        {


            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staf = _iSRRepository.Get(id??1),
                Title = "Staf Details"
            };
            

            return View(viewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staf)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (staf.Photo != null)
                {
                    string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + staf.Photo.FileName;
                    string imaaFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    staf.Photo.CopyTo(new FileStream(imaaFilePath, FileMode.Create));
                }
                Staf newstaf = new Staf()
                {
                    FirstName = staf.FirstName,
                    LastName=staf.LastName,
                    Email=staf.Email,
                    Department=staf.Department,
                    PhotoFillPath=uniqueFileName
                };

                var newStaf = _iSRRepository.Create(newstaf);
               return RedirectToAction("details", new { id = newStaf.Id });
            }
            return View();
        }
       
    }
}
