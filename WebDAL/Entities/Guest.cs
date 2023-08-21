using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDAL
{
    //[Table("Guests")]
    public class Guest
    {
        public Int64 Id { get; set; }
        
        [Required] //NOT_NULL
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        [Column("Male")] 
        public bool IsMale { get; set; }
        
        [NotMapped]
        public bool IsNew { get; set; }
        
        public Department Department { get; set; }
    }
}