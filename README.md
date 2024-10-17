We know the caching refers to storing frequently used or retriving data in temporary high-speed storage to reduce the latency of a system.
I use the Redis Cache here in .NET Core 8.0 web API including SQL Server database. I covered the installation of required packages, configuration of the Redis connection, implementation of caching logic, and verification of cache usage.
Steps:
i) Create a .NET core web API project
ii) Add some nuget packages
HtmlAgilityPack
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.Extensions.Caching.StackExchangeRedis
Newtonsoft.Json
iii) Create model, service for cache, entity repository and controller etc.
