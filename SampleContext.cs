using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SingleOrFirstBenchmark
{
    public class SampleContext : DbContext
    {
        public DbSet<SampleRecord?> SampleRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(
                @"Server=PLUTO-0101;Database=SampleRecords;Trusted_Connection=True;Encrypt=False");
        }
    }
}
