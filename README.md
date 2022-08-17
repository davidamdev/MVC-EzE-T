# MVC Ez E&T (Example and Tutorial)

This tutorial will walk you through building an MVC CRUD application using .NET 6. It's divided into the following sections:

1. [Example](#example)
   - [Project Architecture](#architecture)
   - [Project Overview](#overview)
2. [Tutorial](#tutorial)
   - [Prerequisites](#prerequisites)
   - [.NET 6 MVC Tutorial](#net-6-mvc)
      1. [Create a new project](#1--create-a-new-project)
      2. [Install dependencies](#2--install-dependencies)
      3. [Create a class](#3--first-entity-creation)
      4. [Connect database](#4--connect-database)
      5. [Scaffolding](#5--scaffolding)

5. [Next Steps](#next-steps)

## Example

### **Architecture**:

Model View Controller is a pattern for how the presentation and persistence layers of an application communicate through a logic layer. Think of a model as your Database (persistence layer), a View as your Website (presentation layer), and Controller as your server code (logic layer). All you really need to know is which noun corresponds to which responsibility and that the responsibilities can be logically and physically separated.

### **Overview**:

Today you're going to build an MVC Snowboard Shop. Basically, we’re building a generic IMS (inventory management system), that will create, read, update, and delete snowboards. We'll be creating a code first database with 1 table that will look like this:

| ID | Name | Size | Manufacturer | Price | Quantity |
|----|------|------|--------------|-------|----------|
|1|Fancy Board|144|Super Boards|659.95|5|
|2|Fancy Board|159|Super Boards|659.95|5|
|3|Ez Board|144|Super Boards|499.95|10|
|4|Ez Board|144|Super Boards|499.95|10|

## Tutorial

### **Prerequisites**:

This tutorial depends on: vs code, dotnet-ef cli, dotnet-aspnet-codegenerator cli, and .net 6 sdk. The following script automates the onboarding process.

```ps
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/davidamdev/MVC-EzE-T/2022/Onboarding/onboarding.ps1'))
```

### **.NET 6 MVC**:

Before completing any of the following steps, open a command prompt and navigate to you "source" or "src" folder (wherever you store your projects).

1. #### Create a new project

   - Run `dotnet new -o OnlyBoards.Core` in your previously opened command prompt.

2. #### Install dependencies

   - Change directory to OnlyBoards.Core: `cd OnlyBoards.Core`

   - Run the following commands in your previously opened command prompt:
      - `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
      - `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
      - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
      - `dotnet add package Microsoft.EntityFrameworkCore.Design`
      - `dotnet add package Microsoft.EntityFrameworkCore`

3. #### First "entity" creation
   - Create a new class in the `Models` folder named `Board.cs`
   - Add the following code to `Board.cs`:

```c#
using System.ComponentModel.DataAnnotations;

public class Board
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
```
4. #### Connect database
   - Create a new folder in the root directory named `Data`.
   - Create a new class in the `Data` folder named `Context.cs`.
   - Open the `Program.cs` class and add `builder.Services.AddDbContext<Context>();` after the line `var builder = WebApplication.CreateBuilder(args);`.
   - Add the following code to `Context.cs`:

```c#
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
   public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(@"Data Source=OnlyBoards.db");
    }
   
   public DbSet<Board> Boards { get; set; }
}
```

5. #### Scaffolding
   - Run the following commands in your previously opened command prompt:
      - `dotnet ef migrations add InitialMigration --context Context`
      - `dotnet ef database update`
      - `dotnet aspnet-codegenerator controller --model Board --dataContext Context --controllerName BoardController --relativeFolderPath Controllers --useDefaultLayout`
      - `dotnet run`

Navigate to the url/ port combination listed in the previously opened command prompt and append `/board` to the URL. **You have a working MVC CRUD application writen in C# 10 and .NET 6.** 

## Next Steps:

Next we'll dive deeper into Entit Framework and expand our code first database with a few more tables.