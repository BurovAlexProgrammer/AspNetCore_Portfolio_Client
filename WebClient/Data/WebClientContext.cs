using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDAL.Entity;

namespace WebClient.Data
{
    public class WebClientContext : DbContext
    {
        public WebClientContext (DbContextOptions<WebClientContext> options)
            : base(options)
        {
        }

        public DbSet<WebDAL.Entity.Guest> Guest { get; set; }
    }
}
