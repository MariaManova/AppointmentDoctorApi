using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
	public class MessageViewModel
	{
		public long Fk_Author { get; set; }
		public long Fk_DoctorChat { get; set; }
		public string Text { get; set; }

		public DateTime date = DateTime.Now;


		public static explicit operator ChatMessage(MessageViewModel m)
		{
			return new ChatMessage()
			{
				Fk_Author = m.Fk_Author,
				Fk_DoctorChat = m.Fk_DoctorChat,
				Text = m.Text,
				CreatedAt = m.date,
				EditedAt = m.date,
				Removed = false,
			};
		}
	}
}
