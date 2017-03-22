
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
	public class AppointmentDTO
    {
		public System.Int32 Id { get; set; }
		public System.DateTime Date { get; set; }
		public System.Boolean IsFirstVisit { get; set; }
		public System.Int32 VeterinarianId { get; set; }
		public System.Int32 CustomerId { get; set; }
		public string Veterinarian_Name { get; set; }
		public string Customer_Name { get; set; }

        public static System.Linq.Expressions.Expression<Func< Appointment,  AppointmentDTO>> SELECT =
            x => new  AppointmentDTO
            {
                Id = x.Id,
                Date = x.Date,
                IsFirstVisit = x.IsFirstVisit,
                VeterinarianId = x.VeterinarianId,
                CustomerId = x.CustomerId,
                Veterinarian_Name = x.Veterinarian.Name,
                Customer_Name = x.Customer.Name,
            };

	}
}