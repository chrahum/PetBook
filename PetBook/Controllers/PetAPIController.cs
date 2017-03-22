
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
    public class PetController : ApiController
    {
        private PetBook.PetBookModelContainer db = new PetBook.PetBookModelContainer();

        public IQueryable<PetDTO> GetPets(int pageSize = 10
                        ,System.Int32? CustomerId = null
                )
        {
            var model = db.Pets.AsQueryable();
                                if(CustomerId != null){
                        model = model.Where(m=> m.CustomerId == CustomerId.Value);
                    }
                        
            return model.Select(PetDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(PetDTO))]
        public async Task<IHttpActionResult> GetPet(int id)
        {
            var model = await db.Pets.Select(PetDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutPet(int id, Pet model)
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
                if (!PetExists(id))
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

        [ResponseType(typeof(PetDTO))]
        public async Task<IHttpActionResult> PostPet(Pet model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Pets.Select(PetDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(PetDTO))]
        public async Task<IHttpActionResult> DeletePet(int id)
        {
            Pet model = await db.Pets.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Pets.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Pets.Select(PetDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
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

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.Id == id) > 0;
        }
    }
}