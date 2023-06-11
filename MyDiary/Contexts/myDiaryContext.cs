using Microsoft.EntityFrameworkCore;
using MyDiary.Models.ORMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Contexts
{
    public class myDiaryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UPLPK9E; Database=MyDiaryDb; Trusted_Connection=True");
        }


        public DbSet <Diary> diaries { get; set; }

    }
}
