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
using OnlineRecruitment.DataAccessLayer;
using OnlineRecruitment.DataAccessLayer.Models;

namespace OnlineRecruitment.Controllers
{
    [Authorize(Roles ="Employer")]
    public class EmployersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employers
        public IQueryable<Employer> GetEmployerTable()
        {
            return db.EmployerTable;
        }

        // GET: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult GetEmployer(int id)
        {
            Employer employer = db.EmployerTable.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // PUT: api/Employers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployer(int id, Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employer.EmployerId)
            {
                return BadRequest();
            }

            db.Entry(employer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers
        [ResponseType(typeof(Employer))]
        public IHttpActionResult PostEmployer(Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployerTable.Add(employer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employer.EmployerId }, employer);
        }

        // DELETE: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult DeleteEmployer(int id)
        {
            Employer employer = db.EmployerTable.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            db.EmployerTable.Remove(employer);
            db.SaveChanges();

            return Ok(employer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerExists(int id)
        {
            return db.EmployerTable.Count(e => e.EmployerId == id) > 0;
        }
    }
}