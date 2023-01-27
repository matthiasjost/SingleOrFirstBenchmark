using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace SingleOrFirstBenchmark
{
    public class Benchmarks
    {
        [Benchmark]
        public async Task FirstOrDefaultSenario()
        {
            Guid lastGuid = Guid.Parse("090c2fa6-5a4e-44e9-9b43-c68862463746");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordFirst = context.SampleRecords.FirstOrDefault(r => r.Uid == lastGuid);
            }
        }
        
        [Benchmark(Baseline = true)]
        public void SingleOrDefaultScenario()
        {
            Guid lastGuid = Guid.Parse("090c2fa6-5a4e-44e9-9b43-c68862463746");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordSingle =
                    context.SampleRecords.SingleOrDefault(r => r.Uid == lastGuid);
            }
        }
    }
}