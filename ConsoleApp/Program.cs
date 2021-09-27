using System;
using Tendo.Services;

namespace Tendo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new SurveyRepository();
            var simpleSentimentAnalysis = new SimpleSentimentAnalysis();
            var complexSentimentAnalysis = new ComplexSentimentAnalysis();
            repo.InitWithTestData();
            var patient = repo.PatientWithIncompleteReview();
            var reviews = repo.IncompleteReview(patient.Id);
            foreach (var review in reviews)
            {

                Console.WriteLine($"Hi {review.Appointment.Patient.FirstName()}, on a scale of 1 - 10, would you recommend Dr {review.Appointment.Doctor.Family} to a friend or family member ? 1 = Would not recommend, 10 = Would strongly recommend");
                review.DoctorRating = ValidateDoctorRating(Console.ReadLine());

                while (review.DoctorRating == 0)
                {
                    Console.WriteLine($"  Only numbers between 1 (Would not recommend) and 10 (Would strongly recommend) please");
                    review.DoctorRating = ValidateDoctorRating(Console.ReadLine());
                }
                Console.WriteLine($"Thank you. You were diagnosed with {review.Appointment.PrimaryDiagnosis.FriendlyDescription}. Did Dr {review.Appointment.Doctor.Family} explain how to manage this diagnosis in a way you could understand?");
                review.DoctorExplanationFeeling = Console.ReadLine();
                review.DoctorExplanationFeelingSentiment = simpleSentimentAnalysis.AnalyzeText(review.DoctorExplanationFeeling);

                Console.WriteLine($"We appreciate the feedback, one last question: how do you feel about being diagnosed with {review.Appointment.PrimaryDiagnosis.FriendlyDescription}?");
                review.DiagnosisFeeling = Console.ReadLine();
                review.DiagnosisFeelingSentiment = complexSentimentAnalysis.AnalyzeText(review.DiagnosisFeeling);

                DisplayReview(review);
            }
        }

        private static void DisplayReview(Models.AppointmentReview review)
        {
            Console.WriteLine("Thanks again! Here’s what we heard:");
            // doctor rating
            if (review.DoctorRating >= 8)
                Console.WriteLine($"  You would recommend Dr {review.Appointment.Doctor.Family} to your family and friends. We will let the doctor know you really liked your visit");
            else if (review.DoctorRating >= 5)
                Console.WriteLine($"  You may recommend {review.Appointment.Doctor.Family} to your family and friends. We will let the doctor know.");
            else
                Console.WriteLine($"  You would not recommend Dr {review.Appointment.Doctor.Family}. We may reach out to you later to get more information on how we can improve our service.");

            // feeling about explanation
            if (review.DoctorExplanationFeelingSentiment > .5F)
            {
                Console.WriteLine($"  You understand how to manage your {review.Appointment.PrimaryDiagnosis.FriendlyDescription}. ");
            }
            else
            {
                Console.WriteLine($"  You may have more questions about how to manage your {review.Appointment.PrimaryDiagnosis.FriendlyDescription}. We may reach out to see if we can help.");
            }

            // feeling about diagnosis
            if (review.DiagnosisFeelingSentiment> .5F)
            {
                Console.WriteLine($"  You feel ok with your diagnosis of {review.Appointment.PrimaryDiagnosis.FriendlyDescription}. ");
            }
            else
            {
                Console.WriteLine($"  You have concerns about your diagnosis of {review.Appointment.PrimaryDiagnosis.FriendlyDescription}.");
                if (review.DoctorExplanationFeelingSentiment > .5F)
                {
                    Console.WriteLine($"Dr {review.Appointment.Doctor.Family} is looking forward to helping you with any future needs. ");
                }
                else {
                    Console.WriteLine($"Our medical staff is looking forward to helping you with any future needs. ");
                }
            }

        }

        private static int ValidateDoctorRating(string input)
        {
            int rating = 0;
            if (int.TryParse(input, out int parsedRating))
            {
                if (parsedRating > 0 && parsedRating <= 10)
                    rating = parsedRating;
            }
            return rating;
        }
    }
}
