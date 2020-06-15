using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentDoctorApi.Models;
using AppointmentDoctorApi.Models.ViewModels;
using AppointmentDoctorApi.Models.Enumerations;
using AppointmentDoctorApi.Models.Helpers;
using AppointmentDoctorApi.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppointmentDoctorApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AppDbContext db;
        public PatientCardController(AppDbContext db, IUserService userService)
        {
            this.db = db;
         
        }
        // GET: api/Admin
        [AllowAnonymous]
        [HttpGet("dataDoctor")]
        public IActionResult DataDoctor()
        {
            IEnumerable<Speciality> spec = db.Speciality.ToList();
            IEnumerable<PlaceOfWork> plOfW = db.PlaceOfWork.ToList();
            return Ok( new {
                speciality = spec,
                placeOfWork = plOfW
            });
        }

        // GET: api/Admin/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/Admin/creationDoctor
       [HttpPost("creationCard")]
        public IActionResult CreationDoctor([FromBody] PatientCardViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
        
            var card = (PatientCard)model;
      
            db.Add(card);
            db.SaveChanges();
			return Ok(new
			{
				//messages = chat.ChatMessages,
				patientcard = card

			});
		}

        
        
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{


			if (id == 0)
			{
				return BadRequest();
			}
			//var pat = db.Patient.Include(p => p.User).ThenInclude(u => u.Photo).Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.Speciality)
			//	.Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.PlaceOfWork)
			//	.Include(p => p.MyAppointments).ThenInclude(a => a.Doctor.User).ThenInclude(a => a.Photo).FirstOrDefault(p => p.Id == id);
			var pt = db.Patient.Include(p => p.User).ThenInclude(u => u.Photo)
				.Include(p => p.PatientCardss)
				.ThenInclude(a => a.User)
				//.Include(p => p.MyDoctorsChats).ThenInclude(a => a.Doctor).ThenInclude(a => a.PlaceOfWork)
				//.Include(p => p.MyDoctorsChats).ThenInclude(a => a.Doctor.User).ThenInclude(a => a.FullName)
				.FirstOrDefault(p => p.Id == id);
			if (pt == null)
			{
				return BadRequest();
			}

			var historyApprs = pt.PatientCardss.OrderBy(p => p.CreatedAt).ToList();

			return Ok(new
			{
				patient = pt,
				history = historyApprs,
			});
		}

		[HttpGet()]
		public IActionResult GetDoctorChat(long id_Doctor)
		{


			if (id_Doctor == 0)
			{
				return BadRequest();
			}
			//var pat = db.Patient.Include(p => p.User).ThenInclude(u => u.Photo).Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.Speciality)
			//	.Include(p => p.MyAppointments).ThenInclude(a => a.Doctor).ThenInclude(a => a.PlaceOfWork)
			//	.Include(p => p.MyAppointments).ThenInclude(a => a.Doctor.User).ThenInclude(a => a.Photo).FirstOrDefault(p => p.Id == id);
			var doc = db.User
				//.Where(p => p.Fk_User == id_Doctor)
				.Include(p => p.PatientCards)
				.ThenInclude(a => a.Patient).ThenInclude(a => a.User)
				//.Include(p => p.DoctorsChats).ThenInclude(a => a.Patient)
				//.Include(p => p.DoctorsChats).ThenInclude(a => a.Patient.User).ThenInclude(a => a.Photo)
				.FirstOrDefault(p => p.Id == id_Doctor);
			if (doc == null)
			{
				return BadRequest();
			}
			var historyApprs = doc.PatientCards.OrderBy(p => p.CreatedAt).ToList();
			return Ok(new
			{
				doctor = doc,
				history = historyApprs,

			});
		}

		// PUT: api/Admin/5
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
