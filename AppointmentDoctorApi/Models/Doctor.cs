using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    public class Doctor
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Специальность"), ForeignKey(nameof(Speciality))]
        public long Fk_Speciality { get; set; }
        [Display(Name = "Место работы"), ForeignKey(nameof(PlaceOfWork))]
        public long Fk_PlaceOfWork { get; set; }
        [Display(Name = "Категория")]
        public int Enum_Category { get; set; }
        public double Rating { get; set; }
        [Display(Name = "Данные пользователя"), ForeignKey(nameof(User))]
        public long Fk_User { get; set; }
        public int TotalSumRating { get; set; }
        public int NumRated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }


        [JsonIgnore]
        [InverseProperty(nameof(Appointment.Doctor))]
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        [InverseProperty(nameof(WorkSchedule.Doctor))]
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new HashSet<WorkSchedule>();
		[JsonIgnore]
		[InverseProperty(nameof(DoctorChat.Doctor))]
		public virtual ICollection<DoctorChat> DDoctorsChats { get; set; } = new HashSet<DoctorChat>();
		public virtual Speciality Speciality { get; set; }
        public virtual PlaceOfWork PlaceOfWork { get; set; }        
        public virtual User User { get; set; }
    }
}
