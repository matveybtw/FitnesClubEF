using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
    }
}
