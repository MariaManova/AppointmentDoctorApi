using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
	public class ChatDoctorViewModel
	{
		public long Fk_Doctor { get; set; }
		public long Fk_Patient { get; set; }

		public DateTime date = DateTime.Now;


		public static explicit operator DoctorChat(ChatDoctorViewModel m)
		{
			return new DoctorChat()
			{
				
				Fk_Doctor = m.Fk_Doctor,
				Fk_Patient = m.Fk_Patient,
				CreatedAt = m.date,
				EditedAt = m.date,
				Removed = false,
			};
		}
	}
}
