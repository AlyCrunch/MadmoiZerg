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
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api/profiles")]
    public class ProfilesController : ApiController
    {
        private APIContext db;

        public ProfilesController(APIContext context)
        {
            db = context;
        }

        public ProfilesController()
        {
            db = new APIContext();
        }

        [Route("")]
        public IQueryable<Profile> GetProfiles()
        {
            return db.Profiles;
        }

        [Route("{id:int}")]
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ProfileId)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        [Route("")]
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profile.ProfileId }, profile);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(profile);
            db.SaveChanges();

            return Ok(profile);
        }

        [Route("")]
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteAllProfiles()
        {
            var profiles = db.Profiles;
            db.Profiles.RemoveRange(profiles);
            db.SaveChanges();

            return Ok(profiles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profiles.Count(e => e.ProfileId == id) > 0;
        }
    }
}