using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hospital.Data;
using System.Linq;

namespace HMUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HMContext Obj = new HMContext();
            Obj.PLogin.Add(new Hospital.Data.Entities.PatientLogin
            {
                PatientLoginID = 1,
                    PatientName = "Johnson",
                    PassWord = "123@abc"

                

                });
            Obj.SaveChanges();

            var A = Obj.PLogin.ToList().Where(x => x.PatientName == "Johnson").ToList().FirstOrDefault();
            Assert.AreEqual(A.PatientName, "Je");
        }
       
    }
}
