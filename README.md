This project for learning c# from youtube: build an ids with c# by ShaneInSweden

I convert his project into dotnet core and run in vscode. you can restore db from file Database\IDSDB.mdf
and update your db connection string to run this solution in your local.  Happy Coding

dotnet add package System.Xml.Linq
dotnet add package ..\References\PacketDotNet.dll
dotnet add package ..\Common.Data\Common.Data.csproj

check in .csproj to see the reference is there sometime you need to add yourself

install extensions: SQL Server (mssql)
database connect > select server>database>create the profile name to save

ctrl + shift + p > "MS SQL" connect > (localdb)\MSSQLLocalDB > IDSDB

open .sql file then ctrl + shift + e to run the query

extension roslynator 

Part 14: BlackNurseDos attack 5000 package per second cause the network to down
https://www.youtube.com/watch?v=_f2p37F8aRo&list=PL9EdUUfu9_As7joMSFZNFBaQ6RiwPD91t&index=14

download the code with rules
https://github.com/shaneinsweden/IDS/blob/master/TyranIds13.zip

in order to find F12 work need to create a solution and add projects into the solution file, Ctrl + Shift + P select OmiSharp project and select the solution file

dotnet sln new --name myslution
dotnet sln add .\WebMonitorSensor.TestClient\WebMonitorSensor.TestClient.csproj
-- run project solution solution directory
dotnet run --project .\WebMonitorSensor.TestClient\WebMonitorSensor.TestClient.csproj

debug test setup
// when target netstandard2.0 cause a lot error and warning, but change to netcoreapp2.0 then thing start to work
the file: Ids.Tests\Ids.Test.csproj

<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <GenerateProgramFile>false</GenerateProgramFile>
  </PropertyGroup>

-- to test a specific test name
dotnet test --filter CreatePortScanSensor_PortScanPackets_PortScanAlertCtreated

-- how to setup a debug for unit test https://xpirit.com/netcore-withvscode-should-haveunit-tests/
file .vscode\tasks.json update
,
        {
            "label": "test",
            "command": "dotnet",
            "type": "shell",
            "group": {
                "isDefault": true,
                "kind": "test"   
            },
            "args": [
                "test",
                "${workspaceFolder}/Ids.Tests/Ids.Tests.csproj"
            ],
            "presentation": {
                "reveal": "always",
            },
            "problemMatcher": "$msCompile"
          }

-- then install extensions: .net core test exploer by Jun han
select your test in the exploer right click select dropdown menu debug

-- display all test details -v for display verbosity and n mean verbosity in normal mode
dotnet test -v n


--------------------------------------------------------ef code first
dotnet new classlib --framework netcoreapp3.0 -o Ids.Data
cd Ids.Data
dotnet add reference ..\Common\Common.csproj
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add packaga Microsoft.EntityFrameworkCore.Design

neew file DataContext.cs

https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet
--- add ef tools as global like most developers
dotnet tool install --global dotnet-ef

+ add DBContextFactory.cs
--- create migration
dotnet ef migrations add InitialCreate

dotnet ef database update InitialCreate
dotnet ef database update 20180904195021_InitialCreate

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/

After create db: follow the steps
1. update the model and db codes
2. run: dotnet ef migrations add XYZ  -- to generate the code change to be run for db update dabase up and down
3. run: dotnet ef database update XYZ    -- to push migration code to db




