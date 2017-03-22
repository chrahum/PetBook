
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
	public class CustomerDTO
    {
		public System.Int32 Id { get; set; }
		public System.String Name { get; set; }
		public System.Int32 VeterinarianId { get; set; }
		public System.String Address { get; set; }
		public System.Int32 Age { get; set; }
		public System.String PhoneNumber { get; set; }
		public System.String Email { get; set; }
		public System.Boolean Gender { get; set; }
		public string Veterinarian_Name { get; set; }
		public int Appointments_Count { get; set; }
		public int Pets_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< Customer,  CustomerDTO>> SELECT =
            x => new  CustomerDTO
            {
                Id = x.Id,
                Name = x.Name,
                VeterinarianId = x.VeterinarianId,
                Address = x.Address,
                Age = x.Age,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Gender = x.Gender,
                Veterinarian_Name = x.Veterinarian.Name,
                Appointments_Count = x.Appointments.Count(),
                Pets_Count = x.Pets.Count(),
            };

	}
}