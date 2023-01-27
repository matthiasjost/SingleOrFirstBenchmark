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
        public async Task FirstOrDefault_Indexed_Last()
        {
            Guid lastGuid = Guid.Parse("090c2fa6-5a4e-44e9-9b43-c68862463746");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordFirst = context.SampleRecords.FirstOrDefault(r => r.Uid == lastGuid);
            }
        }

        [Benchmark]
        public async Task FirstOrDefault_Indexed_First()
        {
            Guid firstGuid = Guid.Parse("6c121f49-bc78-4cb2-b34c-b7fd15b9820d");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordFirst = context.SampleRecords.FirstOrDefault(r => r.Uid == firstGuid);
            }
        }

        [Benchmark(Baseline = true)]
        public void SingleOrDefault_Indexed_Last()
        {
            Guid lastGuid = Guid.Parse("090c2fa6-5a4e-44e9-9b43-c68862463746");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordSingle =
                    context.SampleRecords.SingleOrDefault(r => r.Uid == lastGuid);
            }
        }

        [Benchmark]
        public void SingleOrDefault_Indexed_First()
        {
            Guid firstGuid = Guid.Parse("6c121f49-bc78-4cb2-b34c-b7fd15b9820d");

            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordSingle =
                    context.SampleRecords.SingleOrDefault(r => r.Uid == firstGuid);
            }
        }

        [Benchmark]
        public async Task FirstOrDefault_NotIndexed_Last()
        {
            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordFirst = context.SampleRecords.FirstOrDefault(r => r.Name == "10000000");
            }
        }

        [Benchmark]
        public async Task FirstOrDefault_NotIndexed_First()
        {
            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordFirst = context.SampleRecords.FirstOrDefault(r => r.Name == "1");
            }
        }

        [Benchmark]
        public void SingleOrDefault_NotIndexed_Last()
        {
            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordSingle =
                    context.SampleRecords.SingleOrDefault(r => r.Name == "10000000");
            }
        }

        [Benchmark]
        public void SingleOrDefault_NotIndexed_First()
        {
            using (SampleContext context = new SampleContext())
            {
                SampleRecord recordSingle =
                    context.SampleRecords.SingleOrDefault(r => r.Name == "1"); ;
            }
        }
    }
}