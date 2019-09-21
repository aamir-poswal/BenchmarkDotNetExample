#### Checking .NET application performance at more granular level using BenchmarkDotNet
Following example shows how we can use BenchmarkDotNet to compare the performance of Serialization to JSON (using Newtonsoft.Json) and Binary Serialization. 

Similarly as per our requirements, we can leverage BenchmarkDotNet to check the performance of different implementation component we have like â€œTo measure the performance Entity Framework 6.0 and Entity Framework Coreâ€, and so on.

####  I am using

Visual Studio Code
 .NET Core 3.0 Preview 9
 
#### Packages 

Newtonsoft.Json

BenchmarkDotNet


####  Create new console application

dotnet new console

Add packages as required. For this example I needed following

dotnet add package BenchmarkDotNet

dotnet add package Newtonsoft.Json

####  Lastly run the application in release mode it is important.

dotnet run -c release

![image](https://user-images.githubusercontent.com/1701237/65369731-2ef85880-dc51-11e9-9f2e-a092832f2c77.png)
