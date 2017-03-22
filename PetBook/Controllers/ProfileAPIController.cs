
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PetBook
{
    public class ProfileController : ApiController
    {
        private PetBook.PetBookModelContainer db = new PetBook.PetBookModelContainer();

        public IQueryable<ProfileDTO> GetProfiles(int pageSize = 10
                        ,System.Int32? PetId = null
                )
        {
            var model = db.Profiles.AsQueryable();
                                if(PetId != null){
                        model = model.Where(m=> m.PetId == PetId.Value);
                    }
                        
            return model.Select(ProfileDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(ProfileDTO))]
        public async Task<IHttpActionResult> GetProfile(int id)
        {
            var model = await db.Profiles.Select(ProfileDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProfile(int id, Profile model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        [ResponseType(typeof(ProfileDTO))]
        public async Task<IHttpActionResult> PostProfile(Profile model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Profiles.Select(ProfileDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(ProfileDTO))]
        public async Task<IHttpActionResult> DeleteProfile(int id)
        {
            Profile model = await db.Profiles.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Profiles.Select(ProfileDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return Ok(ret);
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
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}