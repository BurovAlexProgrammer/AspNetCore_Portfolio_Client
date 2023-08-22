using System.Collections.Generic;

namespace WebDAL.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Guest> Guests  { get; set; }
    }
}