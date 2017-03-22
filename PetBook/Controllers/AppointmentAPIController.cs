
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
    public class AppointmentController : ApiController
    {
        private PetBook.PetBookModelContainer db = new PetBook.PetBookModelContainer();

        public IQueryable<AppointmentDTO> GetAppointments(int pageSize = 10
                        ,System.Int32? VeterinarianId = null
                        ,System.Int32? CustomerId = null
                )
        {
            var model = db.Appointments.AsQueryable();
                                if(VeterinarianId != null){
                        model = model.Where(m=> m.VeterinarianId == VeterinarianId.Value);
                    }
                                if(CustomerId != null){
                        model = model.Where(m=> m.CustomerId == CustomerId.Value);
                    }
                        
            return model.Select(AppointmentDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(AppointmentDTO))]
        public async Task<IHttpActionResult> GetAppointment(int id)
        {
            var model = await db.Appointments.Select(AppointmentDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutAppointment(int id, Appointment model)
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
                if (!AppointmentExists(id))
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

        [ResponseType(typeof(AppointmentDTO))]
        public async Task<IHttpActionResult> PostAppointment(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Appointments.Select(AppointmentDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(AppointmentDTO))]
        public async Task<IHttpActionResult> DeleteAppointment(int id)
        {
            Appointment model = await db.Appointments.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Appointments.Select(AppointmentDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
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

        private bool AppointmentExists(int id)
        {
            return db.Appointments.Count(e => e.Id == id) > 0;
        }
    }
}