﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Languages> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
}
