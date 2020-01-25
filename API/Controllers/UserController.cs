using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using SaleMSSQL.Models;

namespace SaleMSSQL.Controllers
{
    public class UserController : ApiController
    {
        private saledbEntities db = new saledbEntities();

       
        // POST: api/User
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostUser(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string password = Sha256(employee.password);
            var rs = db.Employee
                       .Where(s => s.username == employee.username && s.password == password)
                       .FirstOrDefault<Employee>();
            if (rs == null)
            {
                return NotFound();
            }
            return Ok(rs);
        }

        public static string Sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}