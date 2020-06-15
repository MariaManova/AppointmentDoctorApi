using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "Nvarchar(200)")]
        public String Address { get; set; }
        [Display(Name = "Данные пользователя"), ForeignKey(nameof(User))]
        public long Fk_User { get; set; }
		[InverseProperty(nameof(DoctorChat.Patient))]
		public virtual ICollection<DoctorChat> MyDoctorsChats { get; set; } = new HashSet<DoctorChat>();
		[InverseProperty(nameof(PatientCard.Patient))]
		public virtual ICollection<PatientCard> PatientCardss { get; set; } = new HashSet<PatientCard>();
		[InverseProperty(nameof(Appointment.Patient))]
        public virtual ICollection<Appointment> MyAppointments { get; set; } = new HashSet<Appointment>();
		
		public virtual User User { get; set; }
    }
}
