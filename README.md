# F# slow build in Visual Studio 2026

When building my F# class library and unit tests in Visual Studio 2026 Insiders [11206.111], the build does not complete within a reasonable
amount of time. I stop waiting after a minute.

There is a [GitHub Issue](https://github.com/dotnet/fsharp/issues/19073), and the problem may already be fixed according to the comments.


## Visual Studio 2022

NOTE: you get the following warning: `warning NETSDK1233: Targeting .NET 10.0 or higher in Visual Studio 2022 17.14 is not supported.`

```
========== Rebuild completed at 7:31 AM and took 03.111 seconds ==========
```


## `dotnet build` and `dotnet test`

`dotnet build`:

```
Restore complete (0.7s)
  FSharpSlowBuild net9.0 succeeded (1.2s) → src\FSharpSlowBuild\bin\Debug\net9.0\FSharpSlowBuild.dll
  FSharpSlowBuild net10.0 succeeded (1.3s) → src\FSharpSlowBuild\bin\Debug\net10.0\FSharpSlowBuild.dll
  FSharpSlowBuild net8.0 succeeded (1.4s) → src\FSharpSlowBuild\bin\Debug\net8.0\FSharpSlowBuild.dll
  FSharpSlowBuild.Tests net9.0 succeeded (1.7s) → src\FSharpSlowBuild.Tests\bin\Debug\net9.0\FSharpSlowBuild.Tests.dll
  FSharpSlowBuild.Tests net10.0 succeeded (1.6s) → src\FSharpSlowBuild.Tests\bin\Debug\net10.0\FSharpSlowBuild.Tests.dll
  FSharpSlowBuild.Tests net8.0 succeeded (1.6s) → src\FSharpSlowBuild.Tests\bin\Debug\net8.0\FSharpSlowBuild.Tests.dll

Build succeeded in 3.8s
```

`dotnet test`:

```
Restore complete (0.6s)
  FSharpSlowBuild net8.0 succeeded (1.0s) → src\FSharpSlowBuild\bin\Debug\net8.0\FSharpSlowBuild.dll
  FSharpSlowBuild net9.0 succeeded (1.1s) → src\FSharpSlowBuild\bin\Debug\net9.0\FSharpSlowBuild.dll
  FSharpSlowBuild net10.0 succeeded (1.2s) → src\FSharpSlowBuild\bin\Debug\net10.0\FSharpSlowBuild.dll
  FSharpSlowBuild.Tests net9.0 succeeded (1.6s) → src\FSharpSlowBuild.Tests\bin\Debug\net9.0\FSharpSlowBuild.Tests.dll
  FSharpSlowBuild.Tests net8.0 succeeded (1.6s) → src\FSharpSlowBuild.Tests\bin\Debug\net8.0\FSharpSlowBuild.Tests.dll
  FSharpSlowBuild.Tests net10.0 succeeded (1.6s) → src\FSharpSlowBuild.Tests\bin\Debug\net10.0\FSharpSlowBuild.Tests.dll
  FSharpSlowBuild.Tests test net8.0 succeeded (1.1s)
  FSharpSlowBuild.Tests test net9.0 succeeded (1.2s)
  FSharpSlowBuild.Tests test net10.0 succeeded (1.2s)

Test summary: total: 48, failed: 0, succeeded: 48, skipped: 0, duration: 1.0s
Build succeeded in 4.8s
```

## Visual Studio 2026 (both regular and Insiders)

I canceled the build after a minute.

```
Rebuild started at 7:35 AM...
1>------ Rebuild All started: Project: FSharpSlowBuild, Configuration: Debug Any CPU ------
Restored C:\Dev\OPENSOURCE\FSharpSlowBuild\src\FSharpSlowBuild\FSharpSlowBuild.fsproj (in 10 ms).
Restored C:\Dev\OPENSOURCE\FSharpSlowBuild\src\FSharpSlowBuild.Tests\FSharpSlowBuild.Tests.fsproj (in 18 ms).
1>  FSharpSlowBuild -> C:\Dev\OPENSOURCE\FSharpSlowBuild\src\FSharpSlowBuild\bin\Debug\net9.0\FSharpSlowBuild.dll
1>  FSharpSlowBuild -> C:\Dev\OPENSOURCE\FSharpSlowBuild\src\FSharpSlowBuild\bin\Debug\net10.0\FSharpSlowBuild.dll
1>  FSharpSlowBuild -> C:\Dev\OPENSOURCE\FSharpSlowBuild\src\FSharpSlowBuild\bin\Debug\net8.0\FSharpSlowBuild.dll
2>------ Rebuild All started: Project: FSharpSlowBuild.Tests, Configuration: Debug Any CPU ------
Build has been canceled.
========== Elapsed 01:05.246 minutes ==========
```