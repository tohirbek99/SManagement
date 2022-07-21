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
        public ViewResult Details(int id)
        {

            Staf staf = _iSRRepository.Get(id);
            if (staf != null)
            {
                HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
                {
                    Staf = staf,
                    Title = "Staf Details"
                };
                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }

        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("StafNotFound", id);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Staf staf = _iSRRepository.Get(id);
            if (staf != null)
            {
                HomeEditViewModel editViewModel = new HomeEditViewModel()
                {
                    Id = staf.Id,
                    FirstName = staf.FirstName,
                    LastName = staf.LastName,
                    Email = staf.Email,
                    Department = staf.Department,
                    ExPhotoFilePath = staf.PhotoFillPath
                };
                return View(editViewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staf)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(staf);
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
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel staf)
        {
            if (ModelState.IsValid)
            {
                Staf existingStaf = _iSRRepository.Get(staf.Id);
                existingStaf.FirstName = staf.FirstName;
                existingStaf.LastName = staf.LastName;
                existingStaf.Email = staf.Email;
                existingStaf.Department = staf.Department;
                if (staf.Photo != null)
                {
                    if (staf.ExPhotoFilePath != null)
                    {
                       string filePath= Path.Combine(webHost.WebRootPath, "images",staf.ExPhotoFilePath);
                        System.IO.File.Delete(filePath);
                    }
                    existingStaf.PhotoFillPath = ProcessUploadedFile(staf);
                }
              

             
               _iSRRepository.Update(existingStaf);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Staf staf = _iSRRepository.Get(id);
            if (staf != null)
            {
                _iSRRepository.Delete(id);

                return RedirectToAction("index");
            }
            else
            {
                return NotFoundView(id);
            }
             
        }

        private string ProcessUploadedFile(HomeCreateViewModel staf)
        {
            string uniqueFileName = string.Empty;
            if (staf.Photo != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staf.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    staf.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
