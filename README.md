# SingleOrFirstBenchmark
// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22623



|                  Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------ |---------:|----------:|----------:|------:|--------:|
|   FirstOrDefaultSenario | 1.307 ms | 0.0801 ms | 0.2110 ms |  1.06 |    0.19 |
| SingleOrDefaultScenario | 1.275 ms | 0.0711 ms | 0.1969 ms |  1.00 |    0.00 |

// * Warnings *

MinIterationTime
  Benchmarks.FirstOrDefaultSenario: 
  Default   -> The minimum observed iteration time is 1.0302 ms which is very small. It's recommended to increase it to at least 100.0000 ms using more operations.
  
  Benchmarks.SingleOrDefaultScenario: 
  Default -> The minimum observed iteration time is 840.2000 us which is very small. It's recommended to increase it to at least 100.0000 ms using more operations.
