using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentDoctorApi.Models;
using AppointmentDoctorApi.Models.ViewModels;
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
            return db.Doctor.Include(d => d.User).ThenInclude(u => u.Photo).Include(d => d.Speciality).Include(d => d.PlaceOfWork).OrderBy(p => p.Speciality.NameSpeciality).ToList();
        }

        // GET: api/Doctor/5
        [HttpGet(Name = "Get")]
        public IActionResult Get(long id_Doctor, long id_User)
        {
            if (id_User == 0 || id_Doctor == 0)
            {
                return BadRequest();
            }
            var app = db.Appreciated.FirstOrDefault(a => a.Fk_Doctor == id_Doctor && a.Fk_User == id_User);
            var doc = db.Doctor.FirstOrDefault(d => d.Id == id_Doctor);
            if (doc == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                appreciated = app,
                doctor = doc
            });
        }

        // GET: api/Doctor/5
        [AllowAnonymous]
        [HttpGet( "get/appointments")]
        public IActionResult GetAppointments(long id_Doctor, DateTime date)
        {
            if (id_Doctor == 0)
            {
                return BadRequest();
            }
            var app = db.Appointment.Where(a => a.Fk_Doctor == id_Doctor && 
            a.DateTimeReceipt.Date == date.Date).ToList();
             return Ok(new
            {
                 appointments = app,
            });
        }

        // POST: api/Doctor
        [HttpPost("save/appointment")]
        public IActionResult SaveAppointment([FromBody] AppointmentViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var app = (Appointment)model;
            db.Add(app);
            db.SaveChanges();
            return Ok(app);
        }

        // PUT: api/Doctor/5
        [HttpPut("putARating")]
        public IActionResult PutARating(long id_Doctor, [FromBody] RatingViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var doc = db.Doctor.FirstOrDefault(d => d.Id == id_Doctor);
            if (doc == null)
            {
                return BadRequest();
            }
            doc.TotalSumRating = model.TotalSumRating;
            doc.NumRated = model.NumRated;
            doc.Rating = model.Rating;
            db.Update(doc);
            db.SaveChanges();
            Appreciated ap = (Appreciated) model;
            ap.Fk_Doctor = id_Doctor;
            db.Add(ap);
            db.SaveChanges();
            return Ok(new
            {
                doctor = doc,
                appreciated = ap
            });
        }
        // PUT: api/Doctor/5
        [HttpPut("changeRating")]
        public IActionResult ChangeRating(long id_Doctor, [FromBody] RatingViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var doc = db.Doctor.FirstOrDefault(d => d.Id == id_Doctor);
            if (doc == null)
            {
                return BadRequest();
            }
            doc.TotalSumRating = model.TotalSumRating;
            doc.NumRated = model.NumRated;
            doc.Rating = model.Rating;
            db.Update(doc);
            db.SaveChanges();
            Appreciated ap = db.Appreciated.FirstOrDefault(a => a.Id == model.Id_Appreciated);
            ap.Fk_Doctor = id_Doctor;
            ap.Fk_User = model.Id_User;
            ap.Assessment = model.Assessment;
            ap.dateTime = DateTime.Now;
            db.Update(ap);
            db.SaveChanges();
            return Ok(new
            {
                doctor = doc,
                appreciated = ap
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
