using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class Visit
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public DateTime When { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
