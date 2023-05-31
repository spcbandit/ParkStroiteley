using Microsoft.EntityFrameworkCore;

using ParkStroiteleyMVC.Models.Configs;
using ParkStroiteleyMVC.Models.ObjectDTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models
{
    public class DBContext :DbContext
    {
        public DbSet<AdminDTO> Admins { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<NewDTO> News { get; set; }
        public DbSet<NewDTO> Events { get; set; }
        public DbSet<ContactsDTO> Contacts { get; set; }
        public DbSet<GalleryDTO> Gallery { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigDatabase.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
