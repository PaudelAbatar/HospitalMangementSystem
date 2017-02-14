using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Data.Entities;
using System.Data.Entity;

namespace Hospital.Data
{
   public class HMContext: DbContext
    {
public HMContext():base("HMConn")
        { }
       public DbSet<Patientinfo> PInfo { get; set; }
        public DbSet<PatientLogin>PLogin { get; set; }
    }
}
