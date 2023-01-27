using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace SingleOrFirstBenchmark
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await InitialiseDbWithRecords();

            var summary = BenchmarkRunner.Run<Benchmarks>();

            Console.ReadLine();
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

            for (int i = 1; i <= 10_000_000; i++)
            {
                if (i == 10_000_000)
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
            }
            await dbContext.SaveChangesAsync();
        }
    }
}