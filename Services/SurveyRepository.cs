using System;
using System.Collections.Generic;
using System.Linq;
using Tendo.Models;

namespace Tendo.Services
{
    public class SurveyRepository
    {
        private List<AppointmentReview> AppointmentReviews { get; set; }
        public SurveyRepository()
        {
            AppointmentReviews = new List<AppointmentReview>();
        }
        public void InitWithTestData()
        {
            var tendoTenderson = new Patient
            {
                Id = new Guid("6739ec3e-93bd-11eb-a8b3-0242ac130003"),
                Family = "Tenderson",
                Given = new List<string> { "Tendo" }
            };
            var doctor = new Doctor
            {
                Id = new Guid("9bf9e532-93bd-11eb-a8b3-0242ac130003"),
                Family = "Careful",
                Given = new List<string> { "Adam" }
            };
            var diagnosis = new Diagnosis
            {
                Id = new Guid("541a72a8-df75-4484-ac89-ac4923f03b81"),
                Code = "E10-E14.9",
                FriendlyDescription = "Diabetes without complications"
            };
            var appointment = new Appointment
            {
                Id = new Guid("be142dc6-93bd-11eb-a8b3-0242ac130003"),
                Doctor = doctor,
                Patient = tendoTenderson,
                PrimaryDiagnosis = diagnosis
            };
            AppointmentReviews.Add(
                new AppointmentReview
                {
                    Appointment = appointment,
                    Complete = false
                }
            );
        }
        public List<AppointmentReview> IncompleteReview(Guid testPatientId)
        {
            return AppointmentReviews
                .Where(a => a.Appointment.Patient.Id == testPatientId
                    && a.Complete == false)
                .ToList();
        }
        public Patient PatientWithIncompleteReview()
        {
            return (from ar in AppointmentReviews
                    where ar.Complete == false
                    select ar.Appointment.Patient).FirstOrDefault();
        }
    }
}
