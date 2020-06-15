using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
	public class ChatMessage
	{
		[Key]
		public long Id { get; set; }
		[Display(Name = "Автор"), ForeignKey(nameof(Author))]
		public long Fk_Author { get; set; }
		[Required]
		[Display(Name = "Чат"), ForeignKey(nameof(DoctorChat))]
		public long Fk_DoctorChat { get; set; }
		[Required]
		[Display(Name = "Сообщение"), Column(TypeName = "nvarchar(MAX)")]
		public string Text { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		public DateTime EditedAt { get; set; }
		public bool Removed { get; set; }


		
		public virtual User Author { get; set; }
		public virtual DoctorChat DoctorChat { get; set; }

	}
}
