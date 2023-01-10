using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.View_Models
{
    public class AclViewModel
    {
        public Guid FileName { get; set; }
        public TextFileModel TextFileModel { get; set; }
        public String Username { get; set; }
    }
}
