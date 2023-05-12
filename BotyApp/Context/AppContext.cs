using Microsoft.EntityFrameworkCore;
using System;
using BotyApp.Models;
using System.Collections.Generic;
using System.Reflection;

namespace BotyApp.Context
{
    public class AppContext : DbContext
    {
        public new DbSet<Model> Model { get; set; }


        public DbSet<Sneaker> Sneakers { get; set; }


        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
    }

}
