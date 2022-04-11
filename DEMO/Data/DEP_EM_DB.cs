using DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO.Data
{
    public class DEP_EM_DB: DbContext
    {
        public DEP_EM_DB(DbContextOptions<DEP_EM_DB> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
           // modelbuilder.Entity<EMPLEADOS>().ToTable("EMPLEADO", "RH");
        }

        public DbSet<DEPARTAMENTO> Departamento { get; set; }
        public DbSet<EMPLEADOS> Empleados { get; set; }

    }
}
