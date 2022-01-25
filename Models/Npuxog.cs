using System;
using System.Collections.Generic;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class Npuxog
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public decimal Cost { get; set; }
        public DateTime When { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
