using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Имя пользователя"), Column(TypeName = "Nvarchar(100)")]
        public String FullName { get; set; }
        [Display(Name = "Пол")]
        public int? Enum_Gender { get; set; }
        [Required]
        [Display(Name = "Email"), Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; }
        [Display(Name = "Телефон"), Column(TypeName = "varchar(15)")]
        public String Phone { get; set; }
        [Display(Name = "Фото"), ForeignKey(nameof(Photo))]
        public long Fk_Photo { get; set; }
        [Display(Name = "Роль")]
        public int Enum_Role { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }                    

        public virtual Images Photo { get; set; }
		[JsonIgnore]
		[InverseProperty(nameof(PatientCard.User))]
		public virtual ICollection<PatientCard> PatientCards { get; set; } = new HashSet<PatientCard>();

	}
}
