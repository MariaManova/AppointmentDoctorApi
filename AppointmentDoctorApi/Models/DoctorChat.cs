using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AppointmentDoctorApi.Models
{
	public class DoctorChat
	{
		[Key]
		public long Id { get; set; }
		[Display(Name = "Пациент"), ForeignKey(nameof(Patient))]
		public long Fk_Patient { get; set; }
		[Display(Name = "Доктор"), ForeignKey(nameof(Doctor))]
		public long Fk_Doctor { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		public DateTime EditedAt { get; set; }
		public bool Removed { get; set; }

		[InverseProperty(nameof(ChatMessage.DoctorChat))]
		public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new HashSet<ChatMessage>();
		public virtual Doctor Doctor { get; set; }
		[JsonIgnore]
		public virtual Patient Patient { get; set; }
	
		
		
	}
}
