using DataAccessLayer.Metods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Diary;TrustServerCertificate=true;Trusted_Connection=True;Max Pool Size=500;");
        }

        public DbSet<DiarysModel> Diarys { get; set; }
        public DbSet<UsersModel> Users { get; set; }



    }
}
