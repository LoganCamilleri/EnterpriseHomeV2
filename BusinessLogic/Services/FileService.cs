using BusinessLogic.View_Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLogic.Services
{
    public class FileService
    {
        private TextFileDBRepository fr;
        public FileService(TextFileDBRepository _fileRepository)
        {
            fr = _fileRepository;
        }
        public void AddFile(CreateFileViewModel file)
        {
            fr.AddFile(new Domain.Models.TextFileModel()
            {
                Data = file.Data,
                Author = file.Author
            });
        }

        public IQueryable<FileViewModel> GetFiles()
        {
            var list = from f in fr.GetFiles()
                       select new FileViewModel()
                       {
                           FileName = f.FileName,
                           UploadedOn = f.UploadedOn,
                           Data = f.Data,
                           Author = f.Author,
                           LastEditedBy = f.LastEditedBy,
                           LastUpdated = f.LastUpdated
                       };
            return list;
        }

        public FileViewModel GetFile(Guid Fname)
        {
            return GetFiles().SingleOrDefault(x => x.FileName == Fname);
        }
    }
}
