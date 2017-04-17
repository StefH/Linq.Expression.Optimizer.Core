rem https://www.appveyor.com/blog/2017/03/17/codecov/

rem C:\Users\Stef\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -target:"C:\Users\Stef\.nuget\packages\xunit.runner.console\2.3.0-beta1-build3642\tools\xunit.console.x86.exe" -targetargs:"test\System.Linq.Dynamic.Core.Tests\bin\Debug\netcoreapp1.1\System.Linq.Dynamic.Core.Tests.dll -noshadow" -output:".\coverage.xml" -filter:+[System.Linq.Dynamic.Core]*'

%USERPROFILE%\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -target:dotnet.exe -targetargs:"test tests\Linq.Expression.Optimizer.Tests\Linq.Expression.Optimizer.Tests.csproj" -output:coverage.xml -register:user -filter:"+[Linq.Expression.Optimizer]* -[*Tests*]*" -nodefaultfilters -returntargetcode -oldstyle -searchdirs:"tests\Linq.Expression.Optimizer.Tests\bin\Debug\net452"

%USERPROFILE%\.nuget\packages\ReportGenerator\2.5.6\tools\ReportGenerator.exe -reports:"coverage.xml" -targetdir:"report"

start report\index.htm