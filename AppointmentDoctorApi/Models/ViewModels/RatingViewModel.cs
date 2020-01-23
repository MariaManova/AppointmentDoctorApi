using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
    public class RatingViewModel
    {
        public int TotalSumRating { get; set; }
        public int NumRated { get; set; }
        public double Rating { get; set; }
        public int Assessment { get; set; }
        public long Id_User { get; set; }
    }
}
