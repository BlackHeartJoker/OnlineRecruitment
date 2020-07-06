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
using OnlineRecruitment.BusinessLayer;
using OnlineRecruitment.DataAccessLayer;
using OnlineRecruitment.DataAccessLayer.Models;

namespace OnlineRecruitment.Controllers
{
    [Authorize(Roles ="JobSeeker")]
    public class PersonController : ApiController
    {
        private HelperClasses helper;
        public PersonController()
        {
            helper = new HelperClasses();
        }

        // GET: api/Person
        public List<Person> GetEmployerTable()
        {
            return helper.GetAllPersons();
        }

        // GET: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            var person = helper.GetPersonById(id);
            if(person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            helper.UpdatePerson(person);
            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            var person = helper.DeletePerson(id);
            return Ok(person);
        }
    }
}