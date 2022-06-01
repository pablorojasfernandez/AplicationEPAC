using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationEPAC.Models
{
    public class Enrolment
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string Date { get; set; }
    }
}