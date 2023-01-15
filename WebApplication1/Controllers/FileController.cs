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
            fileService.AddFile(data);

            return View();
        }
    }
}
