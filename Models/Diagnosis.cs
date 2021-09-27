using System;

namespace Tendo.Models
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FriendlyDescription { get; set; }
    }
}