using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    
    public class Patientinfo
    {
       
        public int PatientInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
  
    public class PatientLogin

    { 
       
    public int PatientLoginID { get; set; }
    public string PatientName { get; set; }
    public string PassWord { get; set; }
    
    }

}
