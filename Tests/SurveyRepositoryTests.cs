using System;
using Xunit;
using Tendo.Services;
using Tendo.Models;
using System.Linq;

namespace Tendo.Tests
{
    public class SurveyRepositoryTests
    {
        Guid _testPatientId = new Guid("6739ec3e-93bd-11eb-a8b3-0242ac130003");
        [Fact]
        public void GetFirstIncompleteSurvey()
        {
            var repo = new SurveyRepository();
            repo.InitWithTestData();
            AppointmentReview incompleteReview = repo.IncompleteReview(_testPatientId).FirstOrDefault();
            Assert.NotNull(incompleteReview);
            Assert.Equal("Diabetes without complications", incompleteReview.Appointment.PrimaryDiagnosis.FriendlyDescription);
            Assert.Equal("Careful", incompleteReview.Appointment.Doctor.Family);
            Assert.Equal("Tendo", incompleteReview.Appointment.Patient.FirstName());
        }
        [Fact]
        public void GetPatientWithReview()
        {
            var repo = new SurveyRepository();
            Patient patient = repo.PatientWithIncompleteReview();
            Assert.Null(patient);
            repo.InitWithTestData();
            Assert.Equal(_testPatientId, repo.PatientWithIncompleteReview().Id);
        }
    }
}
