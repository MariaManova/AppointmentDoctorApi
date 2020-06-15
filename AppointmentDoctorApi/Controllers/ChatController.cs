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
	public class ChatController : ControllerBase
	{
		AppDbContext db;
		public ChatController(AppDbContext db)
		{
			this.db = db;
		}
		// GET: api/Chat/all
		[AllowAnonymous]
		[HttpGet("all")]
		public ActionResult<IEnumerable<Doctor>> Get()
		{
			return db.Doctor.Include(d => d.User.Photo).Include(d => d.Speciality).Include(d => d.PlaceOfWork).OrderBy(p => p.CreatedAt).ToList();
		}

		// GET: api/Chat/get/chats
		[AllowAnonymous]
		[HttpGet("get/chats")]
		public IActionResult GetChats(long id_DoctorChat)
		{
			if (id_DoctorChat == 0)
			{
				return BadRequest();
			}
			var mess = db.ChatMessage.Where(a => a.Fk_DoctorChat == id_DoctorChat).OrderByDescending(a => a.EditedAt).ToList();
			return Ok(new
			{
				messages = mess
			}
				
				) ;
		}
		// GET: api/Chat/get/chats
		//[AllowAnonymous]
		//[HttpGet("get/chats")]
		//public IActionResult GetPChats(long id_Patient)
		//{
		//	if (id_Patient == 0)
		//	{
		//		return BadRequest();
		//	}
		//	var chat = db.DoctorChat.Where(a => a.Fk_Patient == id_Patient).OrderByDescending(a => a.EditedAt).ToList();
		//	return Ok(new
		//	{
		//		chats = chat,
		//	});
		//}

		
		[HttpPost("post/messages")]
		public IActionResult GetMessages( [FromBody] ChatDoctorViewModel model)// [FromQuery] Guid id_DoctorChat,
		{
			//if (id_DoctorChat == Guid.Empty)
			//{
			//	return BadRequest();
			//}

			//var mess = db.DoctorChat.Where(a => a.Uid == id_DoctorChat).Include(a => a.ChatMessages).OrderByDescending(a => a.EditedAt).ToList();
			//if (mess != null){
			//	var chat = (DoctorChat)model;
			//	db.Add(chat);
			//	db.SaveChanges();
			//	mess = db.DoctorChat.Where(a => a.Uid == chat.Uid).Include(a => a.ChatMessages).OrderByDescending(a => a.EditedAt).ToList();
			//}
			var chat = db.DoctorChat.Where(a => a.Fk_Patient == model.Fk_Patient && a.Fk_Doctor == model.Fk_Doctor).FirstOrDefault();
			
           if (chat == null)
			{
			    chat = (DoctorChat)model;
				db.Add(chat);
				db.SaveChanges();
			}
			return Ok(new
			{
				//messages = chat.ChatMessages,
				doctorchat = chat
				
			});
		}

		[HttpPost("create/messages")]
		public IActionResult CreateMessages([FromBody] MessageViewModel model)
		{
			if (model == null)
			{
				return BadRequest();
			}
			var mess = (ChatMessage)model;
			db.Add(mess);
			db.SaveChanges();
			return Ok(mess);
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
			var pt = db.Patient
				.Include(p => p.User).ThenInclude(u => u.Photo)
				.Include(p => p.MyDoctorsChats)
				.ThenInclude(a => a.Doctor)
				.ThenInclude(a => a.Speciality)
				//.Include(p => p.MyDoctorsChats).ThenInclude(a => a.Doctor).ThenInclude(a => a.PlaceOfWork)
				//.Include(p => p.MyDoctorsChats).ThenInclude(a => a.Doctor.User).ThenInclude(a => a.Photo)
				.FirstOrDefault(p => p.Id == id);
			if (pt == null)
			{
				return BadRequest();
			}
			
			var historyApprs = pt.MyDoctorsChats.OrderBy(p => p.CreatedAt).ToList();

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
			var doc = db.Doctor
				//.Where(p => p.Fk_User == id_Doctor)
				.Include(p => p.User).ThenInclude(u => u.Photo).Include(p => p.DDoctorsChats)
				.ThenInclude(a => a.Patient).ThenInclude(a => a.User)
				//.Include(p => p.DoctorsChats).ThenInclude(a => a.Patient)
				//.Include(p => p.DoctorsChats).ThenInclude(a => a.Patient.User).ThenInclude(a => a.Photo)
				.FirstOrDefault(p=> p.Fk_User == id_Doctor);
			if (doc == null)
			{
				return BadRequest();
			}
			var historyApprs = doc.DDoctorsChats.OrderBy(p => p.CreatedAt).ToList();
			return Ok(new
			{
				doctor = doc,
				history = historyApprs,
				
			});
		}

	}
}
