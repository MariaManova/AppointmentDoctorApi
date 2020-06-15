using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
	public class PatientCardViewModel
	{
		public long Fk_Doctor { get; set; }
		public long Fk_Patient { get; set; }
		public string Diagnosis { get; set; }
		public string Recommendations { get; set; }

		public DateTime date = DateTime.Now;


		public static explicit operator PatientCard(PatientCardViewModel m)
		{
			return new PatientCard()
			{
				
				Fk_Doctor = m.Fk_Doctor,
				Fk_Patient = m.Fk_Patient,
				Diagnosis = m.Diagnosis,
				Recommendations = m.Recommendations,
				CreatedAt = m.date,
				EditedAt = m.date,
				Removed = false,
			};
		}
	}
}
