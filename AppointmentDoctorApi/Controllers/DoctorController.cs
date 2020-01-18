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
    public class DoctorController : ControllerBase
    {
        AppDbContext db;
        public DoctorController(AppDbContext db)
        {
            this.db = db;
        }
        // GET: api/Doctor/all
        [AllowAnonymous]
        [HttpGet("all")]
        public ActionResult<IEnumerable<Doctor>> Get()
        {
            return db.Doctor.Include(d => d.User).ThenInclude(u => u.Photo).Include(d => d.Speciality).OrderByDescending(p => p.Speciality.NameSpeciality).ToList();
        }

        // GET: api/Doctor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Doctor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Doctor/5
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
