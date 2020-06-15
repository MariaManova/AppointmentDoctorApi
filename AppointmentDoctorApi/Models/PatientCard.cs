using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
	public class PatientCard
	{
		[Key]
		public long Id { get; set; }
		[Display(Name = "Доктор"), ForeignKey(nameof(User))]
		public long Fk_Doctor { get; set; }
		[Display(Name = "Пациент"), ForeignKey(nameof(Patient))]
		public long Fk_Patient { get; set; }
		[Display(Name = "Диагноз")]
		public string Diagnosis { get; set; }
		[Display(Name = "Рекомендации")]
		public string Recommendations { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime EditedAt { get; set; }
		public bool Removed { get; set; }

		public virtual User User { get; set; }
		[JsonIgnore]
		public virtual Patient Patient { get; set; }
	}
}
