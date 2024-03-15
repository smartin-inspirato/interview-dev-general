using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
/*
This EF Code is running sub-optimally

Goals:
- Your solution should be in C# EF - if you would like to use another language, please let the interviewer know.
- Boilerplate is provided. Feel free to change the 'Solution' class as you see fit

Assumptions:
- You cannot change the database structure at this time
*/

class Solution
{
    static void Main(string[] args)
    {
        using (var db = new DatabaseContext())
        {
            InterViewUtility.WarmUpDatabaseConnections(db);
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            // Find all employees.
            var employees = db.employees.ToList().Where(employee => employee.salary > 20000);
            stopwatch.Stop();
            PrintEmployeeList(employees);
            Console.WriteLine($"ElapsedTime {stopwatch.ElapsedMilliseconds}ms");
        }
    }
    
    
    private static void PrintEmployeeList (IEnumerable<Employee> employeeList)
    {
            Console.WriteLine($"{"    ",-4} {"ID",-3} {"First Name",-12} {"Last Name",-12} {"Salary",-10}");
           employeeList.ToList().ForEach(e => 
                    Console.WriteLine($"{"Row:",-4} {e.id,-3}, {e.first_name,-12}, {e.last_name,-12}, {e.salary,10:c}") );
    }
}

/*
Boilerplate below:  You may refer to, but not alter the code below
*/
// Define a class that matches the employees table schema.
public class Employee
{
    #nullable enable
    public int id { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public int? salary { get; set; }
}

// Establish a basic database context
public class DatabaseContext : DbContext
{
    public DbSet<Employee> employees { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("Server=/tmp/mysql/socket/mysqld.sock; Protocol=unix; Database=coderpad; Username=coderpad");
    }
}

public static class InterViewUtility
{
    public static void WarmUpDatabaseConnections(DatabaseContext context)   
    {
        var x =    context.employees.Take(1).ToList();
    }
}