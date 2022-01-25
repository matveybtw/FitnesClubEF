using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class Section
    {
        public Section()
        {
            Instructors = new HashSet<Instructor>();
            SectionVisitors = new HashSet<SectionVisitor>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string SectionTitle { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<SectionVisitor> SectionVisitors { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
