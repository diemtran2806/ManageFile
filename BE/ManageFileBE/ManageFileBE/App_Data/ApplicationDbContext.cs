﻿using ManageFileBE.Models;
using ManageFileBE.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageFileBE.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FileEntity> FileEntity { get; set; }

        public DbSet<Users>? Users { get; set; }
    }
}
