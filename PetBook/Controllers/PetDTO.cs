
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
	public class PetDTO
    {
		public System.Int32 Id { get; set; }
		public System.String Name { get; set; }
		public System.String Type { get; set; }
		public System.String Breed { get; set; }
		public System.Int32 Age { get; set; }
		public System.String Size { get; set; }
		public System.Int32 Weight { get; set; }
		public System.Boolean IsAggressive { get; set; }
		public System.Boolean OnMed { get; set; }
		public System.DateTime StartDate { get; set; }
		public System.Int32 VisitsPerYear { get; set; }
		public System.Boolean IsHealthy { get; set; }
		public System.Int32 CustomerId { get; set; }
		public System.Boolean Gender { get; set; }
		public string Customer_Name { get; set; }
		public int Profiles_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< Pet,  PetDTO>> SELECT =
            x => new  PetDTO
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Breed = x.Breed,
                Age = x.Age,
                Size = x.Size,
                Weight = x.Weight,
                IsAggressive = x.IsAggressive,
                OnMed = x.OnMed,
                StartDate = x.StartDate,
                VisitsPerYear = x.VisitsPerYear,
                IsHealthy = x.IsHealthy,
                CustomerId = x.CustomerId,
                Gender = x.Gender,
                Customer_Name = x.Customer.Name,
                Profiles_Count = x.Profiles.Count(),
            };

	}
}