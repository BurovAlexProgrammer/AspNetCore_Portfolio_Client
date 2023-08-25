﻿using System;
using WebAPI;
using WebDAL.Entity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            // using (var db = new PostgresDbContext())
            // {
            //     var guests = db.Guests.ToList();
            //
            //     foreach (var guest in guests)
            //     {
            //         Console.WriteLine(guest.Name + Environment.NewLine);
            //     }
            // }
        }

        public static void Test()
        {
            Console.WriteLine("Start");

            using (var db = new PdbContext())
            {
                var guest1 = new Guest() { Name = "Test1", Password = "Ttt" };
                var guest2 = new Guest() { Name = "Test2", Password = "Aaaa" };
                db.Guests.Add(guest1);
                db.Guests.Add(guest2);
                db.SaveChanges();
            }

            using (var db = new PdbContext())
            {
                // var dep3 = db.Departments.Single(x => x.Name == "Dep3");
                // dep3.Name = "Dep33";
                // db.Update(dep3);
                db.SaveChanges();
            }


            // await using (var db = new PostgresDbContext())
            // {
            //     var result = db.Guests.Include(x => x.Department);
            //
            //     foreach (var guest in result)
            //     {
            //         Console.WriteLine($"Guest: {guest.Name} department: {guest.Department.Name}");
            //     }
            // }
        }
    }
}