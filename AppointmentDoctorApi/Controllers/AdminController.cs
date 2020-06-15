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

namespace AppointmentDoctorApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AppDbContext db;
        public AdminController(AppDbContext db, IUserService userService)
        {
            this.db = db;
            this.userService = userService;
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
       [HttpPost("creationDoctor")]
        public IActionResult CreationDoctor([FromBody] DoctorViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Role = (int)Role.doc;
            User doc;
            try
            {
                doc = userService.Create((User)model, "г. Владимир", model.Password);
            }
            catch (AppException e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Произошла ошибка, попробуйте позже"
                });
            }
            var doctor = (Doctor)model;
            doctor.Fk_User = doc.Id;

            db.Add(doctor);
            db.SaveChanges();
            return Ok(doctor);
        }

        //POST: api/Admin/creationSpeciality
        [HttpPost("creationSpeciality")]
        public IActionResult CreationSpeciality([FromBody] Speciality speciality)
        {
            if (speciality == null)
            {
                return BadRequest();
            }           
            db.Add(speciality);
            db.SaveChanges();
            return Ok();
        }

        //POST: api/Admin/creationPlaceOfWork
        [HttpPost("creationPlaceOfWork")]
        public IActionResult CreationPlaceOfWork([FromBody] PlaceOfWork placeOfWork)
        {
            if (placeOfWork == null)
            {
                return BadRequest();
            }
            db.Add(placeOfWork);
            db.SaveChanges();
            return Ok();
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
