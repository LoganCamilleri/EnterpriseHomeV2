using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.View_Models
{
    public class FileViewModel
    {
        public Guid FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public String Data { get; set; }
        public String Author { get; set; }
        public String LastEditedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
