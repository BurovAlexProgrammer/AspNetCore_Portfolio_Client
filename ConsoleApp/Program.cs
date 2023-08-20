using System;
using System.Linq;
using WebAPI;
using WebDAL;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PostgresDbContext())
            {
                // var guest1 = new Guest() { Name = "Test1", Surname = "Ttt" };
                // var guest2 = new Guest() { Name = "Test2", Surname = "Aaaa" };
                // db.Guests.AddRange(guest1, guest2);
                // db.SaveChangesAsync();
            }

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
    }
}