
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
    public class CustomerController : ApiController
    {
        private PetBook.PetBookModelContainer db = new PetBook.PetBookModelContainer();

        public IQueryable<CustomerDTO> GetCustomers(int pageSize = 10
                        ,System.Int32? VeterinarianId = null
                )
        {
            var model = db.Customers.AsQueryable();
                                if(VeterinarianId != null){
                        model = model.Where(m=> m.VeterinarianId == VeterinarianId.Value);
                    }
                        
            return model.Select(CustomerDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(CustomerDTO))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var model = await db.Customers.Select(CustomerDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutCustomer(int id, Customer model)
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
                if (!CustomerExists(id))
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

        [ResponseType(typeof(CustomerDTO))]
        public async Task<IHttpActionResult> PostCustomer(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Customers.Select(CustomerDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(CustomerDTO))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer model = await db.Customers.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Customers.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Customers.Select(CustomerDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
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

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}