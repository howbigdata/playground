using LcaWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcaworld.Db
{
    public class LcaContext : DbContext
    {

        public static readonly ILoggerFactory factory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public LcaContext(DbContextOptions<LcaContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(factory)  //tie-up DbContext with LoggerFactory object
        .EnableSensitiveDataLogging();
        }

           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
        //entities
        public DbSet<SubCompartment> SubCompartments { get; set; }
        public DbSet<ElementaryFlow> ElementaryFlows { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Compartment> Compartments { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessExchanges> ProcessExchanges { get; set; }
        public DbSet<CharacterisationFactor> CharacterisationFactors { get; set; }
        public DbSet<Method> Methods { get; set; }
    }
}
