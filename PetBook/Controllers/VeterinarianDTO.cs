
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
	public class VeterinarianDTO
    {
		public System.Int32 Id { get; set; }
		public System.String Name { get; set; }
		public System.String Address { get; set; }
		public System.Int32 Age { get; set; }
		public System.Boolean Gender { get; set; }
		public System.String Location { get; set; }
		public System.String Email { get; set; }
		public System.String PhoneNumber { get; set; }
		public System.String Username { get; set; }
		public System.String Password { get; set; }
		public System.String NameOfBusiness { get; set; }
		public int Customers_Count { get; set; }
		public int Appointments_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< Veterinarian,  VeterinarianDTO>> SELECT =
            x => new  VeterinarianDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Age = x.Age,
                Gender = x.Gender,
                Location = x.Location,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Username = x.Username,
                Password = x.Password,
                NameOfBusiness = x.NameOfBusiness,
                Customers_Count = x.Customers.Count(),
                Appointments_Count = x.Appointments.Count(),
            };

	}
}