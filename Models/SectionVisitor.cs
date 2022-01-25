using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class SectionVisitor
    {
        public int VisitorId { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
