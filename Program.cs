using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SingleOrFirstBenchmark;

public class Program
{
  public static async Task Main(string[] args)
  {
    //await InitialiseDbWithRecords();
    //var benchmark = new Benchmarks();
    //benchmark.FirstOrDefault_Indexed_Last();
    var summary = BenchmarkRunner.Run<Benchmarks>();
  }

  private static async Task InitialiseDbWithRecords()
  {
    var dbContext = new SampleContext();

    if (dbContext.SampleRecords.Any())
    {
      foreach (var record in dbContext.SampleRecords)
      {
        dbContext.SampleRecords.Remove(record);
      }
    }
    await dbContext.SaveChangesAsync();

    for (int i = 1; i <= 1_000_000; i++)
    {
      if (i == 1)
      {
        dbContext.SampleRecords.Add(new SampleRecord()
        {
          Uid = Guid.Parse("6c121f49-bc78-4cb2-b34c-b7fd15b9820d"),
          Name = i.ToString(),
        });
      }
      else if (i == 1_000_000)
      {
        dbContext.SampleRecords.Add(new SampleRecord()
        {
          Uid = Guid.Parse("090c2fa6-5a4e-44e9-9b43-c68862463746"),
          Name = i.ToString(),
        });
      }
      else
      {
        dbContext.SampleRecords.Add(new SampleRecord()
        {
          Uid = Guid.NewGuid(),
          Name = i.ToString(),
        });
      }

      if (i % 10000 == 0)
      {
        await dbContext.SaveChangesAsync();
        Console.WriteLine(i);
      }
    }
    await dbContext.SaveChangesAsync();
  }
}