﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.MoviesAPI.App.Models
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<Movie> Movies { get; set; }
        public Director()
        {
            Movies = new List<Movie>();
        }
    }
}
