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

namespace HM.Data.API.Controllers
{
    public class PatientinfoesController : ApiController
    {
        private HMContext db = new HMContext();

        // GET: api/Patientinfoes
        public IQueryable<Patientinfo> GetPInfo()
        {
            return db.PInfo;
        }

        // GET: api/Patientinfoes/5
        [ResponseType(typeof(Patientinfo))]
        public IHttpActionResult GetPatientinfo(int id)
        {
            Patientinfo patientinfo = db.PInfo.Find(id);
            if (patientinfo == null)
            {
                return NotFound();
            }

            return Ok(patientinfo);
        }

        // PUT: api/Patientinfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientinfo(int id, Patientinfo patientinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientinfo.PatientInfoID)
            {
                return BadRequest();
            }

            db.Entry(patientinfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientinfoExists(id))
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

        // POST: api/Patientinfoes
        [ResponseType(typeof(Patientinfo))]
        public IHttpActionResult PostPatientinfo(Patientinfo patientinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PInfo.Add(patientinfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patientinfo.PatientInfoID }, patientinfo);
        }

        // DELETE: api/Patientinfoes/5
        [ResponseType(typeof(Patientinfo))]
        public IHttpActionResult DeletePatientinfo(int id)
        {
            Patientinfo patientinfo = db.PInfo.Find(id);
            if (patientinfo == null)
            {
                return NotFound();
            }

            db.PInfo.Remove(patientinfo);
            db.SaveChanges();

            return Ok(patientinfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientinfoExists(int id)
        {
            return db.PInfo.Count(e => e.PatientInfoID == id) > 0;
        }
    }
}