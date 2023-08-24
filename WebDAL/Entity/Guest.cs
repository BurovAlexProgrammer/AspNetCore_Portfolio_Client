using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDAL.Entity
{
    //[Table("Guests")]
    public class Guest
    {
        public Int64 Id { get; set; }

        [Required] //NOT_NULL
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}