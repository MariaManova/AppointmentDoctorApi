using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorApi.Models
{
    public class Images
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Removed { get; set; }
    }
}