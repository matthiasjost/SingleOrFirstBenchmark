using Microsoft.EntityFrameworkCore;
using System;

namespace SingleOrFirstBenchmark;

public class SampleContext : DbContext
{
  public DbSet<SampleRecord?> SampleRecords { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //optionsBuilder.LogTo(Console.WriteLine);
    optionsBuilder.UseSqlServer(
        @"Server=PLUTO-0101;Database=SampleRecords;Trusted_Connection=True;Encrypt=False");
  }
}
