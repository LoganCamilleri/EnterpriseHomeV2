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

        public IQueryable<TextFileModel> GetFileEntries()
        { 
            return context.TextFiles; 
        }

        public TextFileModel GetFile(Guid name)
        {
            return context.TextFiles.SingleOrDefault(x => x.FileName == name);
        }

        public IQueryable<AclModel> GetPermissions()
        {
            return context.Acls;
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

        public void EditFile(TextFileModel updatedFile)
        {
            var originalFile = GetFile(updatedFile.FileName);

            originalFile.Data = updatedFile.Data;
            originalFile.LastEditedBy = updatedFile.LastEditedBy;
            originalFile.LastUpdated = DateTime.Now;

            context.SaveChanges();
        }

        public void ShareFile(AclModel a)
        {
            AclModel acl = new AclModel()
            {
                FileName = a.FileName,
                Username = a.Username
            };
            context.Acls.Add(a);
            context.SaveChanges();
        }
    }
}
