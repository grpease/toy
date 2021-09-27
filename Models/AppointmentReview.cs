using System;

namespace Tendo.Models
{
    public class AppointmentReview
    {
        public Guid Id { get; set; }
        public Appointment Appointment { get; set; }
        public bool Complete { get; set; }
        public string DiagnosisFeeling { get; set; }
        public float DiagnosisFeelingSentiment { get; set; }
        public string DoctorExplanationFeeling { get; set; }
        public float DoctorExplanationFeelingSentiment { get; set; }
        public int DoctorRating { get; set; }
    }
}
