using ApiEmpty.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpty.Models
{
    public class EmptyContext : DbContext
    {
       public EmptyContext(DbContextOptions<EmptyContext> options) 
            :base(options)
        { 

        }

        public DbSet <Empty> Empties { get; set; }
    }
}
