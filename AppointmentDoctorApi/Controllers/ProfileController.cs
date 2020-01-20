using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentDoctorApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentDoctorApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        AppDbContext db;
        public ProfileController(AppDbContext db)
        {
            this.db = db;
        }
        // GET: api/Profile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
             var  pat = db.Patient.Include(p => p.MyAppointments).FirstOrDefault(p => p.Id == id);
            var  us = db.User.Include(u => u.Photo).FirstOrDefault(u => u.Id == pat.Fk_User);
            return Ok(new
            {
                patient = pat,
                user = us
            });
        }

        // POST: api/Profile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
