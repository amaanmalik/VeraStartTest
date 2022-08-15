using Microsoft.AspNetCore.Mvc;
using VeraStartTest.Models;
using VeraStartTest.Services;

namespace VeraStartTest.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileUploadService _service;

        public FileUploadController(ILogger<HomeController> logger, IFileUploadService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> postedFiles)
        {
            if (postedFiles == null)
                return Content("file not selected");

            foreach (var file in postedFiles)
            {

                var cfile = postedFiles.Where(f => f.FileName == FileType.Customer).FirstOrDefault();
                var ofile = postedFiles.Where(f => f.FileName == FileType.Orders).FirstOrDefault();
                var tfile = postedFiles.Where(f => f.FileName == FileType.OrderItems).FirstOrDefault();

                if(cfile != null) _service.UploadCustomerFile(cfile);
                if(ofile!=null) _service.UploadOrderFile(ofile);
                if(tfile!=null) _service.UploadOrderItemFile(tfile);
            }

            return RedirectToAction("Index","Customer");
        }
    }
}
