
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
    public class VeterinarianController : ApiController
    {
        private PetBook.PetBookModelContainer db = new PetBook.PetBookModelContainer();

        public IQueryable<VeterinarianDTO> GetVeterinarians(int pageSize = 10
                )
        {
            var model = db.Veterinarians.AsQueryable();
                        
            return model.Select(VeterinarianDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(VeterinarianDTO))]
        public async Task<IHttpActionResult> GetVeterinarian(int id)
        {
            var model = await db.Veterinarians.Select(VeterinarianDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutVeterinarian(int id, Veterinarian model)
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
                if (!VeterinarianExists(id))
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

        [ResponseType(typeof(VeterinarianDTO))]
        public async Task<IHttpActionResult> PostVeterinarian(Veterinarian model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veterinarians.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Veterinarians.Select(VeterinarianDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(VeterinarianDTO))]
        public async Task<IHttpActionResult> DeleteVeterinarian(int id)
        {
            Veterinarian model = await db.Veterinarians.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Veterinarians.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Veterinarians.Select(VeterinarianDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
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

        private bool VeterinarianExists(int id)
        {
            return db.Veterinarians.Count(e => e.Id == id) > 0;
        }
    }
}