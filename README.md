# SingleOrFirstBenchmark

This repository contains some performance tests to compare SingleOrDefault and FirstOrDefault.

The tests were done with EF Core and an MS SQL server database.

The console application also contains the code to fill the table with example data.

## Summary Table 

(BenchmarkDotNet Console Output)

|                           Method |       Mean |     Error |     StdDev |     Median |  Ratio | RatioSD |
|--------------------------------- |-----------:|----------:|-----------:|-----------:|-------:|--------:|
|      FirstOrDefault_Indexed_Last |   1.702 ms | 0.0556 ms |  0.1595 ms |   1.694 ms |   1.32 |    0.22 |
|     FirstOrDefault_Indexed_First |   1.421 ms | 0.0604 ms |  0.1734 ms |   1.401 ms |   1.10 |    0.15 |
|     SingleOrDefault_Indexed_Last |   1.316 ms | 0.0531 ms |  0.1488 ms |   1.285 ms |   1.00 |    0.00 |
|    SingleOrDefault_Indexed_First |   1.329 ms | 0.0797 ms |  0.2210 ms |   1.290 ms |   1.02 |    0.20 |
|   FirstOrDefault_NotIndexed_Last | 248.808 ms | 4.8239 ms |  7.0708 ms | 247.337 ms | 184.70 |   21.54 |
|  FirstOrDefault_NotIndexed_First |  28.865 ms | 1.1559 ms |  3.3719 ms |  29.820 ms |  21.98 |    3.45 |
|  SingleOrDefault_NotIndexed_Last | 234.705 ms | 6.6970 ms | 18.3330 ms | 229.725 ms | 180.13 |   25.51 |
| SingleOrDefault_NotIndexed_First | 230.140 ms | 4.5863 ms | 12.5549 ms | 229.443 ms | 176.58 |   22.23 |

## See also
* My Blog article: https://www.matthias-jost.ch/ef-core-single-vs-firstordefault/
* Nick Chapsas' YT Video: [SingleOrDefault or FirstOrDefault? When LINQ might harm you](https://www.youtube.com/watch?v=ZTWl2s8ScMc)
