using EF_Core_Intro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro.Data
{
    internal class PersonelContext: DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<PersonelDetay> PersonelDetaylar { get; set; }
        //public DbSet<PersonelBolum> PersonelBolumler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=.;initial catalog=YY2_PersonelDB;integrated security=true;trust server certificate=true");
        }

    }
}
