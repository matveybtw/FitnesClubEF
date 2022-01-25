using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class Visitor
    {
        public Visitor()
        {
            Npuxogs = new HashSet<Npuxog>();
            Pacxogs = new HashSet<Pacxog>();
            SectionVisitors = new HashSet<SectionVisitor>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastTimeVisited { get; set; }
        public int NumOfVisits { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Npuxog> Npuxogs { get; set; }
        public virtual ICollection<Pacxog> Pacxogs { get; set; }
        public virtual ICollection<SectionVisitor> SectionVisitors { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
