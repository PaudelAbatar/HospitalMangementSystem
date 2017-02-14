using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Hospital.Data;
using Hospital.Data.Entities;
using System.Net.Http.Formatting;

namespace HM.Data.API.Controllers
{
    public class PatientLoginsController : ApiController
    {
        private HMContext db = new HMContext();

        // GET: api/PatientLogins
        public IQueryable<PatientLogin> GetPLogin()
        {
            return db.PLogin;
        }

        // GET: api/PatientLogins/5
        [ResponseType(typeof(PatientLogin))]
        public IHttpActionResult GetPatientLogin(int id)
        {
            PatientLogin patientLogin = db.PLogin.Find(id);
            if (patientLogin == null)
            {
                return NotFound();
            }

            return Ok(patientLogin);
        }

        // PUT: api/PatientLogins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientLogin(int id, PatientLogin patientLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientLogin.PatientLoginID)
            {
                return BadRequest();
            }

            db.Entry(patientLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientLoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PatientLogins
        [ResponseType(typeof(PatientLogin))]
        public IHttpActionResult PostPatientLogin(PatientLogin patientLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PLogin.Add(patientLogin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patientLogin.PatientLoginID }, patientLogin);
        }
        [HttpPost]
        [Route("PostData")]
        public String PostData(FormDataCollection data)
        {

            PatientLogin obj = new PatientLogin();
            obj.PatientLoginID = Convert.ToInt32(data.Get("PatientLoginID").ToString());
            obj.PatientName = data.Get("PatientName");
            obj.PassWord = data.Get("PassWord");
            db.PLogin.Add(obj);
            db.SaveChanges();
            return "Record is saved";
        }

        // DELETE: api/PatientLogins/5
        [ResponseType(typeof(PatientLogin))]
        public IHttpActionResult DeletePatientLogin(int id)
        {
            PatientLogin patientLogin = db.PLogin.Find(id);
            if (patientLogin == null)
            {
                return NotFound();
            }

            db.PLogin.Remove(patientLogin);
            db.SaveChanges();

            return Ok(patientLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientLoginExists(int id)
        {
            return db.PLogin.Count(e => e.PatientLoginID == id) > 0;
        }
    }
}