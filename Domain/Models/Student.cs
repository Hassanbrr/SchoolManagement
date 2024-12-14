using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Gender { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required]
        public virtual ICollection<Classroom> Classrooms { get; set; }

    }
}
