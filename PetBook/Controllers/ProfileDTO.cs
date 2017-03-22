
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
	public class ProfileDTO
    {
		public System.Int32 Id { get; set; }
		public System.String NotesOfVisit { get; set; }
		public System.Int32 PetId { get; set; }
		public string Pet_Name { get; set; }

        public static System.Linq.Expressions.Expression<Func< Profile,  ProfileDTO>> SELECT =
            x => new  ProfileDTO
            {
                Id = x.Id,
                NotesOfVisit = x.NotesOfVisit,
                PetId = x.PetId,
                Pet_Name = x.Pet.Name,
            };

	}
}