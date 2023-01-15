using BuisnessLogic.Services;
using BusinessLogic.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        private FileService fileService;
        public FileController(FileService _fileService)
        { fileService = _fileService; }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFileViewModel data)
        {
            try
            {
                fileService.AddFile(data);
                ViewBag.Message = "File Successfully inserted";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "File could not be inserted";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid Fname)
        {
            var originalFile = fileService.GetFile(Fname);

            CreateFileViewModel model = new CreateFileViewModel();
            model.Data = originalFile.Data;
            model.LastEditedBy = originalFile.LastEditedBy;
            model.LastUpdated = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Share(string recipient, Guid File)
        {
            try
            {
                fileService.ShareFile(recipient, File);
                ViewBag.Message = "File Successfully shared";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "File could not be shared";
            }
            return View();
        }
    }
}
