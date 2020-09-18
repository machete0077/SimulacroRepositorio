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
using Simulacro.Models;

namespace Simulacro.Controllers
{
    public class ArcesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Arces
        public IQueryable<Arce> GetStudents()
        {
            return db.Students;
        }

        // GET: api/Arces/5
        [ResponseType(typeof(Arce))]
        public IHttpActionResult GetArce(int id)
        {
            Arce arce = db.Students.Find(id);
            if (arce == null)
            {
                return NotFound();
            }

            return Ok(arce);
        }

        // PUT: api/Arces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArce(int id, Arce arce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arce.ArceID)
            {
                return BadRequest();
            }

            db.Entry(arce).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArceExists(id))
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

        // POST: api/Arces
        [ResponseType(typeof(Arce))]
        public IHttpActionResult PostArce(Arce arce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(arce);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = arce.ArceID }, arce);
        }

        // DELETE: api/Arces/5
        [ResponseType(typeof(Arce))]
        public IHttpActionResult DeleteArce(int id)
        {
            Arce arce = db.Students.Find(id);
            if (arce == null)
            {
                return NotFound();
            }

            db.Students.Remove(arce);
            db.SaveChanges();

            return Ok(arce);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArceExists(int id)
        {
            return db.Students.Count(e => e.ArceID == id) > 0;
        }
    }
}