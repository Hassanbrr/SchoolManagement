using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Domain.Models
{
    public class Classroom
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string? ClassName { get; set; }
        [Required]

        public int  SchoolId { get; set; }

        public virtual School? School { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
