using System.Diagnostics;
using BotyApp.Models.Repositories;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using BotyApp.Models;

namespace BotyApp.Controllers
    {
    
    public class SneakerController : Controller
    {
        private readonly IModelRepository _modelRepository;
        private readonly ISneakerRepository _sneakerRepository;

        public SneakerController(ISneakerRepository sneakerRepository, IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
            
            
            _sneakerRepository = sneakerRepository;


        }

        public IActionResult Index()
        {
            ViewData["Sneakers"] = _sneakerRepository.FindAll();



            return View();
        }

        public IActionResult Add()
        {
            ViewData["Models"] = _modelRepository.FindAll();

            return View("Views/Sneaker/AddSneakerForm.cshtml");


        }

        public IActionResult AddSneaker()
        {
            var brand = (string)Request.Form["brand"];
            var size = (string)Request.Form["size"];


            var modelId = Convert.ToInt32(Request.Form["category"]);


            var model = _modelRepository.FindById(modelId);
            var file = Request.Form.Files[0];


            var uploadPath = Path.GetRelativePath(".", "wwwroot/upload/" + file.FileName);

            using (var stream = System.IO.File.Create(uploadPath))
            {
                file.CopyTo(stream);


            }

            _sneakerRepository.AddSneaker(brand, model, size, file.FileName);


            return new RedirectToRouteResult(new { controller = "Sneaker", action="Index" });


        }
        public IActionResult EditSneaker(int id)
        {
            var brand = (string)Request.Form["brand"];


            var modelId = Convert.ToInt32(Request.Form["category"]);
            var size = (string)Request.Form["size"];


            var model = _modelRepository.FindById(modelId);
            var sneaker = _sneakerRepository.FindById(id);
            var file = Request.Form.Files[0];

            var uploadPath = Path.GetRelativePath(".", "wwwroot/upload/" + file.FileName);
            using (var stream = System.IO.File.Create(uploadPath))
            {
                file.CopyTo(stream);
            }
            if (sneaker != null)
            {
                sneaker.Brand = brand;
                sneaker.Model = model;

                sneaker.Size = size;
                sneaker.Photo = file.FileName;
                _sneakerRepository.UpdateSneaker(sneaker);


                return new RedirectToRouteResult(new {controller = "Sneaker", action = "Index"});
            }
            return new RedirectToRouteResult(new { controller = "Sneaker", action = "Index" });
            
        }
        public IActionResult Edit(int id)
        {
            ViewData["Models"] = _modelRepository.FindAll();

            ViewData["Sneaker"] = _sneakerRepository.FindById(id);

            return View("Views/Sneaker/EditSneakerForm.cshtml");
        }

        public IActionResult Delete(int id)
        {
            var sneaker = _sneakerRepository.FindById(id);
            if(sneaker == null)
            {
                return new RedirectToRouteResult(new { controller = "Sneaker", action = "Index" });

            }
            _sneakerRepository.DeleteSneaker(sneaker);

            return new RedirectToRouteResult(new { controller = "Sneaker", action = "Index" });
        }
    }
}