﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBasic.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
    }
}
