using System;
using System.Linq;
using WebAPI;

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

            // using (var db = new PostgresDbContext())
            // {
            //     db.EnsureDeleted();
            //     db.EnsureCreated();
            //     var dep1 = new Department() { Name = "Dep1" };
            //     var dep2 = new Department() { Name = "Dep2" };
            //     var guest1 = new Guest() { Name = "Test1", Surname = "Ttt", Department = dep1 };
            //     var guest2 = new Guest() { Name = "Test2", Surname = "Aaaa", Department = dep2 };
            //     db.Guests.Add(guest1);
            //     db.Guests.Add(guest2);
            //     db.SaveChanges();
            //     var t1 = db.Departments.Find(dep1.Id);
            //     var t2 = t1.Guests.ToList();
            //     Console.WriteLine("t2: " + t2.Count);
            // }

            using (var db = new PostgresDbContext())
            {
                var dep3 = db.Departments.Single(x => x.Name == "Dep3");
                dep3.Name = "Dep33";
                db.Update(dep3);
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