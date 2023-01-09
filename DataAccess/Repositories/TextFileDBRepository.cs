using DataAccess.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class TextFileDBRepository
    {
        private FileSharingContext context { get; set; }

        public TextFileDBRepository(FileSharingContext _context)
        {
            context = _context;
        }

        public IQueryable<TextFileModel> GetFiles()
        { 
            return context.TextFiles; 
        }

        public void AddFile(TextFileModel f)
        {
            TextFileModel textFile = new TextFileModel()
            {
                FileName = Guid.NewGuid(),
                UploadedOn = DateTime.Now,
                Data = f.Data,
                Author = f.Author,
                LastEditedBy = f.Author,
                LastUpdated = DateTime.Now
            };
            context.TextFiles.Add(f);
            context.SaveChanges();
        }

        public void EditFile()
        { }

        public void ShareFile()
        { }
    }
}
