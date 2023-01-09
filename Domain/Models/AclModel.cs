using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class AclModel
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("TextFileModel")]
        public Guid FileName { get; set; }
        public TextFileModel TextFileModel { get; set; }
        public String Username { get; set; }
    }
}
