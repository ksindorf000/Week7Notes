using Day2Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Day2Server.Controllers
{
    public class CerealController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        public IQueryable<Cereal> Get()
        {
            return db.Cereals;
        }

        [ResponseType(typeof(Cereal))]
        public IHttpActionResult Get(int? id)
        {
            Cereal instance = db.Cereals.Find(id);

            if (id == null)
            {
                return BadRequest();
            }

            if (instance == null)
            {
                return NotFound();
            }

            //Return a 200 status with an instance of a model
            return Ok(instance);    
        }

    }
}
