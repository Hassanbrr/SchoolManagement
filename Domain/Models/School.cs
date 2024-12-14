using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }


        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual Manger Manger { get; set; }
        public virtual Deputy Deputy { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
