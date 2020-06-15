using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
	public class NewMessageViewModel
	{
		public long Fk_Doctor { get; set; }
		public long Fk_Patient { get; set; }




	}
}
