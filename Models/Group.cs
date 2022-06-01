﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationEPAC.Models
{
    public class Group
    {
        public enum TypeGroup
        {
            Morning,
            Afternoon
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public TypeGroup type { get; set; }

        public int Credits { get; set; }
    }
}