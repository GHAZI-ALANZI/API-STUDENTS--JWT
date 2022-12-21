using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace School_API.Models
{
    public partial class Student
    {
        [Key]
        public string StudentId { get; set; } = null!;
        public string? EnrollmentNo { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? FatherCn { get; set; }
        public string? PermanentAddress { get; set; }
        public string? TemporaryAddress { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public string Session { get; set; } = null!;
        public string Caste { get; set; } = null!;
        public string Religion { get; set; } = null!;
        public byte[] Photo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Nationality { get; set; }
        public string? Class { get; set; }
        public string? Section { get; set; }
        public int? SchoolId { get; set; }

        public virtual School? School { get; set; }
        
    }
}
