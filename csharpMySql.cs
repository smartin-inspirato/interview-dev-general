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
- Boilerplate is provided. Feel free to change the code as you see fit

Assumptions:
- You cannot change the database structure at this time
*/

class Solution
{
    static void Main(string[] args)
    {
        using (var db = new DatabaseContext())
        {
            // Find all employees.
            var employees = db.employees.ToList();
            int count = 0;
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.id + ", " 
                                + employee.first_name + ", " 
                                + employee.last_name + ", "
                                + employee.salary);
                count++;
            }
            

            
        }
    }
}

// Define a class that matches the employees table schema.

public class Employee
{
    #nullable enable
    public int id { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public int? salary { get; set; }
}

public class DatabaseContext : DbContext
{
    public DbSet<Employee> employees { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("Server=/tmp/mysql/socket/mysqld.sock; Protocol=unix; Database=coderpad; Username=coderpad");
    }
}

