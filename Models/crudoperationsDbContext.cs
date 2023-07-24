
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Netcore5CRUD.Models
{
    public class crudoperationsDbContext : IdentityDbContext
    {
        public crudoperationsDbContext(DbContextOptions options) : base(options)
        {


        }
       public  DbSet<Genres> Genres { get; set; }
       public  DbSet<Movies> Movies { get; set; }

     
    }
}