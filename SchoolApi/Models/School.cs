using System;
using System.Collections.Generic;

namespace School_API.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
