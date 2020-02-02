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
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var  pat = db.Patient.Include(p => p.User).ThenInclude(u => u.Photo).Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.Speciality)
                .Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.PlaceOfWork)
                .Include(p => p.MyAppointments).ThenInclude(a => a.Doctor.User).ThenInclude(a => a.Photo).FirstOrDefault(p => p.Id == id);
            if (pat == null)
            {
                return BadRequest();
            }
            var listApprs = pat.MyAppointments.Where(p => p.DateTimeReceipt > DateTime.Now).OrderBy(p => p.DateTimeReceipt).ToList();
            var historyApprs = pat.MyAppointments.Where(p => p.DateTimeReceipt < DateTime.Now).OrderByDescending(p => p.DateTimeReceipt).ToList();
            return Ok(new
            {
                patient = pat,
                appointments = listApprs,
                history = historyApprs,
            });
        }

        // POST: api/Profile
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Profile/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
